using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    public class CRM_request
    {
        public Guid     Id { get; }                     //  todo: генер. автомат: ЛС абонента|день|месяц|год
        public Guid     SubscriberId { get; }           //  лицевой счет + номер абонента
        public DateOnly CreationDate { get; }           //  дата создания
        public string   Service { get; }                //  услуга
        public string   ServiceProvided { get; }        //  оказываемая услуга
        public string   ServiceType { get; }            //  тип услуги
        public string   Status { get; }                 //  статус услуги
        public string   TypeOfEquipment { get; }        //  тип оборудования
        public string   TypeOfProblem { get; }          //  тип проблемы
        public string   ProblemDescription { get; }     //  описание услуги
        public DateOnly ClosingDate { get; }            //  дата закрытия заявки

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