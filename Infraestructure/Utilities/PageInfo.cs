using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Utilities
{
	public class PageInfo
	{
		public PageInfo() { }

		public PageInfo(int page, int items, int total)
		{
			if (page < 0)
			{
				throw new Exception("La pagina debe ser mayor o igual a 1.");
			}
			if (items < 0)
			{
				throw new Exception("Los registros por pagina deben ser mayor o igual a 0.");
			}
			if (total < 0)
			{
				throw new Exception("El total de items debe ser mayor o igual a 0.");
			}
			this.currentPage = page;
			this.totalItems = total;
			this.totalPages = (int)Math.Ceiling(((decimal)total) / ((decimal)items));
			this.itemsPerPage = items;
			this.previusPage = page <= 1 ? -1 : page > totalPages ? totalPages - 1 : page - 1;
			this.nextPage = page >= totalPages ? -1 : page + 1;
			if (this.previusPage <= 0)
			{
				this.previusPage = null;
			}
			if (this.nextPage <= 0)
			{
				this.nextPage = null;
			}
			if (this.currentPage > this.totalPages)
			{
				throw new Exception("La pagina seleccionada supera la cantidad maxima de paginas ("+ this.totalPages.ToString() + ").");
			}
		}

		public int totalItems { get; set; }
		public int totalPages { get; set; }
		public int itemsPerPage { get; set; }
		public int? previusPage { get; set; }
		public int? nextPage { get; set; }
		public int currentPage { get; set; }
	}
}
