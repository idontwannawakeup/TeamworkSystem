using System.Data.SqlClient;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Profession { get; set; }

        public string? Specialization { get; set; }

        public static User CreateInstanceFromReader(SqlDataReader reader)
        {
            var id = (int) reader["Id"];
            string name = (string) reader["Name"];
            string surname = (string) reader["Surname"];

            string? profession = !reader.IsDBNull(3)
                ? (string) reader["Profession"]
                : null;

            string? specialization = !reader.IsDBNull(4)
                ? (string) reader["Specialization"]
                : null;

            return new User(id,
                name,
                surname,
                profession,
                specialization);
        }

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
