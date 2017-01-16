using CourseManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Services
{
    public class SeminarService : ISeminarService
    {
        private readonly ISeminarRepository _seminarRepository;
        public SeminarService(ISeminarRepository seminarRepository)
        {
            _seminarRepository = seminarRepository;
        }
        public void CreateSeminar(Seminar laboratory)
        {
            _seminarRepository.Create(laboratory);
        }

        public void DeleteSeminar(Seminar laboratory)
        {
            _seminarRepository.Delete(laboratory);
        }

        public IEnumerable<Seminar> GetAllSeminaries()
        {
            return _seminarRepository.FindAll();
        }

        /*
         * public IEnumerable<string> GetAllSeminariesNames()
        {
            return _seminarRepository
        }*/

        public Seminar GetSeminarById(Guid guid)
        {
            return _seminarRepository.FindById(guid);
        }

        public void UpdateSeminar(Seminar laboratory)
        {
            _seminarRepository.Update(laboratory); 
        }
    }
}
