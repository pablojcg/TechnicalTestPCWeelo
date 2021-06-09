using System;
using System.Collections.Generic;
using System.Text;
using Infraestructure;
using Infraestructure.Utilities;
using Infraestructure.Entities;
using System.Linq;
using Domain.PocoClass;

namespace Domain.QuerysDomain
{
    public class QuerysGeneral
    {
        #region variables globales
        private readonly DataBaseContext dbContext;
        #endregion

        #region constructor
        public QuerysGeneral()
        {
            this.dbContext = new DataBaseContext();
        }
		#endregion

		#region Querys
		//Consultar Propietarios en total o por ID
		public ResultModel<Owner> OwnerDomain(int id = 0, int page = 1, int items = 0)
		{
			ResultModel<Owner> result = new ResultModel<Owner>();

			try
			{
				if (id < 0) throw new Exception("El identificador debe ser positivo");

				PageInfo pageInfo = null;
				result.custom = (id <= 0 ? dbContext.Owners : dbContext.Owners.Where(x => x.IdOwner == id))
					.OrderBy(x => x.IdOwner)
					.Pagination(page, items, ref pageInfo);
				result.PagesInfo = pageInfo;
			}
			catch (Exception ex)
			{
				result = new ResultModel<Owner>(ex);
			}

			return result;
		}

		//Consultar Propiedades en total o por ID
		public ResultModel<Property> PropertyDomain(int id = 0, int page = 1, int items = 0)
		{
			ResultModel<Property> result = new ResultModel<Property>();

			try
			{
				if (id < 0) throw new Exception("El identificador debe ser positivo");

				PageInfo pageInfo = null;
				result.custom = (id <= 0 ? dbContext.Propertys : dbContext.Propertys.Where(x => x.IdProperty == id))
					.OrderBy(x => x.IdProperty)
					.Pagination(page, items, ref pageInfo);
				result.PagesInfo = pageInfo;
			}
			catch (Exception ex)
			{
				result = new ResultModel<Property>(ex);
			}

			return result;
		}

		//Consultar Imagenes de Propiedades en total o por ID
		public ResultModel<PropertyImage> PropertyImageDomain(int id = 0, int page = 1, int items = 0)
		{
			ResultModel<PropertyImage> result = new ResultModel<PropertyImage>();

			try
			{
				if (id < 0) throw new Exception("El identificador debe ser positivo");

				PageInfo pageInfo = null;
				result.custom = (id <= 0 ? dbContext.PropertyImages : dbContext.PropertyImages.Where(x => x.IdPropertyImage == id))
					.OrderBy(x => x.IdPropertyImage)
					.Pagination(page, items, ref pageInfo);
				result.PagesInfo = pageInfo;
			}
			catch (Exception ex)
			{
				result = new ResultModel<PropertyImage>(ex);
			}

			return result;
		}

		//Consultar Trazabilidad de Propiedades en total o por ID
		public ResultModel<PropertyTrace> PropertyTraceDomain(int id = 0, int page = 1, int items = 0)
		{
			ResultModel<PropertyTrace> result = new ResultModel<PropertyTrace>();

			try
			{
				if (id < 0) throw new Exception("El identificador debe ser positivo");

				PageInfo pageInfo = null;
				result.custom = (id <= 0 ? dbContext.PropertyTraces : dbContext.PropertyTraces.Where(x => x.IdPropertyTrace == id))
					.OrderBy(x => x.IdPropertyTrace)
					.Pagination(page, items, ref pageInfo);
				result.PagesInfo = pageInfo;
			}
			catch (Exception ex)
			{
				result = new ResultModel<PropertyTrace>(ex);
			}

			return result;
		}

		//Obtener toda la info con sus relaciones
		public IEnumerable<Owner> GetOwnerDomain() => dbContext.Owners;

		#endregion
	}
}
