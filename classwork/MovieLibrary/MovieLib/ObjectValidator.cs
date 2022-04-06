using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class ObjectValidator
    {
        public bool TryValidateObject ( IValidatableObject value, out IEnumerable<ValidationResult> results )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            if (Validator.TryValidateObject(value, context, errors, true))
            {
                results = new ValidationResult[0];
                return true;
            };

            results = errors;
            return false;
        }
    }
}
