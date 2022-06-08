using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using ICABAPI.DTOs;
using Microsoft.AspNetCore.Http;

namespace ICABAPI.Data
{
    public class AwsS3CompatibleStorageRepository
    {
        public readonly string _accessKey;
        public readonly string _secretKey;
        public readonly string _bucketName;
        public readonly AmazonS3Config _amazonS3Config = new();
        public readonly IAmazonS3 _amazonS3Client;
        public readonly ResponseDto2 _responseDto2 = new();
        public AwsS3CompatibleStorageRepository()
        {
            _accessKey = "D4BUQMX6AC4Z9RKU720O";
            _secretKey = "KzL7OuZCFkduzbKB0LPslmhK93uaIzQOjgjDOt84";
            _amazonS3Config.ServiceURL = "https://s3.brilliant.com.bd";
            _amazonS3Client = new AmazonS3Client(_accessKey, _secretKey, _amazonS3Config);
            _bucketName = "icab-exam-dev";
        }
        public async Task<ResponseDto2> CreateAFolderAsync(string folderPath)
        {
            try
            {
                PutObjectRequest putObjectRequest = new()
                {
                    BucketName = _bucketName,
                    Key = folderPath + "/"
                };

                PutObjectResponse putObjectResponse = await _amazonS3Client.PutObjectAsync(putObjectRequest);
                return new ResponseDto2
                {
                    Message = "The folder " + folderPath + " is successfully created",
                    Success = true,
                    Payload = new
                    {
                        Output = _amazonS3Config.ServiceURL + "/" + _bucketName + "/" + folderPath + "/",
                        Extras = putObjectResponse
                    }
                };
            }
            catch (Exception ex)
            {
                _responseDto2.Message = "Folder creation failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto2;
            }
        }
        public async Task<ResponseDto2> UploadBytesInAFolderAsync(string folderPath, string fileName, byte[] bytes)
        {
            try
            {
                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    CannedACL = S3CannedACL.PublicRead,
                    Key = folderPath + "/" + fileName
                };
                PutObjectResponse putObjectResponse = new();
                using (var memoryStream = new MemoryStream(bytes))
                {
                    putObjectRequest.InputStream = memoryStream;
                    putObjectResponse = await _amazonS3Client.PutObjectAsync(putObjectRequest);
                }
                return new ResponseDto2
                {
                    Message = "The file " + fileName + " is successfully copied to folder " + folderPath,
                    Success = true,
                    Payload = new
                    {
                        Output = _amazonS3Config.ServiceURL + "/" + _bucketName + "/" + folderPath + "/" + fileName,
                        Extras = putObjectResponse
                    }
                };
            }
            catch (AmazonS3Exception aex)
            {
                _responseDto2.Message = "Byte upload failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    aex.AmazonCloudFrontId,
                    aex.AmazonId2,
                    aex.Data,
                    aex.ErrorCode,
                    aex.ErrorType,
                    aex.HelpLink,
                    aex.HResult,
                    aex.InnerException,
                    aex.Message,
                    aex.RequestId,
                    aex.ResponseBody,
                    aex.Retryable,
                    aex.Source,
                    aex.StackTrace,
                    aex.StatusCode,
                    aex.TargetSite
                };
                return _responseDto2;
            }
            catch (Exception ex)
            {
                _responseDto2.Message = "Byte upload failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto2;
            }
        }
        public async Task<ResponseDto2> UploadFileInAFolderAsync(string folderPath, string fileName, IFormFile formFile)
        {
            try
            {
                var putObjectRequest = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    CannedACL = S3CannedACL.PublicRead,
                    Key = folderPath + "/" + fileName
                };
                PutObjectResponse putObjectResponse = new();
                using (var memoryStream = new MemoryStream())
                {
                    await formFile.CopyToAsync(memoryStream);
                    putObjectRequest.InputStream = memoryStream;
                    putObjectResponse = await _amazonS3Client.PutObjectAsync(putObjectRequest);
                }
                return new ResponseDto2
                {
                    Message = "The file " + fileName + " is successfully copied to folder " + folderPath,
                    Success = true,
                    Payload = new
                    {
                        Output = _amazonS3Config.ServiceURL + _bucketName + "/" + folderPath + "/" + fileName,
                        Extras = putObjectResponse
                    }
                };
            }
            catch (Exception ex)
            {
                _responseDto2.Message = "File upload failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto2;
            }
        }
        public async Task<ResponseDto2> ListContentsOfAFolderAsync(string folderPath)
        {
            try
            {
                ListObjectsRequest listObjectsRequest = new()
                {
                    BucketName = _bucketName,
                    Prefix = folderPath + "/"
                };
                ListObjectsResponse listObjectsResponse = await _amazonS3Client.ListObjectsAsync(listObjectsRequest);
                if (listObjectsResponse.S3Objects.Count == 0)
                {
                    return new ResponseDto2
                    {
                        Message = "No data found.",
                        Success = false,
                        Payload = new
                        {
                            Extras = listObjectsResponse
                        }
                    };
                }
                return new ResponseDto2
                {
                    Message = "Contents of folder " + folderPath,
                    Success = true,
                    Payload = new
                    {
                        Output = listObjectsResponse.S3Objects.Select(x => _amazonS3Config.ServiceURL + "/" + _bucketName + "/" + x.Key).ToList(),
                        Extras = listObjectsResponse
                    }
                };
            }
            catch (Exception ex)
            {
                _responseDto2.Message = "Folder content listing failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto2;
            }
        }
        public async Task<ResponseDto2> DeleteFileAsync(string folderPath, string fileName)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = _bucketName,
                    Key = folderPath + "/" + fileName
                };
                DeleteObjectResponse deleteObjectResponse = await _amazonS3Client.DeleteObjectAsync(deleteObjectRequest);
                return new ResponseDto2
                {
                    Message = "The file " + fileName + " in folder " + folderPath + " is successfully deleted",
                    Success = true,
                    Payload = new
                    {
                        Extras = deleteObjectResponse
                    }
                };
            }
            catch (Exception ex)
            {
                _responseDto2.Message = "Delete file failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto2;
            }
        }
        public async Task<ResponseDto2> DeleteFolderAsync(string folderPath)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = _bucketName,
                    Key = folderPath + "/"
                };
                DeleteObjectResponse deleteObjectResponse = await _amazonS3Client.DeleteObjectAsync(deleteObjectRequest);
                return new ResponseDto2
                {
                    Message = "The folder " + folderPath + " is successfully deleted",
                    Success = true,
                    Payload = new
                    {
                        Extras = deleteObjectResponse
                    }
                };
            }
            catch (Exception ex)
            {
                _responseDto2.Message = "Folder creation failed. Something went wrong. Please try again later";
                _responseDto2.Success = false;
                _responseDto2.Payload = new
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException,
                    ex.Source,
                    ex.Data
                };
                return _responseDto2;
            }
        }
    }
}