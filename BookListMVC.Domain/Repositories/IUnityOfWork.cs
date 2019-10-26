using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Domain.Repositories
{
    public interface IUnityOfWork : IDisposable
    {
        IBooksRepository Books { get; }

        Task<int> CompleteAsync();
    }
}
