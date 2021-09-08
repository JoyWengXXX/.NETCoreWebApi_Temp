﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebAPI_Core_Proj.DAL;
using WebAPI_Core_Proj.Models.Entities;
using WebAPI_Core_Proj.Models.ViewModels;

namespace WebAPI_Core_Proj.BLL
{
    public class TestService
    {
        private TestDataAccess _TestDAO;

        public TestService(IOptions<ConfigViewModel> _Config)
        {
            _TestDAO = new TestDataAccess(_Config);
        }

        public TestEntity QueryTestObject()
        {
            TestEntity returnObj = new TestEntity()
            {
                Data = "TData004",
                Id = "T004"
            };

            var result = _TestDAO.GetTestQuery(returnObj);

            return result;
        } 
    }
}
