using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlApp.Service.Contracts
{
    public interface IUrlShortenerService
    {
        public string Encode(int num);
        public int Decode(String str);
    }
}
