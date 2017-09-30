﻿using Lupi.Data.Entities;
using Lupi.Repository;
using System;
using System.Collections.Generic;

namespace Lupi.BusinessLogic
{
    public class BreedsBusinessLogic : IBreedsBusinessLogic
    {
        public IBreedsRepository breedsRepository;

        public BreedsBusinessLogic(IBreedsRepository breedsRepository)
        {
            this.breedsRepository = breedsRepository;
        }

        public IEnumerable<Breed> GetAllBreeds()
        {
            return breedsRepository.GetAll();
        }

        public Breed GetByID(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return breedsRepository.GetByID(id);
        }

        public Guid Add(Breed breed)
        {
            if (breed == null)
            {
                throw new ArgumentNullException(nameof(breed));
            }
            Guid id = Guid.NewGuid();
            breed.Id = id;
            breedsRepository.Add(breed);
            return id;
        }

        public bool Delete(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return breedsRepository.DeleteById(id);
        }

        public bool Update(Guid id, Breed newBreed)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return breedsRepository.Update(id, newBreed);
        }
    }
}
