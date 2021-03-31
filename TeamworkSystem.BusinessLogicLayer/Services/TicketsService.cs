using System;
using System.Threading.Tasks;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ITicketsRepository ticketsRepository;

        public async Task ExtendDeadline(TicketWithExtendedDeadlineRequest ticketWithExtendedDeadline)
        {
            Ticket ticket = await this.ticketsRepository.GetByIdAsync(ticketWithExtendedDeadline.Id);
            if (ticket.Deadline > ticketWithExtendedDeadline.Deadline)
            {
                throw new Exception("New date of deadline is sooner than current.");
            }

            await this.ticketsRepository.UpdateAsync(ticket);
            ticket.Deadline = ticketWithExtendedDeadline.Deadline;
            await this.unitOfWork.SaveChangesAsync();
        }

        public TicketsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.ticketsRepository = this.unitOfWork.TicketsRepository;
        }
    }
}
