using System;

namespace ProjetoPrima.FuncoesDeTratamento
{
    public static class MetodosDeExtensao
    {
        public static int CalcularIdade(this DateTime data)
        {
            int anos = DateTime.Now.Year - data.Year;

            if (DateTime.Now.Month < data.Month || (DateTime.Now.Month == data.Month && DateTime.Now.Day < data.Day))
                anos--;

            return anos;
        }
    }
}
