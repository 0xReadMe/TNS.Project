using CSharpFunctionalExtensions;
using TNS.CORE.INTERFACES.REPOSITORY.CRM;
using TNS.CORE.INTERFACES.REPOSITORY.EQUIPMENT;
using TNS.CORE.INTERFACES.REPOSITORY.SUBSCRIBER;
using TNS.CORE.INTERFACES.SERVICES.CRM;
using TNS.CORE.MODELS.CRM;
using TNS.CORE.MODELS.EQUIPMENT;

namespace TNS.APPLICATION.SERVICES.CRM;

public class CRMService(ICRMRepository crmRepository) : ICRMService
{
    public readonly ICRMRepository _crmRepository = crmRepository;

    public async Task<Result> AddCRM(CRM_request CRM)
    {
        try
        {
            await _crmRepository.Add(CRM);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при добавлении: {ex}");
        }
    }

    public async Task<Result> DeleteCRM(Guid id)
    {
        try
        {
            await _crmRepository.Delete(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при удалении: {ex}");
        }
    }

    public async Task<Result<List<CRM_request>>> GetAllCRM_Requests()
    {
        try
        {
            List<CRM_request> sub = await _crmRepository.GetAllCRM_Requests();
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<CRM_request>>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<Result<CRM_request>> GetByGuidCRM(Guid id)
    {
        try
        {
            CRM_request sub = await _crmRepository.GetByGuid(id);
            return Result.Success(sub);
        }
        catch (Exception ex)
        {
            return Result.Failure<CRM_request>($"Ошибка при получении данных: {ex}");
        }
    }

    public async Task<bool> TestCRMEquipment()
    {
        return CheckRemoteEquipment();
    }

    public async Task<Result> UpdateCRM(CRM_request CRM, Guid id)
    {
        try
        {
            await _crmRepository.Update(CRM, id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure($"Ошибка при обновлении данных: {ex}");
        }
    }

    private static bool CheckRemoteEquipment()
    {
        if (!TryConnectToDevice(Random.Shared.Next(0, 255)))
        {
            return false;
        }
        return true;
    }

    // Код для подключения к удаленному устройству
    // Возвращает true, если подключение установлено, и false в противном случае
    // Вероятность успешного подключения зависит от случайного числа
    private static bool TryConnectToDevice(int randomValue) => randomValue >= 50;

}
