using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactserver.Domain.Models
{
    public class peoples
    {
        public long inn { get; set; }
        public Guid id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; }
        public DateTime birth_date { get; set; }
        public int spdul_code { get; set; }
        public string doc_ser_num { get; set; }
    }
}
