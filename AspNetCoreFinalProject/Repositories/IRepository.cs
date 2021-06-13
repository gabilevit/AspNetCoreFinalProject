using AspNetCoreFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFinalProject.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAnimals();
        IEnumerable<Category> GetCategories();
        IEnumerable<Comment> GetComments();
        IEnumerable<Animal> GetAnimalsViaCategory(int id);
        IEnumerable<Comment> GetCommentsViaAnimal(int id);
        IEnumerable<Animal> GetTop2AnimalsVieComments();
        Animal GetAnimal(int id);
        Category GetCategory(int id);
        void InsertAnimal(Animal animal);
        void InsertComment(Comment comment);
        void UpdateAnimal(int id, Animal animal);
        void DeleteAnimal(int id);
        
    }
}
