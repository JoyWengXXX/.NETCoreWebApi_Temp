using DataAccessLayer.Dapper.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using ProjectModels.ViewModels;

namespace WebAPI_Core_Proj.DAL.UsingDapper
{
    public class BaseDataAccess<T> where T : class
    {
        protected List<WhereContext> where;
        protected OrderByContext order;
        protected ConfigViewModel proj_Config;

        public BaseDataAccess(IOptions<ConfigViewModel> _Config)
        {
            //專案參數
            proj_Config = new ConfigViewModel();
            proj_Config = _Config.Value;
        }

        protected string GetPropertyName(Expression<Func<T, object>> property)
        {
            MemberExpression body = (MemberExpression)property.Body;
            return body.Member.Name;
        }
    }
}
