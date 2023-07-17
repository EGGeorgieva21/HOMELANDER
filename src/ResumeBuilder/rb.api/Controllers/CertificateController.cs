using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.api.ViewModels.Certificate;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificateController : Controller
    {
        private readonly ILogger<CertificateController> _logger;
        private readonly CertificateService certificateService;

        public CertificateController(ILogger<CertificateController> logger)
        {
            _logger = logger;
            certificateService = new CertificateService();
        }

        [Authorize]
        [HttpPost("AddCertificate")]
        public ActionResult AddCertificate(AddCertificate addCertificate)
        {
            Certificate? certificate = certificateService.AddCertificate(addCertificate.Name, addCertificate.IssuedDate, addCertificate.ExpirationDate, addCertificate.UserId);

            if(certificate != null)
            {
                return Ok(certificate);
            }
            return BadRequest("Invalid certificate information");
        }

        [Authorize]
        [HttpDelete("RemoveCertificate")]
        public ActionResult RemoveCertificate(int certificateId)
        {
            bool flag = certificateService.RemoveCertificate(certificateId);

            if(flag)
            {
                return Ok("Certificate removed");
            }
            return BadRequest("Invalid id");
        }

        [Authorize]
        [HttpGet("GetAllByUserId")]
        public ActionResult GetAllByUserId(int userId)
        {
            List<Certificate>? certificates = certificateService.GetAllByUserId(userId);

            if(certificates != null)
            {
                return Ok(certificates);
            }
            return BadRequest("Wrong userId or no certificates added");
        }

        [Authorize]
        [HttpPatch("EditCertificate")]
        public ActionResult EditCertificate(EditCertificate editCertificate)
        {
            Certificate? certificate = certificateService.EditCertificate(editCertificate.Id, editCertificate.Name, editCertificate.IssuedDate, editCertificate.ExpirationDate);

            if(certificate != null)
            {
                return Ok(certificate);
            }
            return BadRequest("Wrong input");
        }
    }
}
