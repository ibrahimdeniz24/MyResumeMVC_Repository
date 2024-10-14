
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Concretes
{
    public class ErorResult : Result
    {
        //bir yerde erorresult çağırırsak otomatik olarak ısScusses fasle oalrak gelecek.
        public ErorResult() : base(false) { }
        public ErorResult(string message): base(false,message) { }
        
    }
}
