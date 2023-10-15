using BookReadingEvent.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Domain.UnitOfWorkInterface
{
    public interface IAccountUnitOfWork
    {
        public IAccountRepository Account { get; }

    }
}
