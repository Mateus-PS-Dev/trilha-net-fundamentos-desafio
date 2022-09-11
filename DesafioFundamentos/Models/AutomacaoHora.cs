namespace DesafioFundamentos.Models
{
    public class AutomacaoHora
    {
        /// <summary>
        /// Uma string que recebe a struct DateTime.Now convertida em string, retorna a mesma string. Assim atualizando o DateTime.Now toda vez que é invocada.
        /// </summary>
        /// <returns>Uma string com data atualizada no momento que o Metodo é invocado.</returns>
        public static string DataAtualizadaString()
        {
            string dataAtualizadaString = Convert.ToString(DateTime.Now);

            return dataAtualizadaString;
        }
        /*
        Metodo para automatização da remoção do veiculo, qual pega o DateTime e transforma em minutos (para melhor visualização do funcionamento do codigo em execução) para depois no Estacionameto.cs converter em horas, para não necessitar inserir a hora com comando manual.
        */
        public static int ConvertendoDataEmMinutos (string dataString)
        {
            List<char> caracteresData = new List<char>();
            string dataAtualizada = DataAtualizadaString(), coletorCaracteres = "";
            int diasParaMinutos = 0, mesesParaMinutos = 0, anosParaMinutos = 0, horasParaMinutos = 0, minutos = 0;

            caracteresData.AddRange(dataString);

            coletorCaracteres = Convert.ToString(caracteresData[0] + caracteresData[1]);
            diasParaMinutos = Convert.ToInt32(coletorCaracteres) * 1440;

            // Implemetar verificador para meses com 30 e 31 dias
            coletorCaracteres = Convert.ToString(caracteresData[3] + caracteresData[4]);
            mesesParaMinutos = Convert.ToInt32(coletorCaracteres) * 43800;

            // Implementar verificador para ano bisiestos
            coletorCaracteres = Convert.ToString(caracteresData[8] + caracteresData[9]);
            anosParaMinutos = Convert.ToInt32(coletorCaracteres) * 525600;

            coletorCaracteres = Convert.ToString(caracteresData[11] + caracteresData[12]);
            horasParaMinutos = Convert.ToInt32(coletorCaracteres) * 60;

            coletorCaracteres = Convert.ToString(caracteresData[14] + caracteresData[15]);
            minutos = Convert.ToInt32(caracteresData[14]) * 10 + Convert.ToInt32(caracteresData[15]);

            minutos += diasParaMinutos + mesesParaMinutos + anosParaMinutos + horasParaMinutos;

            return minutos;
        }
    }
}