using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlApp.Service.Dtos;

namespace UrlApp.Service.Contracts
{
    public interface IUrlService
    {
        string GetLongUrl(string ShortUrl);

        string GetShortUrl(string OriginalUrl);
        string SaveOriginalUrl(string OriginalUrl);

    }
}
