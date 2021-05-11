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
            var tickets = await ticketsRepository.GetAsync();
            return tickets?.Select(mapper.Map<Ticket, TicketResponse>);
        }

        public async Task<PagedList<TicketResponse>> GetAsync(
            TicketsParameters parameters)
        {
            var tickets = await ticketsRepository.GetAsync(parameters);
            return tickets?.Map(mapper.Map<Ticket, TicketResponse>);
        }

        public async Task<TicketResponse> GetByIdAsync(int id)
        {
            var ticket = await ticketsRepository.GetCompleteEntityAsync(id);
            return mapper.Map<Ticket, TicketResponse>(ticket);
        }

        public async Task InsertAsync(TicketRequest request)
        {
            var ticket = mapper.Map<TicketRequest, Ticket>(request);
            await ticketsRepository.InsertAsync(ticket);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketRequest request)
        {
            var ticket = await ticketsRepository.GetByIdAsync(request.Id);
            ticket.ProjectId = request.ProjectId;
            ticket.ExecutorId = request.ExecutorId;
            ticket.Title = request.Title;
            ticket.Type = request.Type;
            ticket.Description = request.Description;
            ticket.Status = request.Status;
            ticket.Priority = request.Priority;
            ticket.Deadline = request.Deadline;
            await ticketsRepository.UpdateAsync(ticket);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task ExtendDeadlineAsync(
            TicketWithExtendedDeadlineRequest request)
        {
            var ticket = await ticketsRepository.GetByIdAsync(request.Id);

            if (ticket.Deadline > request.Deadline)
            {
                throw new Exception(
                    "New date of deadline is sooner than current.");
            }

            ticket.Deadline = request.Deadline;
            await ticketsRepository.UpdateAsync(ticket);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await ticketsRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public TicketsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            ticketsRepository = this.unitOfWork.TicketsRepository;
        }
    }
}
