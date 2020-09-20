using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.Repos.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IBookRepo Books { get; }
        IAuthorRepo Authors { get; }
        
        Task Done();
    }
}
