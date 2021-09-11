using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoJSCore.Models
{
    [Table("PLC")]
    public class PLCModel
    {
        public int ID { set; get; }
        public string JSON { set; get; }
}
}
