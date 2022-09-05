namespace DesafioFundamentos.Models
{
    public class AutomacaoHora
    {
        public DateTime dataAtual = DateTime.Now;
        public string dataAtualString = Convert.ToString(DateTime.Now.Hour) + ":" + Convert.ToString(DateTime.Now.Minute);

        /*
        Metodo para automatização da remoção do veiculo, qual pega o DateTime
        da hora e minuto e transforma em minutos, para o não necessitaro dos comandos de entrada.
        */
        public int ConvertendoStringDataTimeParaInteiro(string dataString)
        {
            string coletorDeCaractresHoras = "", coletorDeCaractresMinutos = "";
            int horas = 0, minutos = 0;
            List<char> listaCaracteres = new List<char>();

            listaCaracteres.AddRange(dataAtualString);

            for (int contador = 0; contador < listaCaracteres.Count; contador++)
            {

                if (char.IsNumber(listaCaracteres[contador]))
                {
                    if (coletorDeCaractresHoras.Length < 2)
                    {
                        coletorDeCaractresHoras += listaCaracteres[contador];
                    }
                    else if (coletorDeCaractresHoras.Length >= 2)
                    {
                        coletorDeCaractresMinutos += listaCaracteres[contador];
                    }
                    else if (coletorDeCaractresMinutos.Length >= 2)
                    {
                        break;
                        
                    }
                }
            }
            horas = Convert.ToInt32(coletorDeCaractresHoras);
            minutos = Convert.ToInt32(coletorDeCaractresMinutos);

            minutos += horas * 60;

            return minutos;
        }
    }
}