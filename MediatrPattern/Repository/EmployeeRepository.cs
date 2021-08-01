using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatrPattern.Data;
using MediatrPattern.Entities;
using MediatrPattern.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MediatrPattern.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Employee> _dbSet;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Employee;
        }

        public async Task<Employee> Find(long id) => await _dbSet.FindAsync(id);

        public async Task<Employee> FindOrThrow(long id) 
            => await Find(id) ?? throw new Exception("Employee Not Found");

        public async Task<List<Employee>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<EntityEntry<Employee>> Create(Employee employee) => await _context.AddAsync(employee);

        public void Update(Employee employee) => _context.Update(employee);

        public async Task<int> Flush() => await _context.SaveChangesAsync();

        public void Remove(Employee employee) => _context.Employee.Remove(employee);
    }
}