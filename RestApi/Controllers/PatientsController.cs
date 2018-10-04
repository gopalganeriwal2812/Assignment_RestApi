using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestApi.BusinessLayer;
using RestApi.Interfaces;
using RestApi.Models;
/// <summary>
/// This Web API provide single endpoint to retrieve Patient details based on its Id.
/// </summary>
namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IPatientServices _patientServices;
        
        public PatientsController(IPatientServices patientServices) //, IDatabaseContext dbContext
        {
            
            _patientServices = patientServices;
            //_patientServices.DbContext = dbContext;
            
            
        }

        [HttpGet]
        public HttpResponseMessage Get(int patientId)
        {

            var patient = _patientServices.GetEpisodeInfoByPatientId(patientId);

            if (patient != null)
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("No Episodes found for this Patient Id - {0} ", patientId));
        }
    }
}