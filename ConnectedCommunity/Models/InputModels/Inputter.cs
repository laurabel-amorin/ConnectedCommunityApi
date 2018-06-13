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
        protected readonly int id;

        public Inputter(TI input)
        {
            this.input = input;
        }

        public Inputter(TI input, int id)
        {
            this.input = input;
            this.id = id;
        }

        public ValidationResult Validate()
        {
            if (id == 0)
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
