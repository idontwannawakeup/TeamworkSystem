namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class RatingProfileResponse
    {
        public int Id { get; set; }

        public string FromId { get; set; }

        public string ToId { get; set; }

        public int Social { get; set; }

        public int Skills { get; set; }

        public int? Responsibility { get; set; }

        public int? Punctuality { get; set; }

        public string Comment { get; set; }
    }
}
