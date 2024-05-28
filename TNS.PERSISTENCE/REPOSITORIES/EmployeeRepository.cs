using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.CORE.INTERFACES.REPOSITORY;
using TNS.CORE.MODELS;
using TNS.CORE.VO;
using TNS.PERSISTENCE.ENTITIES;

namespace TNS.PERSISTENCE.REPOSITORIES
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TNSDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(TNSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(Employee employee)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity() 
            {
                Id = employee.Id,
                FullName = employee.FullName,
                PositionId = employee.PositionId,
                //TODO: остальные поля
            };

            await _context.Employee.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> employees = [];

            await foreach(var emp in _context.Employee.AsAsyncEnumerable()) 
            {
                employees.Add(_mapper.Map<Employee>(emp));
            }
            return employees;
        }

        public async Task<Employee> GetByPhone(PhoneNumber phone)
        {
            var employeeEntity = await _context.Employee
                .AsNoTracking()
                .FirstOrDefaultAsync(emp => emp.Login == phone) ?? throw new Exception();

            return _mapper.Map<Employee>(employeeEntity);
        }
    }
}
