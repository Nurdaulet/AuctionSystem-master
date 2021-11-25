



namespace Application.TopUp.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class UserTopUpCommandHandler : IRequestHandler<UserTopUpCommand>
    {
        private readonly IAuctionSystemDbContext context;
        private readonly ICurrentUserService currentUserService;
        private readonly IDateTime dateTime;
        private readonly IMapper mapper;

        public UserTopUpCommandHandler(IAuctionSystemDbContext context,
            ICurrentUserService currentUserService,
            IDateTime dateTime,
            IMapper mapper)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.dateTime = dateTime;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UserTopUpCommand request, CancellationToken cancellationToken)
        {
            var transactionNew = this.mapper.Map<TransactionsNew>(request);
            var saldo = await this.context.SaldoUsers.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            if (saldo != null)
            {
                saldo.Saldo += request.Amount;
            }
            else
            {
                saldo = new SaldoUser { Saldo = request.Amount, UserId = request.UserId };
                await this.context.SaldoUsers.AddAsync(saldo, cancellationToken);
            }
            transactionNew.ClassOfTransaction = (int)ClassOfTransaction.TopUp;
            transactionNew.SaldoAccount = saldo.Saldo;
            await this.context.TransactionsNew.AddAsync(transactionNew, cancellationToken);
            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}