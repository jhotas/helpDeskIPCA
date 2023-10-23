using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpDeskIPCA
{
    class Assistencia
    {
        public int ID;
        public string type;
        public string state;
        public string description;
        public string technical;
        public string client;
        public int avaliation;

        public Assistencia(int ID, string type, string state, string description, string technical, string client)
        {
            this.ID = ID;
            this.type = type;
            this.state = state;
            this.description = description;
            this.technical = technical;
            this.client = client;
        }

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
        static void Main(string[] args)
        {
            int escolha;
            Console.WriteLine(" ||| Helpdesk IPCA ||| ");
            Console.WriteLine("Selecione uma das opções: \n1. Obter assistência\n2. Verificar estado de uma assistência\n" +
                "3. Resolução de problemas\n4. Sair");
            escolha = int.Parse(Console.ReadLine());
            while (escolha != 4)
            {
                if (escolha == 1)
                {
                    string description;
                    Console.WriteLine("De uma descrição de seu problema: ");
                    description = Console.ReadLine();
                    Assistencia a1 = new Assistencia(32143, "Celular", description, "Jean", "Gabriel");
                }
            }
        }
    }
}
