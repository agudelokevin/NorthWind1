﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.Common.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse>:
        IPipelineBehavior<TRequest,TResponse>
        where TRequest : IRequest<TResponse>
    {
        readonly IEnumerable<IValidator<TRequest>> Validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)=>
            Validators = validators;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var Failures = Validators
                .Select(v => v.Validate(request))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();
            if(Failures.Any())
            {
                throw new ValidationException(Failures);
            }
            return next();
        }
    }
}
