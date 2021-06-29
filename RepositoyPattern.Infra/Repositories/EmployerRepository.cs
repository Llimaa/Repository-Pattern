using Dapper;
using RepositoyPattern.Domain.Entities;
using RepositoyPattern.Domain.Repositories;
using RepositoyPattern.Infra.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoyPattern.Infra.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly IDB _db;

        public EmployerRepository(IDB db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Employer>> GetAll()
        {
            var sql = "select * from employer";

            using (var dbCon = _db.GetConnection())
            {
                var employer = await dbCon.QueryAsync<Employer>(sql);
                return employer;
            }
        }
         

        public async Task<Employer> GetById(int id)
        {
            var sql = "select * from employer where id = @id";

            using (var dbCon = _db.GetConnection())
            {
                var employer = await dbCon.QueryAsync<Employer>(sql, new { id });
                return employer.FirstOrDefault();
            }
        }


        public void Add(Employer employer)
        {
            var sql = "	INSERT INTO [dbo].[Employer]          " +
                        "	           ([Id]					  " +
                        "	           ,[Name]					  " +
                        "	           ,[Email]					  " +
                        "	           ,[Document])				  " +
                        "	     VALUES							  " +
                        "	           (@Id						  " +
                        "	           ,@Name					  " +
                        "	           ,@Email 					  " +
                        "	           ,@Document)				  ";

            using (var dbCon = _db.GetConnection())
            {
                dbCon.ExecuteAsync(sql, new
                {
                    @Id = employer.Id,
                    Name = employer.Name,
                    Email = employer.Email,
                    Document = employer.Document
                });
            }
        }

        void IEmployerRepository.Update(Employer employer)
        {
            var sql = "update employer set" +
                "name=@Name" +
                "email=@Email" +
                "document=@Document" +
                "where id=@Id";

            using (var dbCon = _db.GetConnection())
            {
                dbCon.ExecuteAsync(sql, new
                {
                    Name = employer.Name,
                    Email = employer.Email,
                    Document = employer.Document
                });
            }
        }
    }
}
