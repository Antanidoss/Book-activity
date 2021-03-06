using BookActivity.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookActivity.Domain.Interfaces.Repositories
{
    public interface IEventStoreRepository : IDisposable
    {
        void Save(StoredEvent @event);
        Task<IList<StoredEvent>> GetAllAsync(Guid aggregateId);
    }
}