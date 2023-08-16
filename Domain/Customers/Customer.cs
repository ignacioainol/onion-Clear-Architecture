using Domain.ValueObjects;
using Domanin.Primitives;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public CustomerId customerId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Lastname { get; private set; } = string.Empty;
    public string FullName => $"{Name} {Lastname}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }

}