using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FreeGeoIPCore.AppCode;
using GetUserLocationMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace GetUserLocationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;

        public DefaultController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public string GetUserLocation()
        {
            LocationModel user = new LocationModel();

            string ip = GetRequestIP(_httpContextAccessor);
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                user = JsonConvert.DeserializeObject<LocationModel>(info);
            }
            catch (Exception)
            {
                user.Loc = null;
            }
            return user.Loc;
        }

        public static string GetRequestIP(IHttpContextAccessor httpContextAccessor, bool tryUseXForwardHeader = true)
        {
            string ip = null;

            if (tryUseXForwardHeader)
                ip = GetHeaderValueAs<string>(httpContextAccessor, "X-Forwarded-For").SplitCsv().FirstOrDefault();

            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (ip.IsNullOrWhitespace() && httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            if (ip.IsNullOrWhitespace())
                ip = GetHeaderValueAs<string>(httpContextAccessor, "REMOTE_ADDR");

            // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.

            if (ip.IsNullOrWhitespace())
                throw new Exception("Unable to determine caller's IP.");

            // Remove port if on IP address
            ip = ip.Substring(0, ip.IndexOf(":"));

            return ip;
        }

        public static T GetHeaderValueAs<T>(IHttpContextAccessor httpContextAccessor, string headerName)
        {
            StringValues values;

            if (httpContextAccessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!rawValues.IsNullOrWhitespace())
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }
    }
}