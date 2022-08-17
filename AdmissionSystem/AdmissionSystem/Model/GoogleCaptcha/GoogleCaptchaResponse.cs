using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.GoogleCaptcha
{
    public class GoogleCaptchaResponse
    {
        [JsonProperty("success")]
        public bool success { get; set; }
       // public double score { get; set; }
        [JsonProperty("error-codes")]
        public List<string> Message { get; set; }
    }
}
