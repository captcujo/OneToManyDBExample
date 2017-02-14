using OneToManyDBExample.Interfaces;
using OneToManyDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToManyDBExample.Services
{
    public class CategoryService: ICategoryService
    {
        private IGenericRespository _repo;

        public CategoryService(IGenericRespository repo)
        {
            this._repo = repo;
        }

        public List<Catagory> ListCategories()
        {
            List<Catagory> categories = (from c in _repo.Query<Catagory>()
                                         select new Catagory
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            Movies = c.Movies
                                        }).ToList();
            return categories;
        }

        public Catagory GetCategory(int catId)
        {
            Catagory moviesByCategory = (from c in _repo.Query<Catagory>()
                                         where c.Id == catId
                                         select new Catagory
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            Movies = c.Movies
                                        }).FirstOrDefault();
            return moviesByCategory;
        }

        public void AddCategory(Catagory inCategory)
        {
            _repo.Add(inCategory);
        }

        public void UpdateCategory(Catagory inCategory)
        {
            _repo.Update(inCategory);
        }

        public void DeleteCategory(int id)
        {
            Catagory category = (from c in _repo.Query<Catagory>()
                                 where c.Id == id
                                 select c).FirstOrDefault();
            _repo.Delete(category);
        }

        public Catagory getCategoryWithoutMoives(int catId)
        {
            Catagory category = (from c in _repo.Query<Catagory>()
                                 where c.Id == catId
                                 select c).FirstOrDefault();
            return category;
        }
    }
}
