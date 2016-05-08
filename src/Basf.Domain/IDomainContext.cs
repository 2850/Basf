﻿using Basf.Data;
using Basf.Domain.Event;
using Basf.Message;
using System;
using System.Threading.Tasks;

namespace Basf.Domain
{
    public interface IDomainContext
    {
        void Initialize(Action<IProducer> producerInitializer, Action<IConsumer> consumerInitializer);
        void Start();
        IAggRoot Get(AggRootKey aggRootKey);
        Task<IAggRoot> GetAsync(AggRootKey aggRootKey);
        void Add(IAggRoot aggRoot);
        Task AddAsync(IAggRoot aggRoot);
        Task<ActionResponse> ApplyChange(IDomainEvent domainEvent);
        ActionResponse Publish(IDomainEvent domainEvent);
        Task<ActionResponse> PublishAsync(IDomainEvent domainEvent);
        ActionResponse InvokeHandler(IAggRoot aggRoot, IDomainEvent domainEvent);
        void AddHandler(Type aggRootType, Type eventType);
    }
}
