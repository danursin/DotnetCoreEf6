using System.Collections.Generic;
using DataAccess.Repositories.Interfaces;
using Domain.Services.Interfaces;
using Model.Models;

namespace Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<PersonModel> All()
        {
            return _personRepository.All();
        }
    }
}
