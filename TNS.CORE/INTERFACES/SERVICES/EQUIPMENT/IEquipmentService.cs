using CSharpFunctionalExtensions;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;

public interface IEquipmentService
{
    Task<Result> AddEquipment(Equipment equipment);
    Task<Result> DeleteEquipment(Guid id);
    Task<Result> UpdateEquipment(Equipment equipment, Guid id);
    Task<Result<Equipment>> GetByGuidEquipment(Guid id);
    Task<Result<List<Equipment>>> GetAllEquipments();
    Task<Result<Equipment>> TestEquipment(Guid id);
    Task<Result<List<Equipment>>> TestAllEquipment();
}
