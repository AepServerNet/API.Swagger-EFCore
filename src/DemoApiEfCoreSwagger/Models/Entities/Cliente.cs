namespace DemoApiEfCoreSwagger.Models.Entities
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}