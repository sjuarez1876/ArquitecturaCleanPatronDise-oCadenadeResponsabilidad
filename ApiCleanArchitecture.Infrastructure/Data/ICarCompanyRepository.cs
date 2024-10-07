using ApiCleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCleanArchitecture.Infrastructure.Data
{
    public interface ICarCompanyRepository
    {
        Task<CarCompany> GetByIdAsync(int id);
        Task<List<CarCompany>> GetAllAsync();
        Task AddAsync(CarCompany carCompany);
        Task UpdateAsync(CarCompany carCompany);
        Task DeleteAsync(int id);
    }

    public class CarCompanyRepository : ICarCompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CarCompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CarCompany> GetByIdAsync(int id)
        {
            return await _context.CarCompany.FindAsync(id);
        }

        public async Task<List<CarCompany>> GetAllAsync()
        {
            return await _context.CarCompany.ToListAsync();
        }

        public async Task AddAsync(CarCompany carCompany)
        {
            try
            {
                _context.CarCompany.Add(carCompany);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            { 
            }    
           
        }

        public async Task UpdateAsync(CarCompany carCompany)
        {
            _context.CarCompany.Update(carCompany);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carCompany = await GetByIdAsync(id);
            if (carCompany != null)
            {
                _context.CarCompany.Remove(carCompany);
                await _context.SaveChangesAsync();
            }
        }
    }
}
