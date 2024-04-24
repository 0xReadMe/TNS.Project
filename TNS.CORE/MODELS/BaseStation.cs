using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNS.Database;

namespace TNS.CORE.MODELS
{
    public class BaseStation
    {


        public BaseStation() 
        {
        }

        public static Result<BaseStation> Create() 
        {
            BaseStation result = new BaseStation();

            return Result.Success(result);
        }
    }
}
