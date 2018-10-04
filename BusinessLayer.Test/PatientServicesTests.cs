using NUnit.Framework;
using RestApi.BusinessLayer;
using RestApi.Models;
using RestApi.Models.Generic_Repository;
using RestApi.Models.Unit_of_Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHelper;
using Moq;

namespace BusinessLayer.Test
{
    public class PatientServicesTests
    {
        #region Variables
        private IPatientServices _patientService;
        private IUnitofWork _unitOfWork;
        private List<Patient> _patients;
        private PatientRepository _patientRepository;
        private PatientContext _dbpatientContext;
        #endregion

        [TestFixtureSetUp]
        public void Setup()
        {
            _patients = SetUpPatients();
        }

        #region Setup

        /// <summary>
        /// Re-initializes test.
        /// </summary>
        [SetUp]
        public void ReInitializeTest()
        {
            _patients = SetUpPatients();
            _dbpatientContext = new Mock<PatientContext>().Object;
            _patientRepository = SetUpPatientRepository();
            var unitOfWork = new Mock<IUnitofWork>();
            unitOfWork.SetupGet(s => s.PatientRepository).Returns(_patientRepository);
            _unitOfWork = unitOfWork.Object;
            _patientService = new PatientServices(_unitOfWork);

        }

        #region Private member methods

        /// <summary>
        /// Setup dummy repository
        /// </summary>
        /// <returns></returns>
        private PatientRepository SetUpPatientRepository()
        {
            // Initialise repository
            var mockRepo = new Mock<PatientRepository>(MockBehavior.Default, _dbpatientContext);

            // Setup mocking behavior
            

            mockRepo.Setup(p => p.GetByID(It.IsAny<int>()))
                .Returns(new Func<int, Patient>(
                             id => _patients.Find(p => p.PatientId.Equals(id))));

            

            // Return mock implementation object
            return mockRepo.Object;
        }

        #endregion
        private static List<Patient> SetUpPatients()
        {
            var patientId = new int();
            var patients = DataInitializer.GetAllPatients();
            foreach (Patient pat in patients)
                pat.PatientId = ++patientId;
            return patients;
        }

        /// <summary>
        /// Service should return Episode Details if correct Patient id is supplied
        /// </summary>
        [Test]
        public void GetEpisodeInfoByRightIdTest()
        {
            var patientEpisodeInfo = _patientService.GetEpisodeInfoByPatientId(2);
            if (patientEpisodeInfo != null)
            {

                AssertObjects.PropertyValuesAreEquals(patientEpisodeInfo,_patients.Find(a => a.FirstName.Contains("Millicent")));
            }
        }

        [Test]
        public void GetPatientByWrongIdTest()
        {
            var patient = _patientService.GetEpisodeInfoByPatientId(0);
            Assert.Null(patient);
        }

        /// <summary>
        /// Tears down each test data
        /// </summary>
        [TearDown]
        public void DisposeTest()
        {
            _patientService = null;
            _unitOfWork = null;
            _patientRepository = null;
            if (_dbpatientContext != null)
                _dbpatientContext.Dispose();
            _patients = null;
        }

        #endregion

        [TestFixtureTearDown]
        public void DisposeAllObjects()
        {
            _patients = null;
        }

    }
}
