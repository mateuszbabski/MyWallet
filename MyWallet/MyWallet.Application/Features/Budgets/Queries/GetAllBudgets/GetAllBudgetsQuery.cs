﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Features.Budgets.Queries.GetAllBudgets
{
    public class GetAllBudgetsQuery : IRequest<IEnumerable<BudgetInListViewModel>>
    {

    }
}
