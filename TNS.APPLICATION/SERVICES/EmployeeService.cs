using TNS.APPLICATION.Auth;
using TNS.CORE.INTERFACES.REPOSITORY;
using TNS.CORE.INTERFACES.SERVICES;
using TNS.CORE.MODELS;
using TNS.CORE.VO;

namespace TNS.APPLICATION.SERVICES
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository    _employeeRepository;
        //private readonly IPasswordHasher        _passwordHasher;
        //private readonly IJWTProvider           _jwtProvider;

        public EmployeeService(
            IEmployeeRepository employeeRepository 
            //IPasswordHasher     passwordHasher, 
            //IJWTProvider        jwtProvider
            )
        {
            _employeeRepository = employeeRepository;
            //_passwordHasher     = passwordHasher;
            //_jwtProvider        = jwtProvider;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<string> Login(string phoneNumber, string password)
        {
            var phone = PhoneNumber.Create(phoneNumber);
            if (phone.IsSuccess)
            {
                Employee employee = await _employeeRepository.GetByPhone(phone.Value);
                //bool result = _passwordHasher.Verify(password, employee.PasswordHash);
                //if (result == false)
                //{
                //    throw new Exception("password does not match");
                //}
                //string token = _jwtProvider.Generate(employee);
                return "token";
            }
            else 
            {
                // TODO: проверить проброс исключения
                return phone.Error.ToString();
            }
        }
    }
}
