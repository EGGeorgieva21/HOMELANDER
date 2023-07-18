using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSkillController : Controller
    {
        private readonly ILogger<UserSkillController> _logger;
        private readonly UserSkillService userSkillService;

        public UserSkillController(ILogger<UserSkillController> logger)
        {
            _logger = logger;
            userSkillService = new UserSkillService();
        }

        [Authorize]
        [HttpPost("AddUserSkill")]
        public ActionResult AddUserSkill(AddUserSkill addUserSkill)
        {
            UserSkill? userSkill = userSkillService.AddUserSkill(addUserSkill.UserId, addUserSkill.SkillId);

            if (userSkill != null)
            {
                return Ok(userSkill);
            }
            return BadRequest("Invalid user skill information");
        }

        [Authorize]
        [HttpGet("GetUserSkills")]
        public ActionResult GetUserSkills(int userId)
        {
            List<Skill>? skills = userSkillService.GetUserSkills(userId);

            if (skills != null)
            {
                return Ok(skills);
            }
            return BadRequest("Wrong userId or no skills added");
        }

        [Authorize]
        [HttpDelete("RemoveUserSkill")]
        public ActionResult RemoveUserSkill(int userSkillId)
        {
            bool flag = userSkillService.RemoveUserSkill(userSkillId);

            if (flag)
            {
                return Ok("User Skill removed");
            }
            return BadRequest("Invalid id");
        }
    }
}
