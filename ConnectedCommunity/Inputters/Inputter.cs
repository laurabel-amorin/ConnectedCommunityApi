using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public abstract class Inputter<TI, T, TR> 
        where TR : IRepository<T>
        where T:class
    {
        protected readonly TI input;
        protected T processedInput;
        protected T current;
        protected TR repo;

        public Inputter(TR repo, TI input)
        {
            this.repo = repo;
            this.input = input;
        }

        public Inputter(TR repo, TI input, T current)
        {
            this.repo = repo;
            this.input = input;
            this.current = current;
        }

        public ValidationResult Validate()
        {
            if (current==null)
            {
                return ValidateNew();
            }
            return ValidateUpdate();
        }

        public T GetProcessedInput()
        {
            return processedInput;
        }

        public abstract ValidationResult ValidateNew();
        public abstract ValidationResult ValidateUpdate();
        
    }
}
