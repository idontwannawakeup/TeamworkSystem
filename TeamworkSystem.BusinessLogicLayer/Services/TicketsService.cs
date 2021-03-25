using System;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IUnitOfWork unitOfWork;

        public async Task ExtendDeadline(TicketWithExtendedDeadlineDTO ticketWithExtendedDeadline)
        {
            Ticket ticket = await this.unitOfWork.TicketsRepository.GetByIdAsync(ticketWithExtendedDeadline.Id);
            if (ticket.Deadline > ticketWithExtendedDeadline.Deadline)
            {
                throw new Exception("New date of deadline is sooner than current.");
            }

            await this.unitOfWork.TicketsRepository.UpdateAsync(ticket);
            ticket.Deadline = ticketWithExtendedDeadline.Deadline;
            await this.unitOfWork.SaveChangesAsync();
        }

        public TicketsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
