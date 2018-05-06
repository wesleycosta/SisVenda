using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPrima.Dominio
{
    using FuncoesDeTratamento;

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;

        public int GetIdade() =>
            DataNascimento.CalcularIdade();
    }
}
