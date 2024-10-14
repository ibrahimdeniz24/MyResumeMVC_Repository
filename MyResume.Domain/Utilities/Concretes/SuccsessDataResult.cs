using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Concretes
{
    public class SuccsessDataResult<T> : DataResult<T> where T : class
    {
        public SuccsessDataResult() : base(default, true) { }
        public SuccsessDataResult(string message) : base(default, true, message) { }
        public SuccsessDataResult(T data, string message) : base(data, true, message) { }
    }
}
