using System.Collections.Generic;
using System.Reflection;
using DataAccessLayer.Interfaces.Enum;

namespace DataAccessLayer.Models
{
    public class WhereContext
    {
        public string tableColumn { get; set; }
        public SQLContextEnum.WhereEnum equetion { get; set; }
    }

    public class OrderByContext
    {
        public string tableColumn { get; set; }
        public SQLContextEnum.OrderByEnum orderType { get; set; }
    }
}
