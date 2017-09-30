using System;
using System.Collections.Generic;
using Lupi.Data.Entities;

namespace Lupi.Repository
{
    public interface IBreedsRepository
    {
        void Add(Breed breed);
        bool DeleteById(Guid id);
        IEnumerable<Breed> GetAll();
        Breed GetByID(Guid id);
        bool Update(Guid id, Breed newBreed);
    }
}