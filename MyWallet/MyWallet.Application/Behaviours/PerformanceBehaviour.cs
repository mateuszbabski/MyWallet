﻿using MediatR;
using Microsoft.Extensions.Logging;
using MyWallet.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Application.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly Stopwatch _timer;

        public PerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService userService, IUserRepository userRepository)
        {
            _logger = logger;
            _userService = userService;
            _userRepository = userRepository;
            _timer = new Stopwatch();

        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            

            _timer.Start();
            var response = await next();
            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogWarning($"Long Running Request: {requestName} ({elapsedMilliseconds} milliseconds) - {DateTime.Now}, {request}");
            }
                    
            return response;

        }
    }
}


                

