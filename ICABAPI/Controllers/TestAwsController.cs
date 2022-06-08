using Microsoft.AspNetCore.Mvc;
using ICABAPI.Data;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ICABAPI.Controllers
{
    public class InputForCreateFolder
    {
        public string FolderPath { get; set; }
    }
    public class InputForCreateFileFromBytes
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public byte[] Bytes { get; set; }
    }
    public class InputForCreateFileFromFile
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class InputForDeleteFile
    {
        public string FolderPath { get; set; }
        public string FileName { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TestAwsController : BaseApiController
    {
        private readonly AwsS3CompatibleStorageRepository _awsS3CompatibleStorageRepository;
        public TestAwsController()
        {
            _awsS3CompatibleStorageRepository = new AwsS3CompatibleStorageRepository();
        }

        [HttpPost("CreateFolder")]
        public async Task<ResponseDto2> CreateFolder([FromBody] InputForCreateFolder input)
        {
            return await _awsS3CompatibleStorageRepository.CreateAFolderAsync(input.FolderPath);
        }
        [HttpPost("CreateFile")]
        public async Task<ResponseDto2> CreateFile([FromBody] InputForCreateFileFromBytes input)
        {
            return await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync(input.FolderPath, input.FileName, input.Bytes);
        }
        [HttpPost("CreateFile2")]
        public async Task<ResponseDto2> CreateFile2([FromForm] InputForCreateFileFromFile input)
        {
            return await _awsS3CompatibleStorageRepository.UploadFileInAFolderAsync(input.FolderPath, input.FileName, input.FormFile);
        }
        [HttpPost("DeleteFolder")]
        public async Task<ResponseDto2> DeleteFolder([FromBody] InputForCreateFolder input)
        {
            return await _awsS3CompatibleStorageRepository.DeleteFolderAsync(input.FolderPath);
        }
        [HttpPost("DeleteFile")]
        public async Task<ResponseDto2> DeleteFile([FromBody] InputForDeleteFile input)
        {
            return await _awsS3CompatibleStorageRepository.DeleteFileAsync(input.FolderPath, input.FileName);
        }
        [HttpPost("ListContentsOfFolder")]
        public async Task<ResponseDto2> ListContentsOfFolder([FromBody] InputForCreateFolder input)
        {
            return await _awsS3CompatibleStorageRepository.ListContentsOfAFolderAsync(input.FolderPath);
        }
    }
}
