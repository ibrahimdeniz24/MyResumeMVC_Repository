using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Concretes
{
    public class SuccsesResult : Result
    {
        public SuccsesResult() : base(true) { }
        public SuccsesResult(string message) : base(true,message) { }

    }
}
