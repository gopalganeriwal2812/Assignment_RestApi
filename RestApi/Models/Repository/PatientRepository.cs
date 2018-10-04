using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using RestApi.Interfaces;

namespace RestApi.Models.Generic_Repository
{
    public class PatientRepository
    {
        #region Private member variables...
        internal IDatabaseContext patientContext;

        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public PatientRepository(IDatabaseContext context)
        {
            this.patientContext = context;
            
        }
        #endregion

        #region Public member methods...
            

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Patient GetByID(int patientId)
        {

            var patientsAndEpisodes =
                from p in patientContext.Patients
                join e in patientContext.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new { p, e };

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return first;
            }

            return null;
        }

        
        #endregion
    }
}