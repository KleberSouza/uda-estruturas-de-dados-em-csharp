using System;

namespace Projeto3_Lista_Duplamente_Encadeada
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("   PROJETO 3: LISTA DUPLAMENTE ENCADEADA EM C#                ");
            Console.WriteLine("==============================================================\n");

            ListaDuplamenteEncadeada lista = new ListaDuplamenteEncadeada();

            Console.WriteLine("--- 1. Inserindo elementos na Lista Dupla ---");
            lista.InserirFim(3);
            lista.InserirFim(5);
            lista.InserirFim(7);
            Console.Write("Lista inicial (3, 5, 7): ");
            lista.Mostrar(); // [ 3 5 7 ]

            Console.WriteLine("\n--- 2. Inserindo 6 na posição 2 (exercício dos slides) ---");
            lista.Inserir(6, 2);
            Console.Write("Lista após Inserir(6, 2): ");
            lista.Mostrar(); // [ 3 5 6 7 ]

            Console.WriteLine("\n--- 3. Navegação Bidirecional ---");
            Console.Write("Ordem Direta:  ");
            lista.MostrarDireto();
            Console.Write("Ordem Inversa: ");
            lista.MostrarReverso();

            Console.WriteLine("\n--- 4. Removendo da posição 1 (exercício dos slides) ---");
            int remPos = lista.Remover(1);
            Console.WriteLine($"Elemento removido da pos 1: {remPos} (esperado: 5)");
            Console.Write("Lista após Remover(1): ");
            lista.Mostrar(); // [ 3 6 7 ]

            Console.WriteLine("\n--- 5. Removendo do Fim em tempo constante O(1) ---");
            int remFim = lista.RemoverFim();
            Console.WriteLine($"Elemento removido do fim: {remFim} (esperado: 7)");
            Console.Write("Lista após RemoverFim: ");
            lista.Mostrar(); // [ 3 6 ]

            Console.WriteLine("\n--- 6. Removendo do Início em tempo constante O(1) ---");
            int remIni = lista.RemoverInicio();
            Console.WriteLine($"Elemento removido do início: {remIni} (esperado: 3)");
            Console.Write("Lista após RemoverInicio: ");
            lista.Mostrar(); // [ 6 ]

            Console.WriteLine("\n--- 7. Inserindo novos elementos e testando Inversão da Lista Dupla ---");
            lista.InserirInicio(1);
            lista.InserirFim(8);
            lista.InserirFim(10);
            Console.Write("Lista antes de inverter: ");
            lista.Mostrar(); // [ 1 6 8 10 ]
            lista.Inverter();
            Console.Write("Lista após inverte():    ");
            lista.Mostrar(); // [ 10 8 6 1 ]

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("   Fim dos Testes do Projeto 3 com Sucesso!");
            Console.WriteLine("==============================================================");
        }
    }
}
