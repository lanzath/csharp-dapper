using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    // Associa a classe à tabela User
    // Ao não utilizar este decorator, o dapper tentará associar à "Users"
    [Table("[User]")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
    }
}
