using Microsoft.AspNetCore.Mvc;
using PersonalGoalsAPI.Helpers;
using PersonalGoalsAPI.Models;
using PersonalGoalsAPI.Services;

namespace PersonalGoalsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MandrilController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult <IEnumerable<Mandril>> GetMandriles()
        {
            return Ok(MandrilDataStore.Current.Mandriles);
        }
        [HttpGet ("{mandrilId}")]
        public ActionResult <Mandril> GetMandriles(int mandrilId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

            if (mandril == null)
            {
                return NotFound(Messages.Mandril.NotFound);
            }
            return Ok(mandril);
        }
        [HttpPost]
        public ActionResult<Mandril> PostMandril(MandrilInsert mandrilInsert)
        {
            var maxMandrilId = MandrilDataStore.Current.Mandriles.Max(x => x.Id);

            var mandrilNuevo = new Mandril()
            {
                Id = maxMandrilId + 1,
                Name = mandrilInsert.Name,
                LastName = mandrilInsert.LastName
            };
            MandrilDataStore.Current.Mandriles.Add(mandrilNuevo);

            return CreatedAtAction(nameof(GetMandriles),
                new {mandrilId = mandrilNuevo.Id},
                mandrilNuevo
                );
        }
        [HttpPut ("{mandrilId}")]
        public ActionResult<Mandril> PutMandril(int mandrilId,MandrilInsert mandrilInsert)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

            if (mandril == null)
            {
                return NotFound(Messages.Mandril.NotFound);
            }
            mandril.Name = mandrilInsert.Name;
            mandril.LastName = mandrilInsert.LastName;
            return NoContent();
        }
        [HttpDelete ("{mandrilId}")]
        public ActionResult<Mandril> DeleteMandril(int mandrilId)
        {
            var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
            if (mandril == null)
            {
                return NotFound(Messages.Mandril.NotFound);
            }
            MandrilDataStore.Current.Mandriles.Remove(mandril);
            return NoContent();
        }
    }
}
