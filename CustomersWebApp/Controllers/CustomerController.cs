using CustomersWebApp.Application.Dtos;
using CustomersWebApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomersWebApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICreateCustomerUseCase createCustomerUseCase;
    private readonly IGetCustomersUseCase getCustomersUseCase;
    private readonly IGetCustomerDetailsUseCase getCustomerDetailsUseCase;

    public CustomerController(ICreateCustomerUseCase createCustomerUseCase, IGetCustomersUseCase getCustomersUseCase, IGetCustomerDetailsUseCase getCustomerDetailsUseCase)
    {
        this.createCustomerUseCase = createCustomerUseCase;
        this.getCustomersUseCase = getCustomersUseCase;
        this.getCustomerDetailsUseCase = getCustomerDetailsUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerResponseDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CustomerRequest customer)
    {
        var createdCustomer = await createCustomerUseCase.CreateCustomer(customer);

        return Ok(createdCustomer);
    }
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CustomerResponseDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CustomerDetailsDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
    {
        var customers = await this.getCustomersUseCase.Get(pageNumber, pageSize);
        return Ok(customers);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] string Id)
    {
        var customer = await getCustomerDetailsUseCase.GetCustomerById(Guid.Parse(Id));

        return Ok(customer);
    }

}
