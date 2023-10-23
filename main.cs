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
        public string tipo;
        public string estado;
        public string descricao;
        public string operador;
        public string cliente;
        public int avaliacao;

        public Assistencia(int ID, string tipo, string estado, string descricao, string operador, string cliente)
        {
            this.ID = ID;
            this.tipo = tipo;
            this.estado = estado;
            this.descricao = descricao;
            this.operador = operador;
            this.cliente = cliente;
        }

        public void avaliar(string novoEstado, int avaliacaoAtendimento)
        {
            estado = novoEstado;
            avaliacao = avaliacaoAtendimento;
            Console.WriteLine($"A assistência com ID {ID} foi alterada para {estado}.\n");
            Console.WriteLine($"Você avaliou em {avaliacao} o atendimento de {operador}.\n");
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
