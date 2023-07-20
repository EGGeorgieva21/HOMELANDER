using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CertificateController : Controller
    {
        private readonly ILogger<CertificateController> _logger;
        private readonly CertificateService _certificateService;

        public CertificateController(ILogger<CertificateController> logger)
        {
            _logger = logger;
            this._certificateService = new CertificateService();
        }

        [Authorize]
        [HttpPost("AddCertificate")]
        public ActionResult AddCertificate(AddCertificate addCertificate)
        {
            Certificate? certificate = this._certificateService.AddCertificate(addCertificate.Name, addCertificate.IssuedDate, addCertificate.ExpirationDate, addCertificate.UserId);

            if(certificate != null)
            {
                return Ok(certificate);
            }
            return BadRequest("Invalid certificate information");
        }

        [Authorize]
        [HttpGet("GetAllByUserId/{userId}")]
        public ActionResult GetAllByUserId(int userId)
        {
            List<Certificate>? certificates = this._certificateService.GetAllByUserId(userId);

            if (certificates != null)
            {
                return Ok(certificates);
            }
            return BadRequest("Wrong userId or no certificates added");
        }

        [Authorize]
        [HttpPatch("EditCertificate")]
        public ActionResult EditCertificate(EditCertificate editCertificate)
        {
            Certificate? certificate = this._certificateService.EditCertificate(editCertificate.Id, editCertificate.Name, editCertificate.IssuedDate, editCertificate.ExpirationDate);

            if (certificate != null)
            {
                return Ok(certificate);
            }
            return BadRequest("Wrong input");
        }

        [Authorize]
        [HttpDelete("RemoveCertificate")]
        public ActionResult RemoveCertificate(int certificateId)
        {
            bool flag = this._certificateService.RemoveCertificate(certificateId);

            if(flag)
            {
                return Ok("Certificate removed");
            }
            return BadRequest("Invalid id");
        }
    }
}
