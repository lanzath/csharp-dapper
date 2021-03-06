using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    // Associa a classe à tabela User
    // Ao não utilizar este decorator, o Dapper tentará associar à "Users"
    [Table("[User]")]
    public class User
    {
        // É uma boa prática iniciar listas no construtor da classe.
        public User() => Roles = new List<Role>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)] // Dapper não incluirá esta propriedade no insert.
        public List<Role> Roles { get; set; }
    }
}
