using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class UpdateEventCommand : IRequest<bool>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Capacity { get; init; }
        public DateTime CreationDate { get; init; }
        public Guid LocationId { get; init; }

        public UpdateEventCommand(Guid id, string name, int capacity, DateTime creationDate, Guid locationId)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            CreationDate = creationDate;
            LocationId = locationId;
        }
    }

}
