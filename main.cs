using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HelpDeskIPCA
{
    [Serializable]
    class Assistance 
    {
        public int ID;
        public string Type;
        public string State;
        public string Description;
        public string Technical;
        public string Client;
        public int? Avaliation;

        public Assistance(int ID, string type, string state, string description, string technical, string client, int? avaliation)
        {
            this.ID = ID;
            this.Type = type;
            this.State = state;
            this.Description = description;
            this.Technical = technical;
            this.Client = client;
            this.Avaliation = avaliation;
        }
    }

    class Program
    {
        static List<Assistance> assistances = new List<Assistance>();

        static void PrintAssistance(Assistance n)
        {
            Console.WriteLine($"Assistência {n.ID}:\n");
            Console.WriteLine($"Tipo: {n.Type}\n");
            Console.WriteLine($"Estado: {n.State}\n");
            Console.WriteLine($"Descrição: {n.Description}\n");
            Console.WriteLine($"Técnico Responsável: {n.Technical}\n");
            Console.WriteLine($"Cliente: {n.Client}\n");

            if (n.State == "Concluído" && n.Avaliation.HasValue)
            {
                Console.WriteLine($"Avaliação: {n.Avaliation}\n");
            }
        }

        //static void UpdateAssistanceState()
        //{
        //    if (assistances.Count >= 3 && assistances[0].State == "Em progresso")
        //    {
        //        assistances[0].State = "Concluído";
        //        Console.ReadLine();
        //        Console.Clear();
        //        Console.WriteLine($"{assistances[0].Client}, por favor, nos dê sua avaliação do atendimento em uma escala de 1 a 10");
        //        assistances[0].Avaliation = int.Parse(Console.ReadLine());
        //    }
        //    if (assistances.Count >= 4 && assistances[1].State == "Em progresso")
        //    {
        //        assistances[1].State = "Concluído";
        //        Console.WriteLine($"{assistances[1].Client}, por favor, nos dê sua avaliação do atendimento em uma escala de 1 a 10");
        //        assistances[1].Avaliation = int.Parse(Console.ReadLine());
        //    }
        //    if (assistances.Count >= 5 && assistances[2].State == "Em progresso")
        //    {
        //        assistances[2].State = "Concluído";
        //        Console.WriteLine($"{assistances[2].Client}, por favor, nos dê sua avaliação do atendimento em uma escala de 1 a 10");
        //        assistances[2].Avaliation = int.Parse(Console.ReadLine());
        //    }
        //    if (assistances.Count >= 6 && assistances[3].State == "Em progresso")
        //    {
        //        assistances[3].State = "Concluído";
        //        Console.WriteLine($"{assistances[3].Client}, por favor, nos dê sua avaliação do atendimento em uma escala de 1 a 10");
        //        assistances[3].Avaliation = int.Parse(Console.ReadLine());
        //    }
        //}

        static void SaveAssistancesToFile()
        {
            try
            {
                using (FileStream fs = new FileStream("assistances.dat", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, assistances);
                }
                Console.WriteLine("Assistências salvas com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar assistências: {ex.Message}");
            }
        }

        static void LoadAssistancesFromFile()
        {
            try
            {
                if (File.Exists("assistances.dat"))
                {
                    using (FileStream fs = new FileStream("assistances.dat", FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        assistances = (List<Assistance>)formatter.Deserialize(fs);
                    }
                    Console.WriteLine("Assistências carregadas com sucesso!");
                }
                else
                {
                    Console.WriteLine("Arquivo de assistências não encontrado. Criando um novo arquivo...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar assistências: {ex.Message}");
            }
        }

        static void ChangeAssistanceState(int assistanceId)
        {
            Assistance selectedAssistance = assistances.Find(a => a.ID == assistanceId);

            if (selectedAssistance != null)
            {
                Console.WriteLine($"A assistência {selectedAssistance.ID} está atualmente no estado: {selectedAssistance.State}");
                Console.WriteLine("Deseja marcar a assistência como 'Concluída'? (S/N)");

                if (Console.ReadLine().ToUpper() == "S")
                {
                    selectedAssistance.State = "Concluída";

                    if (GiveRating(selectedAssistance))
                    {
                        Console.WriteLine($"{selectedAssistance.Client}, por favor, nos dê sua avaliação do atendimento em uma escala de 1 a 10");
                        selectedAssistance.Avaliation = int.Parse(Console.ReadLine()); 
                    }

                    Console.WriteLine($"A assistência {selectedAssistance.ID} foi marcada como 'Concluída'.");
                    RemoveCompletedAssistance();
                }
            }
            else
            {
                Console.WriteLine("Assistência não encontrada.");
            }
        }

        static void RemoveCompletedAssistance()
        {
            assistances.RemoveAll(a => a.State == "Concluída");
            Console.WriteLine("Assistências concluídas removidas da lista.");
        }   

        static bool GiveRating(Assistance assistance)
        {
            // Verifica se o cliente já forneceu uma avaliação
            return assistance.State == "Concluído" && !assistance.Avaliation.HasValue;
        }

        static void Main(string[] args)
        {
            LoadAssistancesFromFile();
            int choice = 0;

            while (choice != 4)
            {
                Console.Clear();
                Console.WriteLine("\n| H   H  EEEEE  L      PPPPP   DDDD   EEEEE  SSSSS  K   K       III   PPPPP  CCCC  AAAAA |");
                Console.WriteLine(@"| H   H  E      L      P   P   D   D  E        S    K  K         I    P   P C      A   A |");
                Console.WriteLine(@"| HHHHH  EEEE   L      PPPPP   D   D  EEEE     SSS  KKK          I    PPPP  C      AAAAA |");
                Console.WriteLine(@"| H   H  E      L      P       D   D  E           S K  K         I    P     C      A   A |");
                Console.WriteLine("| H   H  EEEEE  LLLLL  P       DDDD   EEEEE  SSSSS  K   K       III   P     CCCC   A   A |\n");

                Console.WriteLine("Selecione uma das opções: \n1. Solicitar assistência\n2. Verificar estado da assistência\n" +
                    "3. Resolução de problemas\n4. Sair");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            string type, client, description;
                            Console.WriteLine("Informe seu nome: ");
                            client = Console.ReadLine();
                            Console.WriteLine($"{client}, em qual tipo de equipamento está tendo problemas?: ");
                            type = Console.ReadLine();
                            Console.WriteLine($"{client}, forneça uma descrição do problema: ");
                            description = Console.ReadLine();
                            Random rnd = new Random();
                            Assistance newAssistance = new Assistance(rnd.Next(1000, 9999), type, "Em progresso", description, "Jean", client, null);
                            Console.Clear();
                            PrintAssistance(newAssistance);
                            assistances.Add(newAssistance);
                            // UpdateAssistanceState();
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("ID's disponíveis:");
                            foreach (var assistance in assistances)
                            {
                                Console.WriteLine($"ID: {assistance.ID}");
                            }
                            Console.WriteLine("Digite o ID de sua assistência: ");
                            int number;
                            if (int.TryParse(Console.ReadLine(), out number))
                            {
                                Assistance selectedAssistance = assistances.Find(a => a.ID == number);
                                Console.Clear();
                                if (selectedAssistance != null)
                                {
                                    PrintAssistance(selectedAssistance);
                                    ChangeAssistanceState(number);

                                    if (GiveRating(selectedAssistance))
                                    {
                                        Console.WriteLine($"{selectedAssistance.Client}, por favor, nos dê sua avaliação do atendimento em uma escala de 1 a 10");
                                        selectedAssistance.Avaliation = int.Parse(Console.ReadLine());
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Assistência não encontrada.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Digite um número válido.");
                            }
                            Console.ReadLine();
                            break;

                        case 3:
                            int x;
                            Console.WriteLine("1. Computador\n2. Telemóvel\n3. Impressora\n4. Outro dispositivo");
                            x = int.Parse(Console.ReadLine());

                            switch (x)
                            {
                                case 1:
                                    Console.WriteLine("Tente desligar e ligar, caso o problema persista, obtenha assistência");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.WriteLine("Coloque o telemóvel no arroz, caso o problema persista, obtenha assistência");
                                    Console.ReadLine();
                                    break;

                                case 3:
                                    Console.WriteLine("Verifique se os papéis estão nos lugares certos e bata na lateral, caso o problema persista, obtenha assistência");
                                    Console.ReadLine();
                                    break;

                                case 4:
                                    Console.WriteLine("Coloque seu dispositivo em uma bacia com água fervente, depois de 3 minutos, troque por uma bacia com água fria, caso o problema persista, obtenha assistência");
                                    Console.ReadLine();
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número válido.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Agradecemos o contato, estamos aqui sempre que precisar de ajuda!\n");
            SaveAssistancesToFile();
        }
    }
}