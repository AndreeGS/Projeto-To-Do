﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public string Password { get; set; }

    }
}
