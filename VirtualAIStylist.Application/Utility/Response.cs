using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VirtualAIStylist.Application.Utility
{
	public class Response
	{
		public  HttpStatusCode StatusCode { get; set; }
		public  string Message { get; set; }
		public  object Data { get; set; }
		public  Dictionary<string,string> Errors { get; set; }
		
		public static async Task<Response> Success(object data, string message = null)
		{
			return new Response
			{
				StatusCode = HttpStatusCode.OK,
				Message = message,
				Data = data
			};
		}

		public static async Task<Response> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, Dictionary<string, string> errors = null)
		{
			return new Response
			{
				StatusCode = statusCode,
				Message = message,
				Errors = errors
			};
		}
	}
}
