using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionsByDate;
using MyWallet.Application.Wrappers;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class TransactionsByDateRange : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsByDateRange(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "ResultByDateRange")]
        public async Task<ActionResult<PaginatedList<TransactionInListViewModel>>> GetTransactionsByDateRangeAsync([FromQuery] RequestParams request)
        {
            var transactionList = await _mediator.Send(new GetTransactionsByDateRangeQuery()
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                BudgetId = request.BudgetId
            });
            return Ok(transactionList);
        }
    }
}
