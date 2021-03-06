using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;

using MyWallet.Application.Features.Transactions.Queries.GetTransactionsBySearch;
using MyWallet.Application.Wrappers;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class TransactionDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
       
        
                
                
