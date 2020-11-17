using ControleFrota.MDL.Enumeradores;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFrota.MDL.Models
{
    public class Veiculo
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

        public Veiculo(string chassi, Tipo tipo, byte numeroPassageiros, string cor)
        {
            Chassi = chassi;
            Tipo = tipo;
            if (Tipo == Tipo.Caminhao)
            {
                if (numeroPassageiros != 2)
                    throw new InvalidOperationException("O Número de passageiros de um caminhão deve ser 2");
                else
                    NumeroPassageiros = numeroPassageiros;
            }
            else if (Tipo == Tipo.Onibus)
            {
                if (numeroPassageiros != 42)
                    throw new InvalidOperationException("O Número de passageiros de um caminhão deve ser 2");
                else
                    NumeroPassageiros = numeroPassageiros;
            }
            Cor = cor;
        }

        public void SetCor(string cor)
        {
            Cor = cor;
        }
        
    }
}
