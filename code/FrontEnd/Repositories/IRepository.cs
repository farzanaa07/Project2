﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
public interface IRepository<T>
    {
        T Create(T entity);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
