using System;
using SistemaClinica.Modelos;
using SistemaClinica.Servicos;

namespace SistemaClinica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GestorAtendimentoClinica clinica = new GestorAtendimentoClinica();

            // Cadastra dados iniciais para demonstração
            clinica.RegistrarChegada("Maria Clara Silveira", 34, "Cefaleia e febre leve");
            clinica.RegistrarChegada("José Antônio da Costa", 68, "Hipertensão e dor no peito");
            clinica.RegistrarChegada("Beatriz Lima Fernandes", 22, "Renovação de receita médica");
            clinica.RegistrarChegada("Carlos Eduardo Santos", 45, "Entorse de tornozelo");

            if (args.Length > 0 && (args[0] == "--simulacao" || args[0] == "-s" || args[0] == "test"))
            {
                ExecutarSimulacaoAutomatica(clinica);
                return;
            }

            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n===============================================================");
                Console.WriteLine("     CLÍNICA SANTA LÚCIA — SISTEMA DE ATENDIMENTO E TRIAGEM   ");
                Console.WriteLine("     (Aplicação Prática com TADs em C#)                       ");
                Console.WriteLine("===============================================================");
                Console.WriteLine($" Painel: {clinica.TotalAtendidos} paciente(s) atendido(s)");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine(" [1] Registrar Chegada de Novo Paciente (Fila FIFO)");
                Console.WriteLine(" [2] Chamar Próximo Paciente para Atendimento");
                Console.WriteLine(" [3] Desfazer Última Chamada (Pilha LIFO - Undo)");
                Console.WriteLine(" [4] Exibir Fila de Espera Atual");
                Console.WriteLine(" [5] Exibir Prontuários dos Pacientes Atendidos (Lista Dupla)");
                Console.WriteLine(" [6] Simulação Automática de Casos de Teste");
                Console.WriteLine(" [0] Encerrar o Sistema");
                Console.WriteLine("---------------------------------------------------------------");
                Console.Write(" Selecione a opção desejada: ");

                string? entrada = Console.ReadLine();
                if (entrada == null) break;
                string opcao = entrada.Trim();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do Paciente: ");
                        string nome = Console.ReadLine() ?? "Paciente Sem Nome";
                        Console.Write("Idade: ");
                        int.TryParse(Console.ReadLine(), out int idade);
                        Console.Write("Queixa Principal / Sintomas: ");
                        string queixa = Console.ReadLine() ?? "Consulta de rotina";

                        Paciente novo = clinica.RegistrarChegada(nome, idade, queixa);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n✓ Paciente registrado na fila de espera com sucesso!");
                        Console.WriteLine($"  {novo}");
                        Console.ResetColor();
                        break;

                    case "2":
                        Paciente? atendido = clinica.ChamarProximo();
                        if (atendido != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\n🔔 CHAMANDO PARA CONSULTÓRIO: {atendido.Nome} (Senha {atendido.Id:D3})");
                            Console.WriteLine($"   Idade: {atendido.Idade} anos | Queixa: {atendido.QueixaPrincipal}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("ℹ Fila vazia: não há pacientes aguardando no momento.");
                            Console.ResetColor();
                        }
                        break;

                    case "3":
                        string msgUndo = clinica.DesfazerUltimaChamada();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\n↺ {msgUndo}");
                        Console.ResetColor();
                        break;

                    case "4":
                        Console.WriteLine("=== FILA DE ESPERA (ORDEM DE CHEGADA) ===");
                        clinica.ExibirFila();
                        break;

                    case "5":
                        Console.WriteLine("=== PRONTUÁRIOS DOS PACIENTES ATENDIDOS ===");
                        Console.WriteLine("--- Ordem Cronológica de Atendimento (Direta) ---");
                        clinica.ExibirAtendidosDireto();
                        Console.WriteLine("\n--- Ordem Inversa (Mais Recentes Primeiro) ---");
                        clinica.ExibirAtendidosReverso();
                        break;

                    case "6":
                        ExecutarSimulacaoAutomatica(clinica);
                        break;

                    case "0":
                        Console.WriteLine("Encerrando o sistema da Clínica Médica. Até logo!");
                        executando = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private static void ExecutarSimulacaoAutomatica(GestorAtendimentoClinica clinica)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- INICIANDO SIMULAÇÃO AUTOMÁTICA DE ATENDIMENTO E UNDO ---");
            Console.ResetColor();

            Console.WriteLine("\n1. Chamando o 1º paciente da fila:");
            var p1 = clinica.ChamarProximo();
            Console.WriteLine($"   Atendido: {p1?.Nome}");

            Console.WriteLine("\n2. Chamando o 2º paciente da fila:");
            var p2 = clinica.ChamarProximo();
            Console.WriteLine($"   Atendido: {p2?.Nome}");

            Console.WriteLine("\n3. Recepcionista percebeu que chamou o 2º paciente por engano. Acionando UNDO:");
            string undo1 = clinica.DesfazerUltimaChamada();
            Console.WriteLine($"   {undo1}");

            Console.WriteLine("\n4. Estado da Fila de Espera após o Undo (o paciente deve estar em 1º lugar):");
            clinica.ExibirFila();

            Console.WriteLine("\n5. Estado dos Prontuários Atendidos:");
            clinica.ExibirAtendidosDireto();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- SIMULAÇÃO CONCLUÍDA COM SUCESSO! ---");
            Console.ResetColor();
        }
    }
}
