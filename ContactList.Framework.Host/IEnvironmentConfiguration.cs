using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Framework.Host
{
    public interface IEnvironmentConfiguration
    {
        string ConnectionString(string key);
    }
}
