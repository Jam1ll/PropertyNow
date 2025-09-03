using MediatR;
using PropertyNow.Core.Application.DTOs.User;
using PropertyNow.Core.Application.Exceptions;
using PropertyNow.Core.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PropertyNow.Core.Application.Features.Agents.Commands.ChangeStatus
{
    /// <summary>
    /// Command to change the status (active/inactive) of an agent
    /// </summary>
    public class ChangeStatusAgentCommand : IRequest<Unit>
    {
        /// <summary>
        /// The unique identifier of the agent
        /// </summary>
        /// <example>5ac0dfee-9c1c-4f9e-bdd3-5a2d864faea2</example>
        [SwaggerParameter(Description = "The ID of the agent whose status will be changed")]
        public string UserId { get; set; } = default!;

        /// <summary>
        /// The new status of the agent
        /// </summary>
        /// <example>true</example>
        [SwaggerParameter(Description = "The new status of the agent (true = active, false = inactive)")]
        public bool NewStatus { get; set; }
    }

    public class ChangeStatusAgentCommandHandler : IRequestHandler<ChangeStatusAgentCommand, Unit>
    {
        private readonly IAccountServiceForWebApi _accountService;

        public ChangeStatusAgentCommandHandler(IAccountServiceForWebApi accountService)
        {
            _accountService = accountService;
        }

        public async Task<Unit> Handle(ChangeStatusAgentCommand request, CancellationToken cancellationToken)
        {
            var result = await _accountService.ChangeStatusAsync(request.UserId, request.NewStatus);

            if (result == null) // suponiendo que tu servicio devuelve un bool o algo similar
            {
                throw new ApiException("Failed to update agent status", (int)HttpStatusCode.InternalServerError);
            }

            return Unit.Value;
        }
    }
}
