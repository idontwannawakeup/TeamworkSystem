﻿using System;
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

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ITicketsRepository ticketsRepository;

        public async Task<IEnumerable<TicketProfileResponse>> GetProfilesAsync()
        {
            IEnumerable<Ticket> tickets = await this.ticketsRepository.GetAllAsync();
            return tickets.Select(this.mapper.Map<Ticket, TicketProfileResponse>);
        }

        public async Task<IEnumerable<TicketProfileResponse>> GetProfilesAsync(
            TicketsByProjectAndStatusRequest request)
        {
            IEnumerable<Ticket> tickets = await this.ticketsRepository
                .GetByProjectIdAndStatus(request.ProjectId, request.Status);

            return tickets.Select(this.mapper.Map<Ticket, TicketProfileResponse>);
        }

        public async Task<TicketProfileResponse> GetProfileByIdAsync(int id)
        {
            Ticket ticket = await this.ticketsRepository.GetByIdAsync(id);
            return this.mapper.Map<Ticket, TicketProfileResponse>(ticket);
        }

        public async Task ExtendDeadline(TicketWithExtendedDeadlineRequest request)
        {
            Ticket ticket = await this.ticketsRepository.GetByIdAsync(request.Id);
            if (ticket.Deadline > request.Deadline)
            {
                throw new Exception("New date of deadline is sooner than current.");
            }

            await this.ticketsRepository.UpdateAsync(ticket);
            ticket.Deadline = request.Deadline;
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await this.ticketsRepository.DeleteAsync(id);
        }

        public TicketsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.ticketsRepository = this.unitOfWork.TicketsRepository;
        }
    }
}
