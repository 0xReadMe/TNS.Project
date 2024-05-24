using AutoMapper;
using TNS.PERSISTENCE.ENTITIES;
using TNS.CORE.MODELS;

namespace TNS.PERSISTENCE.MAPPINGS
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings() 
        {
            CreateMap<EmployeeEntity, Employee>();
        }
    }
}
