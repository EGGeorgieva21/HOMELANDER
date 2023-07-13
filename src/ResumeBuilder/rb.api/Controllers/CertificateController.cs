using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificateController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly CertificateService certificateService;

        public CertificateController(ILogger<UserController> logger)
        {
            _logger = logger;
            certificateService = new CertificateService();
        }

        [Authorize]
        [HttpPost("AddCertificate")]
        public ActionResult AddCertificate(AddCertificate addCertificate)
        {
            Certificate? certificate = certificateService.AddCertificate(addCertificate.Name, addCertificate.IssuedDate, addCertificate.ExpirationDate, addCertificate.UserId);

            if (certificate != null)
            {
                return Ok("Certificate added");
            }
            return BadRequest("Wrong input");
        }
    }
}
