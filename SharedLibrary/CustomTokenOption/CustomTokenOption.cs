using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CustomTokenOption
{
    public class CustomTokenOption
    {
        public List<string> Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpriration { get; set; }
        public int RefreshTokenExpriration { get; set; }
        public string SecurityKey { get; set; }
    }
}
