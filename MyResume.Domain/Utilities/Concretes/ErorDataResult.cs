using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Concretes
{
    public class ErorDataResult <T>: DataResult<T> where T : class
    {
        //buradaki default T? 'dir null olabilir bir T null olmasını istemiyorsak direk T yazardık.default Tnin null olma durumunda çalışıyopr.
        public ErorDataResult() : base(default, false) { }
        public ErorDataResult(string message) : base(default, false, message) { }
        public ErorDataResult(T data, string message) : base(data, false, message) { }

    }
}
