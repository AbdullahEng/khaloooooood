using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdmissionSystem.Model.GoogleCaptcha
{
    public class GoogleCaptchaConfig
    {
        public string SiteKey { get; set; }
        public string SecretKey { get; set; }
        public string Url { get; set; }

        // When true (and SecretKey is set), the login form's reCAPTCHA answer is verified on the server.
        public bool Enabled { get; set; }
    }
}
