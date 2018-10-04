using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Added By Gopal Ganeriwal 
/// This is to bring seperate Business layer Interface
/// </summary>
namespace RestApi.BusinessLayer
{
    public interface IPatientServices
    {
        //IDatabaseContext DbContext { get; set; }
        Patient GetEpisodeInfoByPatientId(int patientId);
    }
}
