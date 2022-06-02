using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Budgets.Commands.DeleteBudget;
using MyWallet.Application.Features.Budgets.Commands.UpdateBudget;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BudgetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GetAll
        [HttpGet(Name = "GetAllBudgets")]
        public async Task<ActionResult<IEnumerable<BudgetInListViewModel>>> GetAllBudgets()
        {
            var budgetList = await _mediator.Send(new GetAllBudgetsQuery());
            return Ok(budgetList);
        }

        // GetById
        [HttpGet("{id}", Name = "GetBudgetById")]
        public async Task<ActionResult<BudgetViewModel>> GetBudgetById(int id)
        {
            var budget = await _mediator.Send(new GetBudgetByIdQuery()
            {
                Id = id
            });
            return Ok(budget);
        }


        // Add
        [HttpPost(Name = "AddBudget")]
        public async Task<ActionResult<int>> CreateBudget([FromBody] CreateBudgetCommand createBudgetCommand)
        {
            var budget = await _mediator.Send(createBudgetCommand);
            return Ok(budget);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBudget([FromBody] UpdateBudgetCommand updateBudgetCommand)
        {
            await _mediator.Send(updateBudgetCommand);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBudget(int id)
        {
            var deleteBudgetCommand = new DeleteBudgetCommand()
            {
                Id = id
            };

            await _mediator.Send(deleteBudgetCommand);
            return NoContent();
        }
    }
}
