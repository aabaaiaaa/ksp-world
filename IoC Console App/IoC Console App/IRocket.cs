using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Console_App
{
    public interface IRocket
    {
        IKerbal[] Pilots { get; }
        IKerbal[] AddPilot(IKerbal pilot);
    }
}
