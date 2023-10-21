using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCrawler.entity
{
    internal class PhoneInfo
    {
        public string PhoneNumber {  get; set; }
        public List<string>Urls { get; set; }
        public PhoneInfo()
        {
            PhoneNumber = string.Empty;
            Urls = new List<string>();
        }
    }
}
