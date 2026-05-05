namespace backend_autores.Models.DTORequests
{
    public class DTOObraUpdate
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateOnly FechaPublicacion { get; set; }
        public List<int> AutoresIds { get; set; } = new List<int>();
    }
}