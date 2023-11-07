using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Todas as variáveis devem ser criadas em INGLÊS.
namespace helpDeskIPCA
{
    class Assistencia
    {
        // Variáveis da assistência
        public int ID;
        public string type;
        public string state;
        public string description;
        public string technical;
        public string client;
        public int avaliation;

        public Assistencia(int ID, string type, string state, string description, string technical, string client, int avaliation)
        {
            // Atribuindo valores às variáveis
            this.ID = ID;
            this.type = type;
            this.state = state;
            this.description = description;
            this.technical = technical;
            this.client = client;
            this.avaliation = avaliation;
        }

        // Método para o cliente avaliar o atendimento
        public void avaliar(string newState, int avaliateAssistance)
        {
            state = newState;
            avaliation = avaliateAssistance;
            Console.WriteLine($"A assistência com ID {ID} foi alterada para {state}.\n");
            Console.WriteLine($"Você avaliou em {avaliation} o atendimento de {technical}.\n");
        }
    }

    class main
    {
        static void imprimirDados(Assistencia n)
        {
            Console.WriteLine($"Assistência {n.ID}:\n"); 
            Console.WriteLine($"Tipo: {n.type}\n");
            Console.WriteLine($"Estado: {n.state}\n");
            Console.WriteLine($"Descrição: {n.description}\n");
            Console.WriteLine($"Técnico responsável: {n.technical}\n");
            Console.WriteLine($"Cliente: {n.client}\n");
            Console.WriteLine($"Avaliação: {n.avaliation}\n");
        }

        static void Main(string[] args)
        {
            int choice;
            // Transformar o processo de escolha em uma função.
            Console.WriteLine(" ||| Helpdesk IPCA ||| ");
            Console.WriteLine("Selecione uma das opções: \n1. Obter assistência\n2. Verificar estado de uma assistência\n" +
                "3. Resolução de problemas\n4. Sair");
            choice = int.Parse(Console.ReadLine());
            // Limpa o console para facilitar a leitura.
            Console.Clear();

            if (choice == 1)
            {
                string type, client, description;
                Console.WriteLine("Iremos lhe ajudar em seu problema, primeiro nos diga seu nome: \n");
                client = Console.ReadLine();
                Console.WriteLine($"{client}, em qual tipo de equipamento esta a ter problemas?: \n");
                type = Console.ReadLine();
                Console.WriteLine($"{client}, dê uma descrição de seu problema: \n");
                description = Console.ReadLine();
                Console.WriteLine($"Por favor aguarde, iremos encaminhar a assistência para um de nossos técnicos...");
                Thread.Sleep(5000);
                // Gera um número aleatório de 4 dígitos para o ID
                Random rnd = new Random();
                // a1 é apenas para testes, não será usado.
                Assistencia a1 = new Assistencia(rnd.Next(1000, 9999), type, "Em progresso", description, "Jean", client, 10);
                imprimirDados(a1);
            } 
            else if (choice == 2)
            {
                int number;

                Console.WriteLine("Digite o ID de sua assistência: ");
                number = int.Parse(Console.ReadLine());
                
                
            }
            else if (choice == 3)
            {
                int x;

                Console.WriteLine("1. Computador\n2. Telemóvel\n3. Impressora\n4. Outro dispositivo");
                x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 1: // Tutoriais para computador
                        
                        break;
                    case 2: // Tutoriais para telemóvel
                        Console.WriteLine("1. Como Reiniciar um Smartphone\n2. Limpar o Cache de Aplicativos\n" +
                            "3. Liberar Espaço de Armazenamento\n5. Problemas de Conexão Wi-Fi ou Dados Móveis\n6. Problemas de Som");
                        break;
                    case 3: // Tutoriais para impressora
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.WriteLine("");
                        break;
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Agradecemos o contacto, estamos aqui sempre que precisar de ajuda!\n");
                Environment.Exit(0);
            }
        }
    }
}
