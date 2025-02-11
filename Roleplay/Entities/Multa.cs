﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roleplay.Entities
{
    public class Multa
    {
        public int Codigo { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public int PersonagemMultado { get; set; }

        [ForeignKey("PersonagemPolicialBD")]
        public int PersonagemPolicial { get; set; }
        public virtual Personagem PersonagemPolicialBD { get; set; }

        public int Valor { get; set; }

        public string Motivo { get; set; }

        public DateTime? DataPagamento { get; set; } = null;

        public string Descricao { get; set; }
    }
}