using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsRegister.Business.Models
{
    public class JWTSettings
    {
        public string? Secret { get; set; }
        public int HoursdToExpire { get; set; }
        public string? Emitter { get; set; }
        public string? Audience { get; set; }//ONDE este token será válido?
    }
}
