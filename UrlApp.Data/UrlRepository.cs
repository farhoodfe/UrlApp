using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlApp.Data.Contract;
using UrlApp.Data.Models;

namespace UrlApp.Data
{
    public class UrlRepository : IUrlRepository
    {
        public readonly UrlDbContext _urlDbContext;

        public UrlRepository(UrlDbContext urlDbContext)
        {
            _urlDbContext = urlDbContext;
        }
    
    
    public bool ExistsOriginalUrl(string url)
        {
            var Url =  _urlDbContext.Urls.FirstOrDefault(u => u.OriginalUrl == url);
            if (Url == null) 
                return false;
            else
                return true;
        }

        public void Save(Url longUrl)
        {
            _urlDbContext.Add(new Url
            {
                OriginalUrl = longUrl.OriginalUrl
            });
            _urlDbContext.SaveChanges();
        }

        public string GetUrlById(int id)
        {
            var result = _urlDbContext.Urls.FirstOrDefault(u => u.Id == id);
            return result.OriginalUrl;
        }

        public int GetIdByUrl(string orgUrl)
        {
           var url = _urlDbContext.Urls.FirstOrDefault(u => u.OriginalUrl == orgUrl);
            if (url == null)
                return -1;
            return url.Id;
        }

    }

}
