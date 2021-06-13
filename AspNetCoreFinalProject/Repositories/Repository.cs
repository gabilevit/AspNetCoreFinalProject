using AspNetCoreFinalProject.Data;
using AspNetCoreFinalProject.Models;
using AspNetCoreFinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFinalProject.Repositories
{
    public class Repository : IRepository
    {
        private PetSiteContext _petContext;

        public Repository(PetSiteContext petContext)
        {
            _petContext = petContext;
        }        

        public IEnumerable<Animal> GetAnimals()
        {
            return _petContext.Animals.ToList().AsEnumerable();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _petContext.Categories.ToList().AsEnumerable();
        }

        public IEnumerable<Comment> GetComments()
        {
            return _petContext.Comments.ToList().AsEnumerable();
        }

        public Animal GetAnimal(int id)
        {
            var animalInDb = _petContext.Animals.SingleOrDefault(a => a.Id == id);
            return animalInDb;
        }

        public Category GetCategory(int id)
        {
            var categoryInDb = _petContext.Categories.SingleOrDefault(c => c.Id == id);
            return categoryInDb;
        }

        public void InsertAnimal(Animal animal)
        {
             _petContext.Animals.Add(animal);
            _petContext.SaveChanges();
        }

        public void InsertComment(Comment comment)
        {
            _petContext.Comments.Add(comment);
            
            _petContext.SaveChanges();
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            var tmp = _petContext.Animals.First(a => a.Id == id);
            if (animal.Name != null) tmp.Name = animal.Name;
            if (animal.Age > 0) tmp.Age = animal.Age;
            if (animal.Description != null) tmp.Description = animal.Description;
            if (animal.CategoryId > 0) tmp.CategoryId = animal.CategoryId;
            _petContext.Animals.Update(tmp);
            _petContext.SaveChanges();
        }     

        public void DeleteAnimal(int id)
        {
            var animalInDb = _petContext.Animals.SingleOrDefault(a => a.Id == id);
            _petContext.Animals.Remove(animalInDb);
            _petContext.SaveChanges();
        }  
        
        public IEnumerable<Animal> GetAnimalsViaCategory(int id)
        {
            var animalsViaCategory = _petContext.Categories.Where(c => c.Id.Equals(id)).SelectMany(c => c.Animals).ToList().AsEnumerable();
            return animalsViaCategory;
        }

        public IEnumerable<Comment> GetCommentsViaAnimal(int id)
        {
            var commentsViaAnimal = _petContext.Animals.Where(a => a.Id.Equals(id)).SelectMany(c => c.Comments).ToList().AsEnumerable();
            return commentsViaAnimal;
        }

        public IEnumerable<Animal> GetTop2AnimalsVieComments()
        {
            var top2 = _petContext.Animals.OrderByDescending(a => a.Comments.Count()).Take(2).ToList().AsEnumerable();
            return top2;
        }
    }
}
