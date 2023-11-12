using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using patientApi_01.Helper;
using patientApi_01.Interface;
using patientApi_01.Models;

namespace patientApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly PatientDbContext _db;
        private readonly IAllergyRepo _iAllergy;
        public AllergiesController(IAllergyRepo iAllergy, PatientDbContext db)
        {
            _db = db;
            _iAllergy = iAllergy;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var manuList = await _iAllergy.GetAll();
                return Ok(manuList);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Allergy>> GetById(int id)
        {
            try
            {
                var aller = await _iAllergy.GetById(id);
                if (aller == null)
                {
                    return NotFound();
                }
                return aller;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        [HttpPost("Insert")]
        public async Task<object> Insert([FromBody] Allergy obj)
        {
            try
            {
                if (obj == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Missing", null));
                }

                // Check if the AllergyName is empty or null
                if (string.IsNullOrWhiteSpace(obj.AllergyName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "AllergyName is required", null));
                }

                // Check if a Allergy with the same AllergyID already exists
                var manu = await _iAllergy.GetById(obj.AllergyID);
                if (manu != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Already Exists", manu));
                }

                // Check if a Allergy with the same name already exists
                var existingAllergy = await _iAllergy.GetByNameAsync(obj.AllergyName);
                if (existingAllergy != null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "AllergyName already exists", existingAllergy));
                }


                // Additional validation checks for AllergyName
                if (!IsValidAllergyName(obj.AllergyName))
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Invalid AllergyName format", null));
                }

                var returnManu = await _iAllergy.Insert(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data Inserted Successfully", returnManu));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private bool IsValidAllergyName(string AllergyName)
        {
            if (AllergyName.Length > 100 || AllergyName.Contains("!"))
            {
                return false;
            }

            return true;
        }
        [HttpPut("Update")]
        public async Task<object> Update([FromBody] Allergy obj)
        {
            try
            {
                var test = await _iAllergy.GetById(obj.AllergyID);
                if (test == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Data Object Missing", null));
                }
                var returnManu = await _iAllergy.Update(obj);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Data updated successfully", returnManu));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var allgDelete = await _iAllergy.GetById(id);
                if (allgDelete == null)
                {
                    return NotFound();
                }
                await _iAllergy.Delete(id);
                return Ok("Data Delete Successfully!!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from database");
            }
        }
        //public AllergiesController(PatientDbContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Allergy>>> GetAllergies()
        //{
        //    return await _context.Allergies.ToListAsync();
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Allergy>> GetAllergy(int id)
        //{
        //    var allergy = await _context.Allergies.FindAsync(id);

        //    if (allergy == null)
        //    {
        //        return NotFound();
        //    }

        //    return allergy;
        //}
        //[HttpPost]
        //public async Task<ActionResult<Allergy>> PostAllergy([FromForm]Allergy allergy)
        //{
        //    _context.Allergies.Add(allergy);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAllergy", new { id = allergy.AllergyID }, allergy);
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAllergy(int id, [FromForm] Allergy allergy)
        //{
        //    if (id != allergy.AllergyID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(allergy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AllergyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAllergy(int id)
        //{
        //    var allergy = await _context.Allergies.FindAsync(id);
        //    if (allergy == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Allergies.Remove(allergy);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AllergyExists(int id)
        //{
        //    return _context.Allergies.Any(e => e.AllergyID == id);
        //}
    }
}
