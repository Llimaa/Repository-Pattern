using RepositoyPattern.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoyPattern.Domain.Repositories
{
    public interface IEmployerRepository
    {
        Task<IEnumerable<Employer>> GetAll();
        Task<Employer> GetById(int id);
        void Add(Employer employer);
        void Update(Employer employer);


    }
}
