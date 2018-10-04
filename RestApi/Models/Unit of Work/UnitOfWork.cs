using RestApi.Interfaces;
using RestApi.Models.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RestApi.Models.Unit_of_Work
{
    /// <summary>
    /// Unit of Work class responsible for Repository instantiation
    /// </summary>
    public class UnitOfWork : IUnitofWork
    {

        private readonly IDatabaseContext _context = null;
        private PatientRepository _PatientRepository;

        public UnitOfWork(Interfaces.IDatabaseContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Get/Set Property for patient repository.
        /// </summary>
        public PatientRepository PatientRepository
        {
            get
            {
                if (this._PatientRepository == null)
                    this._PatientRepository = new PatientRepository(_context);
                return _PatientRepository;
            }
        }

        
    }
}