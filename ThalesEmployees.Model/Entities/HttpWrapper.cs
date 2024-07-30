using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Model.Entities
{
    public class HttpWrapper<T>
    {
        public string status { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}
