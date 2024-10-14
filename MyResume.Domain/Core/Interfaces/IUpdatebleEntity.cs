using MyResume.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProje1.Domain.Core.Interfaces
{
    //Güncellenecek şey ilk önce yaratıldıgından doalyı creatten kalıtım alıyor.
    public interface IUpdatebleEntity : ICreatableEntity
    {
        public string? UpdateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
