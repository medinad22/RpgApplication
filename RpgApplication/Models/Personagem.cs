namespace RpgApplication.Models
{
    public class Personagem
    {

        public int Forca;
        public int Destreza;
        public int Constituicao;
        public int Inteligencia;
        public int Sabedoria;
        public int Carisma;
        public string Nome;

        public Personagem(string nome)
        {
            Random random = new Random();
            this.Nome = nome;
            Destreza = random.Next(1, 20);
            Constituicao = random.Next(1, 20);
            Inteligencia = random.Next(1, 20);
            Sabedoria = random.Next(1, 20);
            Carisma = random.Next(1, 20);
            Forca = random.Next(1, 20);
        }


        public override string ToString()
        {
            return $"Personagem " +
                $"{{ " +
                $"\"nome\": {Nome}, " +
                $"\"forca\": {Forca}," +
                $"\"destreza\": {Destreza}, " +
                $"\"constituicao\": {Constituicao}, " +
                $"\"inteligencia\": {Inteligencia}, " +
                $"\"sabedoria\": {Sabedoria}, " +
                $"\"carisma\": {Carisma} " +
                $"}}";

        }
    }
}
