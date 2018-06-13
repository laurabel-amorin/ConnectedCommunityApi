using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.InputModels
{
    public abstract class Inputter<TI, T>
    {
        protected readonly TI input;
        protected T processedInput;
        protected T current;

        public Inputter(TI input)
        {
            this.input = input;
        }

        public Inputter(TI input, T current)
        {
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
