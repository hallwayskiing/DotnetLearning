using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.entity
{
    public class LogInfo
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TableName { get; set; }
        public DateTime Time { get; set; }
    }
}
