using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var customer = await _unitOfWork.Repository<Customer>().GetEntityBySpecificationAsync(new CustomerWithOrdersSpecification(id));

        return _mapper.Map<Customer, CustomerDto>(customer);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<CustomerDto>>> GetCustomers()
    {
        var customers = await _unitOfWork.Repository<Customer>().GetAllWithSpecificationAsync(new CustomerWithOrdersSpecification());

        return Ok(_mapper.Map<IReadOnlyCollection<Customer>, IReadOnlyCollection<CustomerDto>>(customers));
    }

    [HttpPost]
    public async Task Post([FromBody] CustomerDto user)
    {
        _unitOfWork.Repository<Customer>().Add(_mapper.Map<CustomerDto, Customer>(user));
        await _unitOfWork.CompleteAsync();

    }
}
