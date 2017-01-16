using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Services.Interfaces
{
    public interface ISeminarService
    {

        IEnumerable<Seminar> GetAllSeminaries();
        IEnumerable<string> GetAllSeminariesNames();
        Seminar GetSeminarById(Guid guid);
        void CreateSeminar(Seminar laboratory);
        void UpdateSeminar(Seminar laboratory);
        void DeleteSeminar(Seminar laboratory);
    }
}
