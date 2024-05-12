using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class ServiceType
    {
        public Guid     Id      { get; }
        public string   Name    { get; }

        private ServiceType(Guid    id,
                            string  name)
        {
            Id      = id;
            Name    = name;
        }
        public static Result<ServiceType> Create(Guid   id,
                                                 string name)
        {
            ServiceType result = new ServiceType(id,
                                                 name);

            return Result.Success(result);
        }
    }
}
