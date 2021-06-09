using Infraestructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace System.Linq
{
	public static class Queryable
	{
		/// <summary>
		/// Pagination method
		/// </summary>
		/// <typeparam name="TSource">Datasource</typeparam>
		/// <param name="source">Datasource</param>
		/// <param name="page">selected page,min value 1</param>
		/// <param name="itemPerPage">selected page,min value 0 (0 for all data)</param>
		/// <returns>Pagination data</returns>
		public static IQueryable<TSource> Pagination<TSource>(this IQueryable<TSource> source, int page, int itemPerPage=20)
		{
			int start = (itemPerPage * (page - 1));
			int totalItems = source.Count();
			itemPerPage = itemPerPage <= 0 ? totalItems : itemPerPage;
			PageInfo pageInfo = new PageInfo(page, itemPerPage, totalItems);
			return source.Skip(start).Take(itemPerPage);
		}

		/// <summary>
		/// Pagination method
		/// </summary>
		/// <typeparam name="TSource">Datasource</typeparam>
		/// <param name="source">Datasource</param>
		/// <param name="page">selected page,min value 1</param>
		/// <param name="itemPerPage">selected page,min value 0 (0 for all data)</param>
		/// <param name="pageInfo">Pagination info</param>
		/// <returns>Pagination data</returns>
		public static IQueryable<TSource> Pagination<TSource>(this IQueryable<TSource> source, int page ,int itemPerPage,ref PageInfo pageInfo) {
			int start = (itemPerPage * (page - 1));
			int totalItems = source.Count();
			itemPerPage = itemPerPage <= 0 ? totalItems : itemPerPage;
			pageInfo = new PageInfo(page, itemPerPage, totalItems);
			return source.Skip(start).Take(itemPerPage);
		}
	}
}
