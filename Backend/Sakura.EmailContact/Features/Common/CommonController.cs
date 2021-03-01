using System;
using System.IO;
using System.Linq;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sakura.EmailContact.Features.Common.Dtos;
using System.Drawing;
using System.Collections.Generic;

namespace Sakura.EmailContact.Features.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController: ControllerBase
    {
        private readonly IAmazonS3 s3Client;

        public CommonController(IAmazonS3 s3Client)
        {
            this.s3Client = s3Client;
        }


        [HttpPost("images/upload"), DisableRequestSizeLimit]
        public ActionResult<List<ImageDataDto>> UploadImages()
        {
            var files = Request.Form.Files;
            if (files.Any(f => f.Length == 0))
            {
                return BadRequest();
            }

            List<ImageDataDto> images = new List<ImageDataDto>();
            foreach (var item in files)
            {
                var imageUploaded = UploadImageToAws(item);
                images.Add(imageUploaded);
            }

            var response = new
            {
                Data = images
            };

            return Ok(response);
        }


        private ImageDataDto UploadImageToAws(IFormFile file)
        {
            string fileType = Path.GetExtension(file.FileName.ToLower()).Replace(".", "");
            TransferUtility fileTransferUtility = new TransferUtility(s3Client);

            var fileStream = file.OpenReadStream();
            TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
            {
                BucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME"),
                Key = $"{Guid.NewGuid().ToString()}.{fileType}",
                InputStream = fileStream,
                AutoCloseStream = false,
                ContentType = $"image/{fileType}",
                CannedACL = S3CannedACL.PublicRead
            };

            fileTransferUtility.Upload(fileTransferUtilityRequest);
            Image image = Image.FromStream(fileStream);
            fileStream.Close();

            return new ImageDataDto
            {
                Src = $"https://{fileTransferUtilityRequest.BucketName}.s3.amazonaws.com/{fileTransferUtilityRequest.Key}",
                Type = fileType,
                Width = image.Width,
                Height = image.Height
            };
        }

    }
}
