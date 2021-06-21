using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IUserInputRepository _userInputs;
        public IUserInputRepository UserInput
        {
            get
            {
                if (_userInputs == null)
                {
                    _userInputs = new UserInputRepository(_repoContext);
                }
                return _userInputs;

            }
        }
        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

