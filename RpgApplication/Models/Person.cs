namespace RpgApplication.Models
{
    [Serializable]
    public class Person
    {
        public string? Name { get; set; }

        public string? BirthYear { get; set; }

        public string? EyeColor { get; set; }

        public string? Gender { get; set; }

        public string? HairColor { get; set; }

        public string? Height { get; set; }

        public string? Mass { get; set; }

        public string? SkinColor { get; set; }

        public string? Homeworld { get; set; }

        public List<string>? Films { get; set; }

        public List<string>? Species { get; set; }

        public List<string>? Starships { get; set; }

        public List<string>? Vehicles { get; set; }

        public string? Url { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Edited { get; set; }


        public override string ToString()
        {
            return "PersonDto{" +
                        "name='" + Name + '\'' +
                        ", birthYear='" + BirthYear + '\'' +
                        ", eyeColor='" + EyeColor + '\'' +
                        ", gender='" + Gender + '\'' +
                        ", hairColor='" + HairColor + '\'' +
                        ", height='" + Height + '\'' +
                        ", mass='" + Mass + '\'' +
                        ", skinColor='" + SkinColor + '\'' +
                        ", homeworld='" + Homeworld + '\'' +
                        ", films=" + Films +
                        ", species=" + Species +
                        ", starships=" + Starships +
                        ", vehicles=" + Vehicles +
                        ", url='" + Url + '\'' +
                        ", created=" + Created +
                        ", edited=" + Edited +
                    '}';
        }

    }
}
