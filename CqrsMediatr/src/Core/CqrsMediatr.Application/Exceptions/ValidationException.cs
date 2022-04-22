using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsMediatr.Application.Exceptions
{
    public class ValidationException:Exception
    {
        public ValidationException():base("Validation error occured")
        {

        }
        public ValidationException(string message) : base(message)
        {

        }
        public ValidationException(Exception exception) : base(exception.Message)
        {

        }
    }
}
