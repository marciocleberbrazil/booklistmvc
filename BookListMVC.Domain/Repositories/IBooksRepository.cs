using BookList.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookList.Domain.Repositories
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
    }
}
