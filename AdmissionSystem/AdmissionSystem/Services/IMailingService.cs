using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdmissionSystem.Services
{
    public interface IMailingService
    {
        Task SendEmailAsync(string mailTo, string subject, string body);
    }
}