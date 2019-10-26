using BookList.Domain.Repositories;
using BookList.Infra.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Infra.Data.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBooksRepository Books { get; }

        public IBooksRepository Categories => throw new NotImplementedException();

        public UnityOfWork(ApplicationDbContext context)
        {
            _context = context;

            Books = new BooksRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
