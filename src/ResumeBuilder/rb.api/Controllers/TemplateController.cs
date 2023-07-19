using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : Controller
    {
        private readonly ILogger<TemplateController> _logger;
        private readonly TemplateService templateService;

        public TemplateController(ILogger<TemplateController> logger)
        {
            _logger = logger;
            templateService = new TemplateService();
        }

        [Authorize]
        [HttpPost("AddTemplate")]
        public ActionResult AddTemplate(int userId)
        {
            bool flag = templateService.AddTemplate(userId);

            if (flag)
            {
                return Ok("Template created");
            }
            return BadRequest("Invalid template information");
        }

        [Authorize]
        [HttpDelete("RemoveTemplate")]
        public ActionResult RemoveTemplate(int certificateId)
        {
            bool flag = templateService.RemoveTemplate(certificateId);

            if (flag)
            {
                return Ok("Template removed");
            }
            return BadRequest("Invalid id");
        }

        [Authorize]
        [HttpGet("GetAllTemplates")]
        public ActionResult GetAllTemplates()
        {
            List<Template>? templates = templateService.GetAllTemplates();

            if (templates != null)
            {
                return Ok(templates);
            }
            return BadRequest("No templates added");
        }
    }
}
