using System;
using System.Collections.Generic;
using System.Text;

namespace PaycoreFinalProject.Base.Response
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) //default true
        {
        }

        public SuccessDataResult(T data, bool success) : base(data, success)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
    }
}
