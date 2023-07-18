using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rb.api.ViewModels;
using rb.bll;
using rb.dal.Models;

namespace rb.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLanguageController : Controller
    {
        private readonly ILogger<UserLanguageController> _logger;
        private readonly UserLanguageService educationSkillService;

        public UserLanguageController(ILogger<UserLanguageController> logger)
        {
            _logger = logger;
            educationSkillService = new UserLanguageService();
        }

        [Authorize]
        [HttpPost("AddUserLanguage")]
        public ActionResult AddUserLanguage(AddUserLanguage addUserLanguage)
        {
            UserLanguage? userLanguage = educationSkillService.AddUserLanguage(addUserLanguage.UserId, addUserLanguage.LanguageId);

            if (userLanguage != null)
            {
                return Ok(userLanguage);
            }
            return BadRequest("Invalid user language information");
        }

        [Authorize]
        [HttpGet("GetUserLanguages")]
        public ActionResult GetUserLanguages(int userId)
        {
            List<Language>? languages = educationSkillService.GetUserLanguages(userId);

            if (languages != null)
            {
                return Ok(languages);
            }
            return BadRequest("Wrong userId or no languages added");
        }

        [Authorize]
        [HttpDelete("RemoveUserLanguage")]
        public ActionResult RemoveCertificate(int userLanguageId)
        {
            bool flag = educationSkillService.RemoveUserLanguage(userLanguageId);

            if (flag)
            {
                return Ok("User Language removed");
            }
            return BadRequest("Invalid id");
        }
    }
}
