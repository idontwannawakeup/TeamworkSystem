using AutoMapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Requests;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Application.Interfaces.Repositories;
using TeamworkSystem.WorkManagement.Application.Interfaces.Services;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Services;

public class TicketsService : ITicketsService
{
    private readonly IMapper _mapper;
    private readonly ITicketsRepository _ticketsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TicketsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ticketsRepository = _unitOfWork.TicketsRepository;
    }

    public async Task<IEnumerable<TicketResponse>> GetAsync()
    {
        var tickets = await _ticketsRepository.GetAsync();
        return tickets.Select(_mapper.Map<Ticket, TicketResponse>);
    }

    public async Task<PagedList<TicketResponse>> GetAsync(TicketsParameters parameters)
    {
        var tickets = await _ticketsRepository.GetAsync(parameters);
        return tickets.Map(_mapper.Map<Ticket, TicketResponse>);
    }

    public async Task<TicketResponse> GetByIdAsync(Guid id)
    {
        var ticket = await _ticketsRepository.GetCompleteEntityAsync(id);
        return _mapper.Map<Ticket, TicketResponse>(ticket);
    }

    public async Task InsertAsync(TicketRequest request)
    {
        var ticket = _mapper.Map<TicketRequest, Ticket>(request);
        await _ticketsRepository.InsertAsync(ticket);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketRequest request)
    {
        var ticket = await _ticketsRepository.GetByIdAsync(request.Id);
        ticket.ProjectId = request.ProjectId;
        ticket.ExecutorId = request.ExecutorId;
        ticket.Title = request.Title;
        ticket.Type = request.Type;
        ticket.Description = request.Description;
        ticket.Status = request.Status;
        ticket.Priority = request.Priority;
        ticket.Deadline = request.Deadline;
        await _ticketsRepository.UpdateAsync(ticket);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ExtendDeadlineAsync(
        TicketWithExtendedDeadlineRequest request)
    {
        var ticket = await _ticketsRepository.GetByIdAsync(request.Id);

        if (ticket.Deadline > request.Deadline)
        {
            throw new Exception("New date of deadline is sooner than current.");
        }

        ticket.Deadline = request.Deadline;
        await _ticketsRepository.UpdateAsync(ticket);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _ticketsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
