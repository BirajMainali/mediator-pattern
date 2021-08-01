using System.Collections.Generic;
using System.Threading.Tasks;
using MediatrPattern.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MediatrPattern.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> Find(long id);
        Task<Employee> FindOrThrow(long id);
        Task<List<Employee>> GetAllAsync();
        Task<EntityEntry<Employee>> Create(Employee employee);
        void Update(Employee employee);
        Task<int> Flush();
        public void Remove(Employee employee);
    }
}