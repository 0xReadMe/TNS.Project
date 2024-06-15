using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.INTERFACES.SERVICES.EQUIPMENT;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.APPLICATION.SERVICES.EQUIPMENT;

public class BaseStationService(IBaseStationRepository equipmentRepository) : IBaseStationService
{
    public readonly IBaseStationRepository _equipmentRepository = equipmentRepository;

    public async Task<Result> AddBaseStation(BaseStation baseStation)
    {
        try
        {
            await _equipmentRepository.Add(baseStation);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeleteBaseStation(Guid id)
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

    public async Task<Result<List<BaseStation>>> GetAllBaseStations()
    {
        try
        {
            List<BaseStation> sub = await _equipmentRepository.GetAllBaseStations();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<BaseStation>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<BaseStation>> GetByGuidBaseStation(Guid id)
    {
        try
        {
            BaseStation sub = await _equipmentRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<BaseStation>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<List<BaseStation>>> TestAllBaseStation()
    {
        try
        {
            var result = await _equipmentRepository.GetAllBaseStations();

            foreach (var item in result)
            {
                item.IsWorking = CheckRemoteEquipment();
            }

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<BaseStation>>($"Ошибка при тестировании данных: {ex}");
        }
    }

    public async Task<Result<BaseStation>> TestBaseStation(Guid id)
    {
        try
        {
            var result = await _equipmentRepository.GetByGuid(id);
            result.IsWorking = CheckRemoteEquipment();

            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Failure<BaseStation>($"Ошибка при тестировании данных: {ex}");
        }
    }

    public async Task<Result> UpdateBaseStation(BaseStation baseStation, Guid id)
    {
        try
        {
            await _equipmentRepository.Update(baseStation, id);
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
