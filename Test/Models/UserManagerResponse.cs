using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public int ID { get; set; }
        public ComplaintModel model { get; set; }
    }
}
