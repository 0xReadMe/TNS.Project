using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.APPLICATION.SERVICES.EQUIPMENT;

public class EquipmentService(IEquipmentRepository equipmentRepository) : IEquipmentService
{
    public readonly IEquipmentRepository _equipmentRepository = equipmentRepository;

    public async Task<Result> AddEquipment(Equipment equipment)
    {
        try
        {
            await _equipmentRepository.Add(equipment);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeleteEquipment(Guid id)
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

    public async Task<Result<List<Equipment>>> GetAllEquipments()
    {
        try
        {
            List<Equipment> sub = await _equipmentRepository.GetAllEquipment();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Equipment>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<Equipment>> GetByGuidEquipment(Guid id)
    {
        try
        {
            Equipment sub = await _equipmentRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<Equipment>($"Ошибка при получении абонента: {ex}");
        }
    }

    public async Task<Result<List<Equipment>>> TestAllEquipment()
    {
        try
        {
            var result = await _equipmentRepository.GetAllEquipment();

            foreach (var item in result) 
            {
                item.IsWorking = CheckRemoteEquipment();
            }

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<Equipment>>($"Ошибка при тестировании данных: {ex}");
        }
    }

    public async Task<Result<Equipment>> TestEquipment(Guid id)
    {
        try
        {
            var result = await _equipmentRepository.GetByGuid(id);
            result.IsWorking = CheckRemoteEquipment();

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<Equipment>($"Ошибка при тестировании данных: {ex}");
        }
    }

    public async Task<Result> UpdateEquipment(Equipment equipment, Guid id)
    {
        try
        {
            await _equipmentRepository.Update(equipment, id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при обновлении данных: {ex}");
        }
    }

    private static bool CheckRemoteEquipment()
    {
        if (!TryConnectToDevice(Random.Shared.Next(0, 255)) || !PerformHealthCheck(Random.Shared.Next(0, 255)))
        {
            return false;
        }
        return true;
    }

    // Код для подключения к удаленному устройству
    // Возвращает true, если подключение установлено, и false в противном случае
    // Вероятность успешного подключения зависит от случайного числа
    private static bool TryConnectToDevice(int randomValue) => randomValue >= 50;
    
    // Код для проверки работоспособности удаленного устройства
    // Возвращает true, если устройство работает исправно, и false в противном случае
    // Вероятность успешной проверки зависит от случайного числа
    private static bool PerformHealthCheck(int randomValue) => randomValue >= 75;
}