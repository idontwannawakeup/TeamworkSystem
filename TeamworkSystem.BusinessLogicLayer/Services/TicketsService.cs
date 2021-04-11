using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ITicketsRepository ticketsRepository;

        public async Task<IEnumerable<TicketResponse>> GetAsync()
        {
            IEnumerable<Ticket> tickets = await this.ticketsRepository.GetAsync();
            return tickets?.Select(this.mapper.Map<Ticket, TicketResponse>);
        }

        public async Task<PagedList<TicketResponse>> GetAsync(TicketsParameters parameters)
        {
            PagedList<Ticket> tickets = await this.ticketsRepository.GetAsync(parameters);
            return tickets?.Map(this.mapper.Map<Ticket, TicketResponse>);
        }

        public async Task<TicketResponse> GetProfileByIdAsync(int id)
        {
            Ticket ticket = await this.ticketsRepository.GetByIdAsync(id);
            return this.mapper.Map<Ticket, TicketResponse>(ticket);
        }

        public async Task InsertAsync(TicketRequest request)
        {
            Ticket ticket = this.mapper.Map<TicketRequest, Ticket>(request);
            await this.ticketsRepository.InsertAsync(ticket);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task ExtendDeadlineAsync(TicketWithExtendedDeadlineRequest request)
        {
            Ticket ticket = await this.ticketsRepository.GetByIdAsync(request.Id);
            if (ticket.Deadline > request.Deadline)
            {
                throw new Exception("New date of deadline is sooner than current.");
            }

            ticket.Deadline = request.Deadline;
            await this.ticketsRepository.UpdateAsync(ticket);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this.ticketsRepository.DeleteAsync(id);
            await this.unitOfWork.SaveChangesAsync();
        }

        public TicketsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.ticketsRepository = this.unitOfWork.TicketsRepository;
        }
    }
}
