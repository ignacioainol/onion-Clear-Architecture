using Domain.ValueObjects;
using Domanin.Primitives;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public Customer(CustomerId id, string name, string lastname, string email, PhoneNumber phoneNumber, Address address, bool active)
    {
    }

    private Customer()
    {

    }

    public CustomerId customerId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Lastname { get; private set; } = string.Empty;
    public string FullName => $"{Name} {Lastname}";
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public bool Active { get; set; }

}