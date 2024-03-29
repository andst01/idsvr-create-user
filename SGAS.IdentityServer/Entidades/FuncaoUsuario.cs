﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGAS.IdSvr.Entidade
{

    public class FuncaoUsuario : IdentityUserRole<int>
    {

       
       // [Column("FNUS_ID_USUARIO")]
        public override int UserId { get; set; }

       // [Column("FNUS_ID_FUNCAO")]
        public override int RoleId { get; set; }

        public Funcao Role { get; set; }

        public Usuario User { get; set; }

        public DateTime DataInicio { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; }

    }
}