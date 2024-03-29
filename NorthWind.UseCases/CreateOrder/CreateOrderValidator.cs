﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator:AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator() 
        {
            RuleFor(c => c.CustomerId).NotEmpty()
            .WithMessage("Debe Proporcionar la identificacion del Cliente.");
            RuleFor(c => c.ShipAddress).NotEmpty()
               .WithMessage("Debe Proporcionar la Direccion del Envio.");
            RuleFor(c => c.ShipCity).NotEmpty().MinimumLength(3)
            .WithMessage("Debe Proporcionar al menos 3 caracteres del nombre de la ciudad. ");
            RuleFor(c => c.ShipCountry).NotEmpty().MinimumLength(3)
                .WithMessage("Debe Proporcionar al menos 3 caracteres del nombre de la ciudad.");
            RuleFor(c => c.OrderDetails)
                .Must(d => d != null && d.Any())
                .WithMessage("Deben especificarse los productos de la orden.");

        }
    }
}
