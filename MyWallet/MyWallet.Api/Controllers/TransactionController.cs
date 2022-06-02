using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyWallet.Application.Features.Transactions.Commands.CreateTransaction;
using MyWallet.Application.Features.Transactions.Commands.DeleteTransaction;
using MyWallet.Application.Features.Transactions.Commands.UpdateTransaction;
using MyWallet.Application.Features.Transactions.Queries.GetAllTransactions;
using MyWallet.Application.Features.Transactions.Queries.GetTransactionById;
using MyWallet.Domain.Entities;

namespace MyWallet.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GetAll
        [HttpGet(Name = "GetAllTransactions")]
        public async Task<ActionResult<IEnumerable<TransactionInListViewModel>>> GetAllTransactions()
        {
            var transactionList = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(transactionList);
        }

        // GetById
        [HttpGet("{id}", Name = "GetTransactionById")]
        public async Task<ActionResult<TransactionViewModel>> GetTransactionById(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionByIdQuery()
            {
                Id = id
            });
            return Ok(transaction);
        }

        // Add
        [HttpPost(Name = "AddTransaction")]
        public async Task<ActionResult<int>> CreateTransaction([FromBody] CreateTransactionCommand createTransactionCommand)
        {
            var transaction = await _mediator.Send(createTransactionCommand);
            return Ok(transaction);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTransaction([FromBody] UpdateTransactionCommand updateTransactionCommand)
        {
            await _mediator.Send(updateTransactionCommand);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            var deleteTransactionCommand = new DeleteTransactionCommand()
            {
                Id = id
            };

            await _mediator.Send(deleteTransactionCommand);
            return NoContent();
        }
    }
}
