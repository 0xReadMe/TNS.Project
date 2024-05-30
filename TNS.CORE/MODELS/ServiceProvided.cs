using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    internal class ServiceProvided
    {
        public Guid     Id   { get; }    //  id оказываемой услуги
        public string   Name { get; }    //  оказываемая услуга

        private ServiceProvided(Guid id,
                                string name) 
        {
            Id = id;
            Name = name;
        }

        public static Result<ServiceProvided> Create(Guid id,
                                                     string name)
        {
            ServiceProvided result = new ServiceProvided(id,
                                                         name);

            return Result.Success(result);
        }
    }
}
