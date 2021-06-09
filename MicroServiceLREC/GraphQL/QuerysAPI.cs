using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructure.Entities;
using Infraestructure.Utilities;
using Domain.QuerysDomain;
using Domain.PocoClass;
using HotChocolate.Types;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroServiceLREC.GraphQL
{
    public class QuerysAPI
    {
        #region variables globales
        private readonly QuerysGeneral domainQuerys;
        #endregion

        #region constructor
        public QuerysAPI()
        {
            this.domainQuerys = new QuerysGeneral();
        }
        #endregion

        #region Querys
        [Authorize]
        public ResultModel<Owner> OwnerAPI(int id = 0, int page = 1, int items = 0)
        {
            ResultModel<Owner> result;
            result = domainQuerys.OwnerDomain(id, page, items);
            return result;
        }

        [Authorize]
        public ResultModel<Property> PropertyAPI(int id = 0, int page = 1, int items = 0)
        {
            ResultModel<Property> result;
            result = domainQuerys.PropertyDomain(id, page, items);
            return result;
        }

        [Authorize]
        public ResultModel<PropertyImage> PropertyImageAPI(int id = 0, int page = 1, int items = 0)
        {
            ResultModel<PropertyImage> result;
            result = domainQuerys.PropertyImageDomain(id, page, items);
            return result;
        }

        [Authorize]
        public ResultModel<PropertyTrace> PropertyTraceAPI(int id = 0, int page = 1, int items = 0)
        {
            ResultModel<PropertyTrace> result;
            result = domainQuerys.PropertyTraceDomain(id, page, items);
            return result;
        }

        [Authorize]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<Owner> OwnerInfo() => domainQuerys.GetOwnerDomain();

        //Obtener Token de autenticación
        public string Token(string appName)
        {
            appName = appName.ToUpper();
            IdentityModelEventSource.ShowPII = true;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appName.PadLeft(16, '*').Substring(0, 16)));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(appName, appName,
                new[] {
                    new Claim(JwtRegisteredClaimNames.UniqueName, appName + "_" + Guid.NewGuid().ToString())
                },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
            );
            string x = new JwtSecurityTokenHandler().WriteToken(token);
            return x;
        }
        #endregion
    }
}
