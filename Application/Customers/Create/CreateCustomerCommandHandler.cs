using Domain.Customers;
using Domain.ValueObjects;
using Domanin.Primitives;
using MediatR;

namespace Application.Customers.Create;

internal sealed class CreateCustomerCommmandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommmandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }

        if (Address.Create(command.Country, command.Line1, command.Line2, command.City,
            command.State, command.ZipCode) is not Address address)
        {
            throw new ArgumentException($"{nameof(address)} is not valid.");
        }

        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            command.Name,
            command.Lastname,
            command.Email,
            phoneNumber,
            address,
            true
            );

        await _customerRepository.Add(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
