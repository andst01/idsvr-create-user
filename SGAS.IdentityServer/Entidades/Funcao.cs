﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGAS.IdSvr.Entidade
{
    
    public  class Funcao : IdentityRole<int>
    {
        public override int Id { get; set; }

        public override string Name { get; set; }


        [NotMapped]
        public virtual ICollection<FuncaoUsuario> FuncoesUsuarios { get; set; }

    }
}