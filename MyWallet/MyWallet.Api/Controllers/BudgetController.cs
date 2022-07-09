using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Api.Services;
using MyWallet.Application.Features.Budgets.Commands.CreateBudget;
using MyWallet.Application.Features.Budgets.Commands.DeleteBudget;
using MyWallet.Application.Features.Budgets.Commands.UpdateBudget;
using MyWallet.Application.Features.Budgets.Queries.GetAllBudgets;
using MyWallet.Application.Features.Budgets.Queries.GetBudgetById;
using MyWallet.Application.Interfaces;
using System.Security.Claims;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BudgetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _userService;
        

        public BudgetController(IMediator mediator, ICurrentUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
            
        }

        
        [HttpGet(Name = "GetAllBudgets")]
        public async Task<ActionResult<IEnumerable<BudgetInListViewModel>>> GetAllBudgets()
        {
            
            var budgetList = await _mediator.Send(new GetAllBudgetsQuery()
            {
                CreatedById = _userService.GetUserId
            });
                
            return Ok(budgetList);
        }


        [HttpGet("{id}", Name = "GetBudgetById")]
        public async Task<ActionResult<BudgetViewModel>> GetBudgetById(int id)
        {
            var budget = await _mediator.Send(new GetBudgetByIdQuery()
            {
                Id = id,
                CreatedById = _userService.GetUserId
            });
            return Ok(budget);
        }
        
        
        [HttpPost(Name = "AddBudget")]
        public async Task<ActionResult<int>> CreateBudget([FromBody] CreateBudgetCommand createBudgetCommand)
        {
            //var budget = await _mediator.Send(createBudgetCommand);
            var budget = await _mediator.Send(new CreateBudgetCommand
            {
                UserId = _userService.GetUserId,
                Name = createBudgetCommand.Name,
                Description = createBudgetCommand.Description
            });

            return Ok(budget);
        }
            


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBudget([FromBody] UpdateBudgetCommand updateBudgetCommand)
        {
            await _mediator.Send(new UpdateBudgetCommand()
            {
                CreatedById = _userService.GetUserId,
                Id = updateBudgetCommand.Id,
                Name = updateBudgetCommand.Name,
                Description = updateBudgetCommand.Description
            });

            return NoContent();
        }
            
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBudget(int id)
        {
            var deleteBudgetCommand = new DeleteBudgetCommand()
            {
                Id = id,
                CreatedById = _userService.GetUserId
            };

            await _mediator.Send(deleteBudgetCommand);
            return NoContent();
        }
    }
}
        
        
        
            

        

        
