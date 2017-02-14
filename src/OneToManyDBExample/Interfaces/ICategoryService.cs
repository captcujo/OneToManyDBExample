using System.Collections.Generic;
using OneToManyDBExample.Models;

namespace OneToManyDBExample.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Catagory inCategory);
        void DeleteCategory(int id);
        Catagory GetCategory(int catId);
        Catagory getCategoryWithoutMoives(int catId);
        List<Catagory> ListCategories();
        void UpdateCategory(Catagory inCategory);
    }
}