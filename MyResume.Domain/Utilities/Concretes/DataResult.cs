
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Concretes
{
    public class DataResult<T> : Result, IDataResult<T> where T : class
    {
        public T? Data { get; }

        //base kalıtım algı yere gönderiyor.
        public DataResult(T data, bool isSuccsess) : base(isSuccsess)
        {
            Data = data;
        }

        public DataResult(T data, bool isSuccsess, string messsage) : base(isSuccsess, messsage)
        {
            Data = data;
        }

    }
}
