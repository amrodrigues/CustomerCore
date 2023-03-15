﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Events;

namespace Projeto.Repository.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task<IList<StoredEvent>> All(Guid aggregateId);
    }
}