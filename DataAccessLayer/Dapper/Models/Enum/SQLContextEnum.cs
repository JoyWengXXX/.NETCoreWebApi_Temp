using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dapper.Interfaces.Enum
{
    public class SQLContextEnum
    {
        public enum WhereEnum
        {
            Equal,
            NotEqual
        }

        public enum OrderByEnum
        {
            ASC,
            DESC
        }
    }
}
