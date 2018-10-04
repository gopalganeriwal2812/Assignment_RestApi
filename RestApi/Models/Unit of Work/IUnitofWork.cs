using RestApi.Models.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Models.Unit_of_Work
{
    public interface IUnitofWork
    {
        PatientRepository PatientRepository { get; }
    }
}
