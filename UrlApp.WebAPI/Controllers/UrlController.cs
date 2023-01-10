using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlApp.Service.Contracts;
using UrlApp.Service.Dtos;
using UrlApp.WebAPI.Models;
using AutoMapper;

namespace UrlApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IMapper _mapper;

        public UrlController(IUrlService urlService, IMapper mapper)
        {
            _urlService = urlService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public IActionResult NewUrl([FromQuery] string OriginalUrl)
        {

            string results =  _urlService.SaveOriginalUrl(OriginalUrl);
            if (results == "-1")
                return BadRequest("The Link already exists in Data Base");
            else
                return Ok(results);
            
        }

        //[HttpGet(Name ="GetOriginalUrl")]
        //public IActionResult Get(string shortUrl)
        //{
        //    //UrlModel result = new UrlModel();
        //    var response = _urlService.GetLongUrl(shortUrl);
        //    if (Response == null)
        //        return NotFound();
        //    return Ok(response);

        //}

        //[Route("[action]/{longUrl}")]

        [HttpGet(Name = "GetShortUrl")]
        public string GetShort(string longUrl)
        {
            var response = _urlService.GetShortUrl(longUrl);
            if (Response == null)
                return "NotFound";

            return response;
            //_mapper.Map<UrlModel>(result);

        }
    }

}
