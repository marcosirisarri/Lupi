﻿using Lupi.Data.DataAccess;
using Lupi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lupi.Repository
{
    public class BreedsRepository
    {
        public IEnumerable<Breed> GetAll()
        {
            using (var context = new LupiDbContext())
            {
                return context.Breeds.ToList();
            }
        }

        public Breed GetByID(Guid id)
        {
            using (var context = new LupiDbContext())
            {
                return context.Breeds.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Add(Breed breed)
        {
            using (var context = new LupiDbContext())
            {
                context.Breeds.Add(breed);
                context.SaveChanges();
            }
        }

        public bool DeleteById(Guid id)
        {
            using (var context = new LupiDbContext())
            {
                Breed breed = context.Breeds.FirstOrDefault(p => p.Id == id);
                if (breed == null)
                {
                    return false;
                }
                context.Breeds.Remove(breed);
                context.SaveChanges();
                return true;
            }
        }

        public bool Update(Guid id, Breed newBreed)
        {
            using (var context = new LupiDbContext())
            {
                Breed originalBreed = context.Breeds.FirstOrDefault(p => p.Id == id);
                if (originalBreed == null)
                {
                    return false;
                }
                originalBreed.HairColors = newBreed.HairColors;
                originalBreed.HairType = newBreed.HairType;
                originalBreed.Name = newBreed.Name;
                context.SaveChanges();
                return true;
            }
        }
    }
}
