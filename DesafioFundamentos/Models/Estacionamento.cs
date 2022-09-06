namespace DesafioFundamentos.Models
{
    public class Estacionamento : AutomacaoHora
    {
        private decimal precoInicial = 0.00M;
        private decimal precoPorHora = 0.00M;

        private List<string> veiculos = new List<string>();
        private List<string> datasEntradaVeiculoString = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        
        /*
        Aqui transformei a lista para demilitar o numero de vagas pois o 
        estaconamento tem um numero de vagas limitadas para veiculos e espaço para mais alguns
        outros para dia de eventos e dias atípicos.
        */
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo que esta entrando:");
            string placa = Console.ReadLine();

            veiculos.Add(placa);
            //Limitador de vagas
            if (veiculos.Count < 12)
            {
                Console.WriteLine();
                Console.WriteLine("Há vaga!");

                datasEntradaVeiculoString.Add(DataAtualizadaString());
                
                Console.WriteLine();
                Console.WriteLine($"O veiculo de placa: {veiculos.Last()}\n" + $"Entrou as: {DataAtualizadaString()}");

                //Alerta de capacidade limite prestes a ser atingida
                if (veiculos.Count == 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("ATENÇÃO O PROXIMO VÉCULO IRÁ FICAR NA ÁREA DE TRANSIÇÃO!! TEMOS SÓ MAIS DUAS VAGAS!!!");
                }
                else if (veiculos.Count == 12)
                {
                    Console.WriteLine();
                    Console.WriteLine("ULTIMA VAGA!!!! SE HOUVER FILA PEDIR QUE AGUARDE UM CARRO SAIR!!!!");
                }
                
                Console.WriteLine();
                Console.WriteLine("Solicitar a chave do veiculo para que um dos nossos motoristas o estacione");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Não há mais vaga ):");
            }

        }

        //Metodo para inserir hora manual
        public void RemoverVeiculoManual()
        {   
            Console.WriteLine();
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine();
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = (horas * precoPorHora) + precoInicial;

                Console.WriteLine();
                Console.WriteLine($"O veículo {placa} foi removido \n" + "Preço total foi de: R$ {valorTotal}");

                veiculos.Remove(placa);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        /*
        Remove o veiculo já preenchendo o campo de horas que o veiculo permaneceu estacionado.
        */
        public void RemoverVeiculoAutomatico()
        {
            double valorTotal = 0;
            int tempoEstacionado = 0;

            Console.WriteLine();
            Console.WriteLine("Digite a placa do veículo que esta saindo:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int indexLista = 0;

                /*
                Localizardor de Index do Array, para remover das listas horaEntradaVeiculos e Veiculos.
                */
                for (int contador = 0; contador < veiculos.Count; contador++)
                {
                    if (veiculos[contador].Contains(placa))
                    {
                        indexLista = contador;
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"Entrada: {datasEntradaVeiculoString[indexLista]}");
                Console.WriteLine($"Saída : {DataAtualizadaString()}");

                // Calculo minutos estacionados 
                tempoEstacionado = ConvertendoDataEmMinutos(DataAtualizadaString()) -  ConvertendoDataEmMinutos(datasEntradaVeiculoString[indexLista]);
                Console.WriteLine($"Tempo Hospedagem do veiculo em minutos: {tempoEstacionado}");

                valorTotal = ((tempoEstacionado / 60) * Convert.ToDouble(precoPorHora)) + Convert.ToDouble(precoInicial);

                Console.WriteLine();
                Console.WriteLine($"O veículo {placa} foi removido \n" + $"preço total foi de: R$ {valorTotal.ToString("N2")}");

                veiculos.Remove(veiculos[indexLista]);
                datasEntradaVeiculoString.Remove(datasEntradaVeiculoString[indexLista]);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }  

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                for (int contador = 0; contador < veiculos.Count; contador++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Vaga {contador + 1} veiculo: {veiculos[contador]}\n" + $"Entrada:{datasEntradaVeiculoString[contador]}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
