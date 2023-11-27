using System.Runtime.Serialization;

namespace RpgApplication.Models
{
    public class SearchQueryDto
    {
        public int? Forca { get; set; }
        public int? ForcaGt { get; set; }
        public int? ForcaLt { get; set; }
        public int? Destreza { get; set; }
        public int? DestrezaGt { get; set; }
        public int? DestrezaLt { get; set; }
        public int? Constituicao { get; set; }
        public int? ConstituicaoGt { get; set; }
        public int? ConstituicaoLt { get; set; }
        public int? Inteligencia { get; set; }
        public int? InteligenciaGt { get; set; }
        public int? InteligenciaLt { get; set; }
        public int? Sabedoria { get; set; }
        public int? SabedoriaGt { get; set; }
        public int? SabedoriaLt { get; set; }
        public int? Carisma { get; set; }
        public string? Nome { get; set; }

        public SearchQueryDto(int? forca, int? forcaGt, int? forcaLt, int? destreza, int? destrezaGt, int? destrezaLt, int? constituicao, int? constituicaoGt, int? constituicaoLt, int? inteligencia, int? inteligenciaGt, int? inteligenciaLt, int? sabedoria, int? sabedoriaGt, int? sabedoriaLt, int? carisma, string? nome)
        {
            Forca = forca;
            ForcaGt = forcaGt;
            ForcaLt = forcaLt;
            Destreza = destreza;
            DestrezaGt = destrezaGt;
            DestrezaLt = destrezaLt;
            Constituicao = constituicao;
            ConstituicaoGt = constituicaoGt;
            ConstituicaoLt = constituicaoLt;
            Inteligencia = inteligencia;
            InteligenciaGt = inteligenciaGt;
            InteligenciaLt = inteligenciaLt;
            Sabedoria = sabedoria;
            SabedoriaGt = sabedoriaGt;
            SabedoriaLt = sabedoriaLt;
            Carisma = carisma;
            Nome = nome;
        }

        public SearchQueryDto()
        {
        }
    }
}
