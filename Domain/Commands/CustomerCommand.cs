using System;
using NetDevPack.Messaging;

namespace Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string CPF { get; protected set; }

        public DateTime DateOfBirth { get; protected set; }
    }
}