using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.GoogleCaptcha
{
    public class GoogleCaptcahService
    {
        private readonly IOptions<GoogleCaptchaConfig> config;

        public GoogleCaptcahService(IOptions<GoogleCaptchaConfig> _config)
        {
            config = _config;
        }


        public GoogleCaptchaResponse ValidateCaptcah(string response) {

            using (var client = new WebClient()) {
            string secret = config.Value.SecretKey;
                string url = $"{config.Value.Url}secret={secret}&response={response}";
               // string url
                var result = client.DownloadString(url);
                try
                {
                    var data = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(result.ToString());
                    return data;
                }
                catch (Exception)
                {
                    return default(GoogleCaptchaResponse);
             
                }

            }

        }







        //public async Task<bool> Vefytoken(string token) {
        //    try
        //    {
        //        var url = $"https://www.google.com/recaptcha/api/siteverify?secret={config.CurrentValue.SecretKey}&response={token}";
        //        using (var client = new HttpClient()) {

        //            var httpResult = await client.GetAsync(url);
        //            if (httpResult.StatusCode != HttpStatusCode.OK) {
        //                return false;
        //            }
        //            var responsestring = await httpResult.Content.ReadAsStringAsync();
        //            var googleResult = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(responsestring);
        //            return googleResult.success && googleResult.score >= 0.5;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //        throw;
        //    }

        //}
    }
}
