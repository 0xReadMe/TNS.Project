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
            CreateMap<BaseStationAddressEntity, BaseStationAddress>();
            CreateMap<BaseStationEntity, BaseStation>();
            CreateMap<CRM_requestEntity, CRM_request>();
            CreateMap<EmployeePositionEntity, EmployeePosition>();
            CreateMap<EquipmentEntity, Equipment>();
            CreateMap<EventEntity, Event>();
            CreateMap<PersonEntity, Person>();
            CreateMap<ServiceEntity, Service>();
            CreateMap<ServiceProvidedEntity, ServiceProvided>();
            CreateMap<ServiceTypeEntity, ServiceType>();
            CreateMap<SubscriberEntity, Subscriber>();
        }
    }
}
