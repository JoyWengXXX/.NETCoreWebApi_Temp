using Microsoft.Extensions.Options;
using WebAPI_Core_Proj.Models.ViewModels;
using WebAPI_Core_Proj.Models.Entities;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces.Enum;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI_Core_Proj.DAL
{
    public class TestDataAccess : BaseDataAccess<TestEntity>
    {
        public TestDataAccess(IOptions<ConfigViewModel> _Config) : base(_Config){}

        public TestEntity GetTestQuery(TestEntity entityModel)
        {
            using (UnitOfWork<TestEntity> UoWObj = new UnitOfWork<TestEntity>(proj_Config.connectString))
            {
                where = new List<WhereContext>();
                where.Add(new WhereContext(){ tableColumn = GetPropertyName(x => x.Id), equetion = SQLContextEnum.WhereEnum.NotEqual });
                order = new OrderByContext() 
                {
                    tableColumn = GetPropertyName(x => x.Id),
                    orderType = SQLContextEnum.OrderByEnum.DESC
                };

               var result = UoWObj.GetGenericRepository.QueryAsync(entityModel).Result;

                UoWObj.Complete();
                UoWObj.Dispose();

                return result;
            }
        }
    }
}
