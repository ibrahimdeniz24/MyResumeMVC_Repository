using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Interfaces
{
    //burada dönüşü class' yaptık çünkü DTo ve VM'lerde de kullanmak için.
    public interface IDataResult<T>:IResult where T : class
    {
        public T? Data { get;} //set edemediğimiz propetylere  construcker içinde veri atayabiliriz.
    }
}
