namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class TeamResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LeaderId { get; set; }

        public string Specialization { get; set; }

        public string About { get; set; }

        public string Avatar { get; set; }

        public UserResponse Leader { get; set; }
    }
}
