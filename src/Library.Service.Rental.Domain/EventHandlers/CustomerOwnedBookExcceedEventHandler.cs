using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class CustomerOwnedBookExcceedEventHandler : BaseRentalEventHandler<CustomerOwnedBookExcceedEvent>
    {
        public CustomerOwnedBookExcceedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(CustomerOwnedBookExcceedEvent evt)
        {
            try
            {
                evt.Result(CustomerOwnedBookExcceedEvent.Code_CUSTOMEOWNEDBOOK_EXCCEED);
            }
            catch (Exception ex)
            {
                evt.Result(DomainEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}