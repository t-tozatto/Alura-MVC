﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alura_MVC.Models
{
    public class Cadastro : BaseModel
    {
        public virtual List<Pedido> Pedido { get; set; }

        [Required]
        public string Nome { get; set; } = "";
        
        [Required]
        public string Email { get; set; } = "";
        
        [Required]
        public string Telefone { get; set; } = "";
        
        [Required]
        public string Endereco { get; set; } = "";
        
        [Required]
        public string Complemento { get; set; } = "";
        
        [Required]
        public string Bairro { get; set; } = "";
        
        [Required]
        public string Municipio { get; set; } = "";
        
        [Required]
        public string UF { get; set; } = "";
        
        [Required]
        public string CEP { get; set; } = "";

        public Cadastro()
        {
        }

    }
}
