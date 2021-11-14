using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShillohHillsCollege.Core.Util
{
    public class Responses<T>: Responses
    {
        public T data { get; set; }
    }

    public class Responses
    {
        public int code { get; set; }
        public string description { get; set; }
    }
}
