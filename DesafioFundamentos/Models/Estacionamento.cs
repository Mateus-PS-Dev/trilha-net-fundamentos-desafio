namespace DesafioFundamentos.Models
{
    public class Estacionamento : AutomacaoHora
    {
        private decimal precoInicial = 0.00M;
        private decimal precoPorHora = 0.00M;

        // Trabalhando com o Dictionary para aprendizado do metodo, apezar de não ser o melhor tipo de método para esse cenario.
        /*
        O Método Dictinary é tipo de array "não ordenado" tipo uma fila(Queue) ou pilha(Stack). 

        O método tem uma certa ordem de entrada que pode ser utiliza para leitura de um foreach mas não pelo for. 

        Ele tem uma abertura de erro: quando você remove um valor ele deixa aquele espaço "ordenado para leitura" alocado com uma key vazia que não é possível fazer leitura, mas quando você adiciona um novo valor preenche aquele espaço na ordem de leitura.
        */
        private Dictionary<string, string> placaEDataEntrada = new Dictionary<string, string>();
        
        private List<string> chavesVazias = new List<string>()
            {   
                "---VAZIA---", "--=VAZIA=--",
                "--=VAZIA==-", "-==VAZIA=--", 
                "---VAZIA--=", "--=VAZIA---", 
                "---VAZIA-=-", "-==VAZIA==-", 
                "-==VAZIA===", "--=VAZIA--=",
                "--=VAZIA-==", "-==VAZIA--="
            };

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
            // Implementado!!!
            Console.WriteLine("Digite a placa do veículo que esta entrando:");
            string placa = Console.ReadLine().ToUpper();

            if(placaEDataEntrada.Any(x => x.Key == chavesVazias[11]))
            {
                placaEDataEntrada.Remove(chavesVazias[11]);
            }
            
            placaEDataEntrada.Add(chavesVazias[11], DataAtualizadaString());

            // Verificador de Key Vazia ( Criada na RemovendoVeiculo() M/A )
            foreach (var item in placaEDataEntrada)
            {
                if (item.Key.StartsWith("-") && chavesVazias.Any(x => x == item.Key))
                {
                    placaEDataEntrada.Remove(item.Key);
                    placaEDataEntrada.Add(placa, DataAtualizadaString());
                    
                    break;
                }
            }


            //Limitador de vagas
            int limitador = 0;
            int contemVazio = 0;

            foreach (KeyValuePair<string, string> item in placaEDataEntrada)
            {
                if (item.Key != string.Empty)
                {
                    limitador++;
                }

                if (chavesVazias.Any(x => x == item.Key))
                {
                    contemVazio++;
                }
            }

            limitador -= contemVazio;

            if (limitador <= 12)
            {
                Console.WriteLine();
                Console.WriteLine("Há vaga!");

                //v1: datasEntradaVeiculoString.Add(DataAtualizadaString());
                
                Console.WriteLine();
                Console.WriteLine($"O veiculo de placa: {placa}\n" + 
                $"Entrou as: {placaEDataEntrada[placa]}");
                
                //Alerta de capacidade limite prestes a ser atingida
                if (limitador == 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("ATENÇÃO O PROXIMO VÉCULO IRÁ FICAR NA ÁREA DE TRANSIÇÃO!! TEMOS SÓ MAIS DUAS VAGAS!!!");
                }
                else if (limitador == 11)
                {
                    Console.WriteLine();
                    Console.WriteLine("ATENÇÃO O PROXIMO VÉCULO IRÁ FICAR NA ÁREA DE TRANSIÇÃO!! TEMOS SÓ MAIS UMA VAGA!!!");
                }
                // Alerta limite atingido
                else if (limitador == 12)
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
                placaEDataEntrada.Remove(placa);
            }

        }

        //Metodo para inserir hora manual
        public void RemoverVeiculoManual()
        {   
            Console.WriteLine();
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Implementado!!!
            string placa = Console.ReadLine();;

            // Verifica se o veículo existe
            if (placaEDataEntrada.Any(x => x.Key == placa.ToUpper()))
            {
                Console.WriteLine();
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                // Implementado!!!
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (horas * precoPorHora) + precoInicial;

                // Implementado!!!

                /*
                 Cria uma vaga vazia, para a lista de vagas que foram preenchida anteriormente não ficarem vazias e não serem computdas pelo sistema.
                */
                for (int contador = 0; contador < chavesVazias.Count; contador++)
                {
                    if (placaEDataEntrada.Keys.Any(x => x != chavesVazias[contador]))
                    {
                        placaEDataEntrada.Remove(placa);
                        placaEDataEntrada.Add(chavesVazias[contador], "--/--/-- --:--:--");
                        
                        break;
                    }
                    
                }

                Console.WriteLine();
                Console.WriteLine($"O veículo {placa} foi removido \n" + "Preço total foi de: R$ {valorTotal}");
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
            if (placaEDataEntrada.Any(x => x.Key == placa.ToUpper()))
            {
                Console.WriteLine();
                Console.WriteLine($"Entrada: {placaEDataEntrada[placa]}");
                Console.WriteLine($"Saída : {DataAtualizadaString()}");

                // Calculo minutos estacionados 
                tempoEstacionado = 
                ConvertendoDataEmMinutos(DataAtualizadaString()) -
                ConvertendoDataEmMinutos(placaEDataEntrada[placa]);

                Console.WriteLine($"Tempo Hospedagem do veiculo em minutos: {tempoEstacionado}");

                valorTotal = 
                ((tempoEstacionado / 60) * Convert.ToDouble(precoPorHora)) +
                Convert.ToDouble(precoInicial);

                Console.WriteLine();
                Console.WriteLine($"O veículo {placa} foi removido \n" + 
                $"preço total foi de: {valorTotal.ToString("C2")}");

                /*
                 Cria uma vaga vazia, para a lista de vagas que foram preenchida anteriormente não ficarem vazias e não serem computdas pelo sistema.
                */
                List<int> indexsLista = new List<int>();

                foreach (var item in placaEDataEntrada)
                {
                    for (int contador = 0; contador < chavesVazias.Count; contador++)
                    {
                        if (item.Key.StartsWith("-") && chavesVazias[contador] == item.Key)
                        {
                            indexsLista.Add(1);
                        }
                    }
                }

                placaEDataEntrada.Remove(placa);
                placaEDataEntrada.Add(chavesVazias[indexsLista.Count], "--/--/-- --:--:--");
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
            if (placaEDataEntrada.Any())
            {
                int contador = 1;

                Console.WriteLine("Os veículos estacionados são:");
                
                // Implementado!!!
                foreach (KeyValuePair<string, string> item in placaEDataEntrada)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Vaga {contador} veiculo de placa: {item.Key}\n" + 
                    $"Entrada: {item.Value}");

                    contador++;
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
