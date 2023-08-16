using MediatR;

namespace Domanin.Primitives;

public record DomainEvent(Guid Id) : INotification;