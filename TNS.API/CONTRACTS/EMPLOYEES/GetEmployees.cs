using TNS.CORE.VO;

namespace TNS.API.CONTRACTS.EMPLOYEES
{
    public record GetEmployees
        (
            Guid id,
                                              Guid positionId,
                                              string fullName,
                                              string? photoId,
                                              string login,
                                              string passwordHash
        );
}
