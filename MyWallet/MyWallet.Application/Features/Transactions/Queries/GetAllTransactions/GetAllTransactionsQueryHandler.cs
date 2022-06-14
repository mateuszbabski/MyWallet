using AutoMapper;
using MediatR;
using MyWallet.Application.Interfaces;



namespace MyWallet.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionInListViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, 
            IMapper mapper, 
            ICurrentUserService userService)
            
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _userService = userService;
        }

            
        public async Task<IEnumerable<TransactionInListViewModel>> Handle(GetAllTransactionsQuery request, 
            CancellationToken cancellationToken)
        {
            var userId = _userService.GetUserId;
            var transactions = await _transactionRepository.GetAllTransactionsAsync(userId);
            

            return _mapper.Map<IEnumerable<TransactionInListViewModel>>(transactions);
        }
    }
}
         
            

