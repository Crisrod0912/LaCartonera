using System.Text.Json.Serialization;

namespace LaCartonera.Web.Models
{
    public class CategoriasModel
    {
        public int? _id { get; set; }

        [JsonPropertyName("Nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("Descripcion")]
        public string? Descripcion { get; set; }

        [JsonPropertyName("Ejemplos")]
        public List<string> Ejemplos { get; set; }
    }
}
