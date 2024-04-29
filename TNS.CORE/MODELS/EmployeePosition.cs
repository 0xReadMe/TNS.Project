using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace TNS.CORE.MODELS 
{
    public class EmployeePosition 
    {
        public Guid     Id              { get; }    //  id должности
        public string   PositionName    { get; }    //  название должности

        private EmployeePosition() 
        {
        
        }

        public static Result<EmployeePosition> Create()
        {
            EmployeePosition result = new EmployeePosition();

            return Result.Success(result);
        }
    }
}
