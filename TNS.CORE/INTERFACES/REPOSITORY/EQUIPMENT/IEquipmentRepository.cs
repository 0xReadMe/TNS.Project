using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;

public interface IEquipmentRepository
{
    Task Add(Equipment equipment);
    Task Delete(Guid id);
    Task Update(Equipment equipment, Guid id);
    Task<Equipment> GetByGuid(Guid id);
    Task<List<Equipment>> GetAllEquipment();
}
