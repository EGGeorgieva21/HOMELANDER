using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : Controller
    {
        private readonly ILogger<ResumeController> _logger;
        private readonly ResumeService resumeService;

        public ResumeController(ILogger<ResumeController> logger)
        {
            _logger = logger;
            resumeService = new ResumeService();
        }

        [Authorize]
        [HttpPost("AddResume")]
        public ActionResult AddResume(AddResume addResume)
        {
            Resume? resume = resumeService.CreateResume(addResume.Summary, addResume.UserId, addResume.TemplateId);

            if (resume != null)
            {
                return Ok(resume);
            }
            return BadRequest("Invalid resume information");
        }

        [Authorize]
        [HttpGet("GetAllByUserId")]
        public ActionResult GetAllByUserId(int userId)
        {
            List<Resume>? resumes = resumeService.GetAllByUserId(userId);

            if (resumes != null)
            {
                return Ok(resumes);
            }
            return BadRequest("Wrong userId or no resumes created");
        }

        [Authorize]
        [HttpPatch("EditResume")]
        public ActionResult EditResume(EditResume editResume)
        {
            Resume? resume = resumeService.EditResume(editResume.Id, editResume.Summary);

            if (resume != null)
            {
                return Ok(resume);
            }
            return BadRequest("Wrong input");
        }

        [Authorize]
        [HttpDelete("RemoveResume")]
        public ActionResult RemoveResume(int resumeId)
        {
            bool flag = resumeService.RemoveResume(resumeId);

            if (flag)
            {
                return Ok("Resume removed");
            }
            return BadRequest("Invalid id");
        }
    }
}
