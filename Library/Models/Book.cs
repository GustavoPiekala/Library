using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Entities
{
    public class Book
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Título é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O Campo Descrição é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O Campo Ano de Lançamento é obrigatório.")]
        [Range(1900, 2100, ErrorMessage = "Informe um Ano Inválido.")]
        public int ReleaseYear { get; set; }

        
        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "O Campo URL da Imagem é obrigatório.")]
        public string ImgPath { get; set; }

    }
}