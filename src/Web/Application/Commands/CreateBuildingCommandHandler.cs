using MediatR;

namespace Web.Application.Commands
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, bool>
    {
        public Task<bool> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
