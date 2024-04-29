using CSharpFunctionalExtensions;

namespace TNS.CORE.MODELS
{
    public class CRM_request
    {
        public Guid     Id                  { get; }     //  todo: генер. автомат: ЛС абонента|день|месяц|год
        public Guid     SubscriberId        { get; }     //  лицевой счет + номер абонента
        public DateOnly CreationDate        { get; }     //  дата создания
        public Guid     ServiceId           { get; }     //  услуга
        public Guid     ServiceProvidedId   { get; }     //  оказываемая услуга
        public Guid     ServiceTypeId       { get; }     //  тип услуги
        public string   Status              { get; }     //  статус услуги
        public string   TypeOfEquipment     { get; }     //  тип оборудования
        public string   TypeOfProblem       { get; }     //  тип проблемы
        public string   ProblemDescription  { get; }     //  описание услуги
        public DateOnly ClosingDate         { get; }     //  дата закрытия заявки

        private CRM_request() 
        {
        
        }

        public static Result<CRM_request> Create()
        {
            CRM_request result = new CRM_request();

            return Result.Success(result);
        }
    }
}