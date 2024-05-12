using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNS.CORE.MODELS
{
    internal class Service
    {
        public Guid     Id   { get; }    //  id услуги
        public string   Name { get; }    //  имя услуги

        private Service(Guid id,
                        string name) 
        {
            Id = id;
            Name = name;
        }

        public static Result<Service> Create(Guid id,
                                             string name)
        {
            Service result = new Service(id,
                                         name);

            return Result.Success(result);
        }
    }
}
