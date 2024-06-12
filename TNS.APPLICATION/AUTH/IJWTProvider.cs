using TNS.CORE.MODELS.EMPLOYEE;

namespace TNS.APPLICATION.Auth
{
    public interface IJWTProvider
    {
        string Generate(Employee employee);
    }
}
