using TNS.CORE.MODELS;

namespace TNS.APPLICATION.Auth
{
    public interface IJWTProvider
    {
        string Generate(Employee employee);
    }
}
