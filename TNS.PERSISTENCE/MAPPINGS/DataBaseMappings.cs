using AutoMapper;
using TNS.PERSISTENCE.ENTITIES.EQUIPMENT;
using TNS.PERSISTENCE.ENTITIES.EMPLOYEE;
using TNS.PERSISTENCE.ENTITIES.CRM;
using TNS.PERSISTENCE.ENTITIES.SUBSCRIBER;
using TNS.CORE.MODELS.EQUIPMENT;
using TNS.CORE.MODELS.CRM;
using TNS.CORE.MODELS.EMPLOYEE;
using TNS.CORE.MODELS.SUBSCRIBER;

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
