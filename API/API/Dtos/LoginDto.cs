namespace API.Dtos
{
    public record LoginDto
    { 
        public string email { get; set; }
        public string password { get; set; }
    }
}
