using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopRu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Infrastructure.Utilities
{
    public static class BaseResponse
    {
        public static ResponseDto<T> CreateResponse<T>(string msg, ModelStateDictionary errs, T data)
        {
            var errors = new Dictionary<string, string>();
            if (errs != null)
            {
                foreach (var err in errs)
                {
                    var counter = 0;
                    var key = err.Key;
                    var errVals = err.Value;
                    foreach (var errMsg in errVals.Errors)
                    {
                        errors.Add($"{(counter + 1)} - {key}", errMsg.ErrorMessage);
                        counter++;
                    }
                }
            }

            var obj = new ResponseDto<T>()
            {
                Message = msg,
                Errs = errors,
                Data = data
            };
            return obj;
        }
    }
}
