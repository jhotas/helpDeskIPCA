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
            int escolha;
            // Transformar o processo de escolha em uma função.
            Console.WriteLine(" ||| Helpdesk IPCA ||| ");
            Console.WriteLine("Selecione uma das opções: \n1. Obter assistência\n2. Verificar estado de uma assistência\n" +
                "3. Resolução de problemas\n4. Sair");
            escolha = int.Parse(Console.ReadLine());
            // Limpa o console para facilitar a leitura.
            Console.Clear();

            if (escolha == 1)
            {
                string type, client, description;
                Console.WriteLine("Iremos lhe ajudar em seu problema, primeiro nos diga seu nome: \n");
                client = Console.ReadLine();
                Console.WriteLine($"{client}, em qual tipo de equipamento esta a ter problemas?: \n");
                type = Console.ReadLine();
                Console.WriteLine($"{client}, dê uma descrição de seu problema: \n");
                description = Console.ReadLine();
                Console.WriteLine($"Por favor aguarde, iremos encaminhar a assistência para um de nossos técnicos...");
                // Gera um número aleatório de 4 dígitos para o ID
                Random rnd = new Random();
                // a1 é apenas para testes, não será usado.
                Assistencia a1 = new Assistencia(rnd.Next(1000, 9999), type, "Em progresso", description, "Jean", client, 10);
                imprimirDados(a1);
            }
        }
    }
}
