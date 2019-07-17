using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DbContexts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        BestDbContext _context;

        public DefaultController(BestDbContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetNominations")]
        public ActionResult<List<Nomination>> GetNominations()
        {
            List<Nomination> nominations = _context.Nominations.ToList();

            return nominations;
        }



        [HttpGet, Route("GetTeacherTypes")]
        public ActionResult<List<TeacherType>> GetTeacherTypes()
        {
            List<TeacherType> teacherTypes = _context.TeacherTypes.ToList();
            return teacherTypes;
        }

        [HttpGet, Route("GetAgeCategories")]
        public ActionResult<List<AgeCategory>> GetAgeCategories()
        {
            List<AgeCategory> ageCategories = _context.AgeCategories.ToList();
            return ageCategories;
        }

        [HttpGet, Route("GetCompetitions")]
        public ActionResult<List<Competition>> GetCompetitions()
        {
            List<Competition> competitions = _context.Competitions.OrderBy(o => o.Date).ToList();
            return competitions;
        }


        [HttpGet, Route("GetSubnominations/{nominationId}")]
        [Route("GetSubnominations")]
        public ActionResult<List<Subnomination>> GetSubnominations(int nominationId)
        {
            List<Subnomination> subnominations = _context.Subnominations.Where(d => d.NominationId == nominationId).ToList();

            return subnominations;
        }

        [HttpGet, Route("GetNominationAdditionalFields/{nominationId}")]
        [Route("GetNominationAdditionalFields")]
        public ActionResult<List<NominationAdditionalField>> GetNominationAdditionalFields(int nominationId)
        {
            List<NominationAdditionalField> nominationAdditionalFields = _context.NominationAdditionalFields.Where(d => d.NominationId == nominationId).ToList();

            return nominationAdditionalFields;
        }

        [HttpPost, Route("PostApplication")]
        public ActionResult PostApplication([FromBody]Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
            return Ok();
        }
    }
}
