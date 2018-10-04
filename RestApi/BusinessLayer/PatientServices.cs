using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Models.Unit_of_Work;

namespace RestApi.BusinessLayer
{
    /// <summary>
    /// Added By Gopal Ganeriwal 
    /// This is to bring seperate Business layer to call Repository functions
    /// </summary>
    public class PatientServices : IPatientServices
    {
        private readonly IUnitofWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public PatientServices(IUnitofWork unitOfWork) //IDatabaseContext dbContext  
        {
            _unitOfWork = unitOfWork;
            
        }

        public Patient GetEpisodeInfoByPatientId(int patientId)
        {
            var patient = _unitOfWork.PatientRepository.GetByID(patientId);
            if (patient != null)
            {
                return patient;
            }
            return null;
        }
    }
}