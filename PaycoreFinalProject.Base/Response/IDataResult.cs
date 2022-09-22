using System;
using System.Collections.Generic;
using System.Text;

namespace PaycoreFinalProject.Base.Response
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
