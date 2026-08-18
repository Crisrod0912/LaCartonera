using System.Text.Json.Serialization;

namespace LaCartonera.Web.Models
{
    public class ResennasModel
    {
        [JsonPropertyName("_id")]
        public int? _id { get; set; }

        [JsonPropertyName("id_usuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("id_local")]
        public int IdLocal { get; set; }

        [JsonPropertyName("calificacion")]
        public int Calificacion { get; set; }

        [JsonPropertyName("comentario")]
        public string Comentario { get; set; }
    }
}
