using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalcomaniaTour.Entities.Message;

namespace YalcomaniaTour.BusinessLayer.Result
{
    public class BusinessLayerResult<T> where T : class    
    {
        //Hata Mesajlarını saklayan bir list
        public List<ErrorMessageObj> Errors { get; set; }

        //sonuç başarılı ise sonucu bu property de veriyor olacağız.
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        //Kolay Error ekleyebilmek için
        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }
    }
}
