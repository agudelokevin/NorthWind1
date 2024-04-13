using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.Common.Validators
{
    public class Validator<Model>
    {
        public Task<List<ValidationFailure>>Validate(Model model,
            IEnumerable<IValidator<Model>>validators,bool causesException=false)
        {
            var Failure=validators
            .Select(v=>v.Validate(model))
            .SelectMany(r=>r.Errors)
            .Where(f=>f!=null)
            .ToList();
            if(Failure.Any()&& causesException)
            {

            }
            return Task.FromResult(Failure);
        }
    }
}
