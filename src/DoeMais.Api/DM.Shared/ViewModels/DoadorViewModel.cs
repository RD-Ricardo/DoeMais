﻿using DM.Domain.Enums;

namespace DM.Shared.ViewModels
{
    public class DoadorViewModel
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public Genero Genero { get; set; }
        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
