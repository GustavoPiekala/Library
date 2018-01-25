using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Category
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Nome é obrigatório.")]
        public string Name { get; set; }

    }
}