using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAIStylist.Domain.Interfaces;

namespace VirtualAIStylist.Application.Services
{
	public class MediaService : IMediaService
	{
		private readonly IConfiguration _configuration;
		public MediaService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task DeleteAsync(string url)
		{
			var imageName = Path.GetFileNameWithoutExtension(url);
			var extention = Path.GetExtension(url);
			var imagePath = $"{_configuration["BaseUrl"]}images/{imageName}{extention}";
			if (File.Exists(imagePath))
			{
				File.Delete(imagePath);
			}

			await Task.CompletedTask;
		}

		public async Task<string> UploadImageAsync(IFormFile Image)
		{
			string extention = Path.GetExtension(Image.FileName);
			string imageName = $"{Guid.NewGuid().ToString()}{extention}";
			string directoryPath = Path.Combine("wwwroot","images");
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}

			string imagePath = (Path.Combine(directoryPath, imageName)).Replace('\\','/');
			using (var stream = new FileStream(imagePath, FileMode.Create))
			{
				Image.CopyTo(stream);
			}
			await Task.CompletedTask;
			return $"{_configuration["BaseUrl"]}{imagePath}";
		}

	}
}
