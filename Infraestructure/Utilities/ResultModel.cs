using System;
using System.Collections.Generic;
using System.Linq;
using Infraestructure.Entities;
using HotChocolate.Types;

namespace Infraestructure.Utilities
{
	public class ResultModel<T>
	{
		public string state { get; set; }
		public string error { get; set; }
		public string message { get; set; }
		public PageInfo PagesInfo { get; set; }
		public IQueryable<T> custom { get; set; }
		public List<T> custom3 { get; set; }
		public T custom2 { get; set; }

		public ResultModel()
		{
			this.error = "false";
			this.message = "success";
			this.state = "200";
		}

		public ResultModel(Exception ex)
		{
			this.error = "true";
			this.message = GetInfoException(ex);
			this.state = "601";
		}

		private string GetInfoException(Exception ex)
		{
			if (ex.InnerException != null)
			{
				return $"{ex.Message} -> InnerException [ {GetInfoException(ex.InnerException)} ]";
			}
			return ex.Message;
		}
	}
}
