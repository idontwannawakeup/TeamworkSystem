using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class User : IIdentifiableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Profession { get; set; }

        public string? Specialization { get; set; }

        public User(int id,
            string name,
            string surname,
            string? profession,
            string? specialization)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Profession = profession;
            this.Specialization = specialization;
        }
    }
}
