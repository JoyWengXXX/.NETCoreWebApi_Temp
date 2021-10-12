using Microsoft.Extensions.Options;
using DataAccessLayer.Dapper;
using DataAccessLayer.Dapper.Models;
using DataAccessLayer.Dapper.Interfaces.Enum;
using System.Collections.Generic;
using System.Linq;
using ProjectModels.Entities;
using ProjectModels.DTO;

namespace WebAPI_Core_Proj.DAL.UsingDapper
{
    public class TestDataAccess : BaseDataAccess<Test>
    {
        public TestDataAccess(IOptions<ProjectConfigDTO> _Config) : base(_Config){}

        public Test GetTestQuery(Test entityModel)
        {
            using (UnitOfWork<Test> UoWObj = new UnitOfWork<Test>(proj_Config.connectString))
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
