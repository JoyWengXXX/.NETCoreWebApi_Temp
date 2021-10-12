using DataAccessLayer.Dapper.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using ProjectModels.DTO;

namespace WebAPI_Core_Proj.DAL.UsingDapper
{
    public class BaseDataAccess<T> where T : class
    {
        protected List<WhereContext> where;
        protected OrderByContext order;
        protected ProjectConfigDTO proj_Config;

        public BaseDataAccess(IOptions<ProjectConfigDTO> _Config)
        {
            //專案參數
            proj_Config = new ProjectConfigDTO();
            proj_Config = _Config.Value;
        }

        protected string GetPropertyName(Expression<Func<T, object>> property)
        {
            MemberExpression body = (MemberExpression)property.Body;
            return body.Member.Name;
        }
    }
}
