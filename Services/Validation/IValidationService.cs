using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public interface IValidationService
    {
        char OptionValidation(string material);

        DateTime ValidationDate();

        int ValidationInterger();

        decimal ValidationDecimal();
    }
}
