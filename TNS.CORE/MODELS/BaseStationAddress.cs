using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    internal class BaseStationAddress
    {
        public Guid     Id          { get; }    //  id
        public string   Address     { get; }    //  адрес площадки
        public string   Location    { get; }    //  место расположения

        private BaseStationAddress(Guid id, string address, string location) 
        {
            Id              = id;
            Address         = address;
            Location        = location;
        }

        public static Result<BaseStationAddress> Create(string address, string location)
        {
            if (!IsValidAddress(address))   return Result.Failure<BaseStationAddress>("Address invalid");   //  валидация адреса площадки
            if (!IsValidAddress(location))  return Result.Failure<BaseStationAddress>("Location invalid");  //  валидация места расположения

            Guid id = Guid.NewGuid();
            return Result.Success<BaseStationAddress>(new(id, address, location));
        }

        /// <summary>
        /// Валидация адреса площадки
        /// </summary>
        /// <param name="address">Адрес площадки</param>
        /// <returns>True - адрес площадки корректен</returns>
        private static bool IsValidAddress(string address)
        {
            try
            {
                string[] parts = address.Split(',');
                string pattern = @"^[\p{L}\p{N}\s\.\,\-\(\)]+$";

                if (string.IsNullOrWhiteSpace(address)) return false;   //  адрес площадки не пустой
                if (address.Length > 150) return false;   //  длина адреса площадки не превышает 150 символов
                if (!System.Text.RegularExpressions.Regex.IsMatch(address, pattern)) return false;   //  адрес площадки содержит только допустимые символы (буквы, цифры, пробелы, точки, запятые, дефисы, скобки)
                if (parts.Length < 2) return false;   //  адрес площадки содержит как минимум 2 части, разделенные запятой
                foreach (string part in parts)                                                          //  каждая часть адреса площадки не пустая и не превышает 50 символов
                {
                    if (string.IsNullOrWhiteSpace(part) || part.Length > 50) return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;                // Возвращаем false, если возникла любая ошибка при проверке адреса площадки
            }
        }
    }
}
