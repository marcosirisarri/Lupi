using System;
using System.Collections.Generic;
using Lupi.Data.Entities;

namespace Lupi.BusinessLogic
{
    public interface IBreedsBusinessLogic
    {
        Guid Add(Breed breed);
        bool Delete(Guid id);
        IEnumerable<Breed> GetAllBreeds();
        Breed GetByID(Guid id);
        bool Update(Guid id, Breed newBreed);
    }
}