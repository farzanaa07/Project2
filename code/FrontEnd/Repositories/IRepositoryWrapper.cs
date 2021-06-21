using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
public interface IRepositoryWrapper
    {
        IUserInputRepository UserInput { get; }
        void Save();
    }
}
