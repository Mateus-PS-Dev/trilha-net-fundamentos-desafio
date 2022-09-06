namespace DesafioFundamentos.Models
{
    public class AtualizacaoDaDataEmTempoReal
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
    }
}