namespace TeamworkSystem.BusinessLogicLayer.DTO.Requests
{
    public class TicketsByProjectAndStatusRequest
    {
        public int ProjectId { get; set; }

        public string Status { get; set; }
    }
}
