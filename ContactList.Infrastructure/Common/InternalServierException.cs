using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure.Common
{
    public class InternalServierException : Exception
    {
        public InternalServierException() { }

        public InternalServierException(string errorcode)
            : base(String.Format("Internal server error with code: {0}", errorcode))
        {

        }
    }
}
