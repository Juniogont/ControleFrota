using ControleFrota.MDL.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFrota.UI.Models.ViewModels
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "O campo Chassi é obrigatório", AllowEmptyStrings = false)]
        public String Chassi { get; set; }
        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        public Tipo Tipo { get; set; }
        [Display(Name = "Nº de Passageiros")]
        [Required(ErrorMessage = "O campo Nº de Passageiros é obrigatório", AllowEmptyStrings = false)]
        public byte NumeroPassageiros { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "O campo Cor é obrigatório", AllowEmptyStrings = false)]
        public String Cor { get; set; }
    }
}
