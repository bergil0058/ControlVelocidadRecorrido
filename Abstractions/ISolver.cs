using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ISolver
    {

        public Task<double> GetMaximumConstantSpeedAsync(Test aTest);

    }
}
