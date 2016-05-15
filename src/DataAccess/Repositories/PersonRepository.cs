using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Model.Models;

namespace DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _context;

        public PersonRepository(DbContext context)
        {
            _context = context;
        }

        public List<PersonModel> All()
        {
            return _context.Set<PersonEntity>()
                .Select(x => new PersonModel
                {
                    PersonId = x.PersonId,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();
        } 
    }
}
