using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : Controller
    {
        private readonly ILogger<SkillController> _logger;
        private readonly SkillService skillService;

        public SkillController(ILogger<SkillController> logger)
        {
            _logger = logger;
            skillService = new SkillService();
        }

        [Authorize]
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            List<Skill>? skills = skillService.GetAll();

            if (!skills.IsNullOrEmpty())
            {
                return Ok(skills);
            }
            return BadRequest("No skills added");
        }
    }
}
