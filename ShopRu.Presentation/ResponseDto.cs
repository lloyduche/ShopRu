using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Model
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public string Code { get; set; }
        public T Data { get; set; }
    }
}
