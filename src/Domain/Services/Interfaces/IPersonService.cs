using System.Collections.Generic;
using Model.Models;

namespace Domain.Services.Interfaces
{
    public interface IPersonService
    {
        List<PersonModel> All();
    }
}