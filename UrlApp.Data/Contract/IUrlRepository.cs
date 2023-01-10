using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlApp.Data.Models;

namespace UrlApp.Data.Contract
{

    public interface IUrlRepository
    {
        bool ExistsOriginalUrl(string url);
        void Save(Url longUrl);

        string GetUrlById(int id);
        int GetIdByUrl(string orgUrl);
    }
}
