using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlApp.Service.Contracts;
using UrlApp.Data.Contract;
using UrlApp.Data.Models;
using UrlApp.Service.Dtos;


namespace UrlApp.Service.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IUrlShortenerService _urlShortenerService;
       

        public UrlService(IUrlRepository urlRepository, IUrlShortenerService urlShortenerService)
        {
            _urlRepository = urlRepository;
            _urlShortenerService = urlShortenerService;
            
        }

        //returns shortenedUrl
        public string SaveOriginalUrl(string strUrl)
        {
            if (_urlRepository.ExistsOriginalUrl(strUrl))
            {
                return "-1";
            }
            else
            {
                _urlRepository.Save(new Url
                {
                    OriginalUrl = strUrl,
                });
                int id = _urlRepository.GetIdByUrl(strUrl);
                return _urlShortenerService.Encode(id);
            }
                
        }
        public string GetLongUrl(string ShortUrl)
        {
            int id = _urlShortenerService.Decode(ShortUrl);
            string longUrl = _urlRepository.GetUrlById(id);
            return longUrl;
        }

        public string GetShortUrl(string OriginalUrl)
        {
            int id =_urlRepository.GetIdByUrl(OriginalUrl);
            if (id == -1)
                return null;
            return _urlShortenerService.Encode(id);

        }
      
    }
}
