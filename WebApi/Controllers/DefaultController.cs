using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        readonly BestDbContext context;

        public DefaultController(BestDbContext context)
        {
            this.context = context;
        }

        [HttpGet, Route("GetNominations")]
        public ActionResult<List<Nomination>> GetNominations()
        {
            List<Nomination> nominations = context.Nominations.ToList();

            return nominations;
        }



        [HttpGet, Route("GetTeacherTypes")]
        public ActionResult<List<TeacherType>> GetTeacherTypes()
        {
            List<TeacherType> teacherTypes = context.TeacherTypes.ToList();
            return teacherTypes;
        }

        [HttpGet, Route("GetAgeCategories")]
        public ActionResult<List<AgeCategory>> GetAgeCategories()
        {
            List<AgeCategory> ageCategories = context.AgeCategories.ToList();
            return ageCategories;
        }

        [HttpGet, Route("GetCompetitions")]
        public ActionResult<List<Competition>> GetCompetitions()
        {
            List<Competition> competitions = context.Competitions.OrderBy(o => o.Date).ToList();
            return competitions;
        }


        [HttpGet, Route("GetSubnominations/{nominationId}")]
        [Route("GetSubnominations")]
        public ActionResult<List<Subnomination>> GetSubnominations(int nominationId)
        {
            List<Subnomination> subnominations = context.Subnominations.Where(d => d.NominationId == nominationId).ToList();

            return subnominations;
        }

        [HttpGet, Route("GetNominationAdditionalFields/{nominationId}")]
        [Route("GetNominationAdditionalFields")]
        public ActionResult<List<NominationAdditionalField>> GetNominationAdditionalFields(int nominationId)
        {
            List<NominationAdditionalField> nominationAdditionalFields = context.NominationAdditionalFields.Where(d => d.NominationId == nominationId).Include(p=>p.NominationAdditionalFieldValueOptions).ToList();

            return nominationAdditionalFields;
        }

        [HttpPost, Route("PostApplication")]
        public ActionResult PostApplication([FromBody]Application application)
        {
            context.Applications.Add(application);
            context.SaveChanges();
            return Ok();
        }
    }
}
