using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFrota.UI.Models.ViewModels
{
    public class BuscaViewModel
    {
        [Required(ErrorMessage = "O campo Chassi é obrigatório", AllowEmptyStrings = false)]
        public String chassi { get; set; }
    }
}
