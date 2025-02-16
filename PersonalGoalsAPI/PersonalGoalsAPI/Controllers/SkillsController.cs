using Microsoft.AspNetCore.Mvc;
using PersonalGoalsAPI.Helpers;
using PersonalGoalsAPI.Models;
using PersonalGoalsAPI.Services;

namespace PersonalGoalsAPI.Controllers
{
    [ApiController]
    [Route("api/mandril/{mandrilId}/[controller]")]
    public class SkillsController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<Skills>> GetSkills(int mandrilId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

            if (mandril == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            return Ok(mandril.Skills);
        }
        [HttpGet("{skillId}")]
        public ActionResult<Skills> GetSkills(int mandrilId, int skillId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
            

            if (mandril == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            var skill = mandril.Skills?.FirstOrDefault(y => y.Id == skillId);
            if (skill == null)
            {
                return NotFound(Messages.Mandril.NotFound);
            }
            return Ok(skill);
        }
        [HttpPost]
        public ActionResult<Skills> PostSkills(int mandrilId, SkillInsert skillInsert)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);


            if (mandril == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            var existingSkill = mandril.Skills.FirstOrDefault(x => x.Name == skillInsert.Name);
            if (existingSkill != null)
            {
                return BadRequest(Messages.Skill.ExistingName);
            }
            var maxSkillId = mandril.Skills.Max(x => x.Id);
            var newSkill = new Skills()
            {
                Id = maxSkillId +1,
                Name = skillInsert.Name,
                Power = skillInsert.Power
            };
            mandril.Skills.Add(newSkill);
            return CreatedAtAction(nameof(GetSkills),
                new {mandrilId = mandrilId, skillId = newSkill.Id},
                newSkill
                );
        }
        [HttpPut("{SkillId}")]
        public ActionResult<Skills> PutSkills(int mandrilId,int SkillId, SkillInsert skillInsert)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

            if (mandril == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            var existingSkill = mandril.Skills?.FirstOrDefault(x => x.Id == SkillId);
            if(existingSkill == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            var existingSkillName = mandril.Skills?.FirstOrDefault(x => x.Id != SkillId && x.Name == skillInsert.Name);
            if (existingSkillName != null)
            {
                return BadRequest(Messages.Skill.ExistingName);
            }
            existingSkill.Name = skillInsert.Name;
            existingSkill.Power = existingSkill.Power;

            return NoContent();
        }
        [HttpDelete("{SkillId}")]
        public ActionResult<Skills> DeleteSkill(int mandrilId,int SkillId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
            var existingSkill = mandril.Skills?.FirstOrDefault(x => x.Id == SkillId);

            if (mandril == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            if (existingSkill == null)
            {
                return NotFound(Messages.Skill.NotFound);
            }
            mandril.Skills.Remove(existingSkill);
            return NoContent();
        }
    }
}
