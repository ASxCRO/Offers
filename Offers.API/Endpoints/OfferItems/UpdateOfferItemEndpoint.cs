﻿using FastEndpoints;
using FluentValidation;
using MediatR;
using Offers.Shared.Commands;

namespace Offers.API.Endpoints.OfferItems
{
    public class UpdateOfferItemEndpoint : Endpoint<UpdateOfferItemCommand>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<UpdateOfferItemCommand> _validator;

        public UpdateOfferItemEndpoint(IMediator mediator, IValidator<UpdateOfferItemCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public override void Configure()
        {
            Put("/offeritems"); 
            AllowAnonymous(); 
        }

        public override async Task HandleAsync(UpdateOfferItemCommand req, CancellationToken ct)
        {
            var validationResult = await _validator.ValidateAsync(req);
            if (!validationResult.IsValid)
            {
                await SendErrorsAsync();
                return;
            }

            await _mediator.Send(req, ct);
            await SendOkAsync(); 
        }
    }
}
