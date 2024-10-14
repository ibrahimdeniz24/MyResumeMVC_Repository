
using MyResume.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume.Domain.Utilities.Concretes
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public Result()
        {
            IsSuccess = false;
            Message = string.Empty;
        }

        public Result(bool isSuccses)
        {
            IsSuccess = isSuccses;
        }

        //this mevcu sınıfı temsil ediyor. parametre verdiğimzi için bir önceki constucketıtı temsil ediyor. Bu şekilde set olmayana veri atamış oluyoruz.
        public Result(bool isSuccses, string message) : this(isSuccses)
        {
            Message = message;
        }

    }
}