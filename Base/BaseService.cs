using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Base
{
    public interface IBaseService <T>
    {
        Task<(T , string? error)> Get(Guid id);
        Task<(T?,  string? error)> Create(T entity);
        Task<(T?,  string? error)> Delete(Guid id);
        
    
    }
}