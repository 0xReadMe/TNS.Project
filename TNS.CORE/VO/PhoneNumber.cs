﻿using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
namespace TNS.CORE.VO;

public partial class PhoneNumber : ValueObject
{
    private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

    public string Number { get; }

    private PhoneNumber(string number) => Number = number;

    public static Result<PhoneNumber> Create(string input)
    {
        if (!IsPhoneNumber(input)) return Result.Failure<PhoneNumber>("Phone number invalid."); //  валидация номер телефона

        return Result.Success<PhoneNumber>(new (input));
    }

    /// <summary>
    /// Валидация номера телефона
    /// </summary>
    /// <param name="number">Номер телефона</param>
    /// <returns>True - номер телефона корректен</returns>
    public static bool IsPhoneNumber(string number)
    {
        try
        {
            if (string.IsNullOrEmpty(number))       return false;   //  не null и не пустая строка
            if (!MyRegex().Match(number).Success)   return false;   //  совпадает с регуляркой
            return true;
        }
        catch 
        {
            return false;
        }
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Number;
    }

    [GeneratedRegex(phoneRegex)]
    private static partial Regex MyRegex();
}