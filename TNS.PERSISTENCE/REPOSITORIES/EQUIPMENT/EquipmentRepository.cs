using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.PERSISTENCE.REPOSITORIES.EQUIPMENT;

public class EquipmentRepository : IEquipmentRepository
{
    public Task Add(Equipment equipment)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Equipment>> GetAllEquipment()
    {
        throw new NotImplementedException();
    }

    public Task<Equipment> GetByGuid(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Equipment equipment, Guid id)
    {
        throw new NotImplementedException();
    }
}
