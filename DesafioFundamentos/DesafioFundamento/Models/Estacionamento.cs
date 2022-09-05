namespace DesafioFundamentos.Models
{
    public class Estacionamento : AutomacaoHora
    {
        private decimal precoInicial = 0.00M;
        private decimal precoPorHora = 0.00M;

        private List<string> veiculos = new List<string>();
        private List<int> horaEntradaVeiculos = new List<int>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        
        /*
        Aqui transformei a listapara demilitar o numero de vagas pois o 
        estaconamento tem um numero de vagas para 50 veiculos e espaço para mais 
        outros 8 para dia de eventos e dias atípicos.
        */
        public void AdicionarVeiculo()
        {
            for (int contador = 0; contador <= veiculos.Count; contador++)
            {   
                //Limitador de vagas
                if (contador < 58)
                {
                    Console.WriteLine("Há vaga!");
                    Console.WriteLine();

                    Console.WriteLine("Digite a placa do veículo que esta entrando:");
                    string placa = Console.ReadLine();

                    veiculos.Add(placa);

                    //Verificador de conteudo da lista
                    if (veiculos[contador] != string.Empty)
                    {
                        horaEntradaVeiculos.Add(ConvertendoStringDataTimeParaInteiro(dataAtualString));

                        Console.WriteLine();
                        Console.WriteLine($" O veiculo de placa: {veiculos[contador]}\n" + $"Entrou as: {dataAtual}");

                        //Alerta de capacidade limitada 
                        if (contador == 50)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ATENÇÃO O PROXIMO VÉCULO IRÁ FICAR NA ÁREA DE TRANSIÇÃO!! TEMOS SÓ MAIS OITO VAGAS!!!");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Solicitar a chave para que nossos motoristas o estacione");

                        break;
                    }  
                }
                //Alerta de capacidade esgotada
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Não há mais vaga ):");

                    break;
                }
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
                Console.WriteLine($" O veículo {placa} foi removido \n" + "preço total foi de: R$ {valorTotal}");

                veiculos.Remove(placa);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }


        public void RemoverVeiculoAutomatico()
        {
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
                Console.WriteLine($"Entrada: {horaEntradaVeiculos[indexLista]}");
                Console.WriteLine($"Saída : {dataAtualString}");

                // Calculo minutos estacionados
                int tempoEstacionado = ConvertendoStringDataTimeParaInteiro(dataAtualString) -  horaEntradaVeiculos[indexLista];

                Console.WriteLine($"Tempo Hospedagem do veiculo em minutos: {tempoEstacionado}");

                decimal valorTotal = ((tempoEstacionado / 60) * precoPorHora) + precoInicial;

                Console.WriteLine();
                Console.WriteLine($"O veículo {placa} foi removido \n" + $"preço total foi de: R$ {valorTotal}");

                veiculos.Remove(veiculos[indexLista]);
                horaEntradaVeiculos.Remove(horaEntradaVeiculos[indexLista]);
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
                    Console.WriteLine($"Vaga {contador + 1} vaiculo: {veiculos[contador]}");
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
