using System.Collections.Generic;
using Model.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        List<PersonModel> All();
    }
}