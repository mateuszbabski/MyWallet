using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactionsPaginated;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionsBySearch;
using MyWallet.Application.Wrappers;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TransactionDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet(Name = "PaginatedResult")]
        //public async Task<ActionResult<PaginatedList<TransactionInListViewModel>>> GetPaginatedTransactionsAsync([FromQuery]int page, [FromQuery]int pageSize)
        //{
        //    var transactionList = await _mediator.Send(new GetAllTransactionsPaginatedQuery()
        //    {
        //        PageNumber = page,
        //        PageSize = pageSize
        //    });
        //    return Ok(transactionList);
        //}
        [HttpGet(Name = "ResultBySearchQuery")]
        public async Task<ActionResult<PaginatedList<TransactionInListViewModel>>> GetTransactionsBySearchAsync([FromQuery] RequestParams request)
        {
            var transactionList = await _mediator.Send(new GetTransactionsBySearchQuery()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchPhrase = request.SearchPhrase
            });
            return Ok(transactionList);
        }
    }
}
                
