namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class TeamResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public UserResponse Leader { get; set; }
    }
}
