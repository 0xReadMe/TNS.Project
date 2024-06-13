using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.APPLICATION.SERVICES.EQUIPMENT;

public class BaseStationAddressService(IBaseStationAddressRepository equipmentRepository) : IBaseStationAddressService
{
    public readonly IBaseStationAddressRepository _equipmentRepository = equipmentRepository;

    public async Task<Result> AddBaseStationAddress(BaseStationAddress baseStationAddress)
    {
        try
        {
            await _equipmentRepository.Add(baseStationAddress);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeleteBaseStationAddress(Guid id)
    {
        try
        {
            await _equipmentRepository.Delete(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при удалении: {ex}");
        }
    }

    public async Task<Result<List<BaseStationAddress>>> GetAllBaseStationAddresses()
    {
        try
        {
            List<BaseStationAddress> sub = await _equipmentRepository.GetAllBaseStationAddresses();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<BaseStationAddress>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<BaseStationAddress>> GetByGuidBaseStationAddress(Guid id)
    {
        try
        {
            BaseStationAddress sub = await _equipmentRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<BaseStationAddress>($"Ошибка при получении абонента: {ex}");
        }
    }

    public async Task<Result> UpdateBaseStationAddress(BaseStationAddress baseStationAddress, Guid id)
    {
        try
        {
            await _equipmentRepository.Update(baseStationAddress, id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при обновлении данных: {ex}");
        }
    }
}
