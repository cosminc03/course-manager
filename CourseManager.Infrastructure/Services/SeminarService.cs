using CourseManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;

namespace CourseManager.Infrastructure.Services
{
    public class SeminarService : ISeminarService
    {
        private readonly ISeminarService _seminarRepository;
        public SeminarService(ISeminarService seminarRepository)
        {
            _seminarRepository = seminarRepository;
        }
        public void CreateSeminar(Seminar laboratory)
        {
            _seminarRepository.CreateSeminar(laboratory);
        }

        public void DeleteSeminar(Seminar laboratory)
        {
            _seminarRepository.DeleteSeminar(laboratory);
        }

        public IEnumerable<Seminar> GetAllSeminaries()
        {
            return _seminarRepository.GetAllSeminaries();
        }

        public IEnumerable<string> GetAllSeminariesNames()
        {
            return _seminarRepository.GetAllSeminariesNames();
        }

        public Seminar GetSeminarById(Guid guid)
        {
            return _seminarRepository.GetSeminarById(guid);
        }

        public void UpdateSeminar(Seminar laboratory)
        {
            _seminarRepository.UpdateSeminar(laboratory); 
        }
    }
}
