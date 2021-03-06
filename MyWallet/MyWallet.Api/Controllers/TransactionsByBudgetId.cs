using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionsByBudgetId;
using MyWallet.Application.Wrappers;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class TransactionsByBudgetId : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransactionsByBudgetId(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "ResultByBudgetId")]
        public async Task<ActionResult<PaginatedList<TransactionInListViewModel>>> GetTransactionsByBudgetIdAsync([FromQuery] RequestParams request)
        {
            var transactionList = await _mediator.Send(new GetTransactionsByBudgetIdQuery()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                BudgetId = request.BudgetId
            });
            return Ok(transactionList);
        }
    }
}
                
