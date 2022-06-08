using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ICABAPI.Controllers;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{
    public class AwsS3BucketRepository
    {
        private readonly string _bucketName;
        private readonly string _awsAccessKey;
        private readonly string _awsSecretKey;
        private readonly RegionEndpoint _regionEndpoint;
        private readonly IAmazonS3 client;
        public AwsS3BucketRepository()
        {
            _bucketName = "satcombucket";
            _awsAccessKey = "AKIA2YDMPMDLYVIXCP6Z";
            _awsSecretKey = "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";
            _regionEndpoint = RegionEndpoint.APSouth1;
            client = new AmazonS3Client(_awsAccessKey, _awsSecretKey, _regionEndpoint);
        }
        public async void CreateAFolder(string folderPath)
        {
            //string folderPath = "my-folder/sub-folder/";
            //If you forget the trailing slash in the path(i.e. "my-folder/sub-folder") it would create an object called sub - folder.
            //If you include a slash at the beginning of the path (i.e. "/my-folder/sub-folder/") it will create a folder with name as an empty string and put the remaining folders inside it.
            PutObjectRequest request = new PutObjectRequest()
            {
                BucketName = _bucketName,
                Key = folderPath // <-- in S3 key represents a path  
            };

            PutObjectResponse response = await client.PutObjectAsync(request);
        }
        public async void CopyBytesInAFolder(string folderPath, string fileName, byte[] bytes)
        {
            //FileInfo localFile = new FileInfo(@"c:\test.txt");
            ////string path = @"high-level-folder\sub-folder\test.txt";

            //S3FileInfo s3File = new S3FileInfo(client, _bucketName, folderPath);
            //if (!s3File.Exists)
            //{
            //    using (var s3Stream = s3File.Create()) // <-- create file in S3  
            //    {
            //        localFile.OpenRead().CopyTo(s3Stream); // <-- copy the content to S3  
            //    }
            //}
            var request = new PutObjectRequest
            {
                BucketName = _bucketName,
                CannedACL = S3CannedACL.PublicRead,
                //Key = string.Format("UPLOADS/{0}", file.FileName)
                Key = folderPath + "/" + fileName//Path.Combine(folderPath, filenName)
            };
            using (var ms = new MemoryStream(bytes))
            {
                request.InputStream = ms;
                await client.PutObjectAsync(request);
            }
        }
        public async Task<ResponseDto2> ListContentOfAFolder(string folderPath)
        {
            List<string> op = new();
            ListObjectsRequest request = new()
            {
                BucketName = _bucketName,
                Prefix = folderPath
            };
            ListObjectsResponse response = await client.ListObjectsAsync(request);
            if (response.S3Objects.Count == 0)
            {
                return new ResponseDto2
                {
                    Message = "No data found.",
                    Success = false,
                    Payload = null
                };
            }
            op = response.S3Objects.Select(x => x.Key).ToList();
            return new ResponseDto2
            {
                Message = "Contents of " + folderPath,
                Success = true,
                Payload = new
                {
                    Output = op,
                    Extras = response
                }
            };
        }
        public async void DeleteFile(string folderPath, string filename)
        {
            // delete test.txt file  
            //string filePath = "my-folder/sub-folder/test.txt";
            var deleteFileRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                //Key = filePath
                Key = Path.Combine(folderPath, filename)
            };
            DeleteObjectResponse fileDeleteResponse = await client.DeleteObjectAsync(deleteFileRequest);
        }
        public async void DeleteFolder(string folderPath)
        {
            // delete test.txt file  
            //string filePath = "my-folder/sub-folder/test.txt";
            var deleteFolderRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = folderPath
            };
            DeleteObjectResponse folderDeleteResponse = await client.DeleteObjectAsync(deleteFolderRequest);
        }
    }
}