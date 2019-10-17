using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class GenderRepository : IGenderRepository
    {
        private readonly WebStoreDbContext _context;

        public GenderRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(Gender item)
        {
            Gender newItem = new Gender()
            {
                Name = item.Name,
                IsDeleted = false
            };
            _context.Gender.Add(newItem);
            _context.SaveChanges();
        }

        public Gender GetById(int? id)
        {
            var gender = _context.Gender
                .Single(s => s.Id == id);
            return gender;
        }

        public void Update(Gender modifiedItem)
        {
            _context.Gender.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var gender = _context.Gender
                .Single(s => s.Id == id);
            gender.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Gender> GetByStr(string searchStr)
        {
            if(searchStr != null) { 
                return _context.Gender.Where(c => c.Name.Contains(searchStr)).ToList();
            }
            else { 
            return new List<Gender>();
            }
        }
        public IEnumerable<Gender> GetAllAvailable()
        {
            return _context.Gender.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<Gender> GetAll()
        {
            return _context.Gender.ToList();
        }
    }
}