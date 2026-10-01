using System;

namespace Projeto2_TADs_Dinamicas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("   PROJETO 2: TADs DINÂMICAS / FLEXÍVEIS EM C#                ");
            Console.WriteLine("==============================================================\n");

            // 1. Teste da Lista Simplesmente Encadeada
            Console.WriteLine("--- 1. LISTA SIMPLESMENTE ENCADEADA (com Nó Sentinela) ---");
            ListaEncadeada lista = new ListaEncadeada();
            lista.InserirInicio(1);
            lista.InserirFim(7);
            lista.InserirFim(9);
            lista.InserirInicio(3);
            lista.Inserir(6, 2); // Insere 6 na posição 2
            Console.Write("Lista após inserções: ");
            lista.Mostrar(); // [ 3 1 6 7 9 ]

            Console.WriteLine($"Removido do início: {lista.RemoverInicio()} (esperado: 3)");
            Console.WriteLine($"Removido do fim: {lista.RemoverFim()} (esperado: 9)");
            Console.WriteLine($"Removido da pos 1: {lista.Remover(1)} (esperado: 6)");
            Console.Write("Lista após remoções: ");
            lista.Mostrar(); // [ 1 7 ]

            Console.WriteLine("\nTestando método de inversão da lista simples (exercício dos slides):");
            lista.InserirFim(8);
            lista.InserirFim(10);
            Console.Write("Antes de inverter: ");
            lista.Mostrar(); // [ 1 7 8 10 ]
            lista.Inverter();
            Console.Write("Depois de inverter: ");
            lista.Mostrar(); // [ 10 8 7 1 ]

            // 2. Teste da Fila Dinâmica
            Console.WriteLine("\n--- 2. FILA DINÂMICA (com Nó Sentinela - FIFO) ---");
            FilaDinamica fila = new FilaDinamica();
            fila.Inserir(3);
            fila.Inserir(5);
            fila.Inserir(7);
            Console.Write("Fila após inserções: ");
            fila.Mostrar(); // [ 3 5 7 ]

            Console.WriteLine($"Removido: {fila.Remover()} (esperado: 3)");
            Console.Write("Fila após remoção: ");
            fila.Mostrar(); // [ 5 7 ]

            // 3. Teste da Pilha Dinâmica
            Console.WriteLine("\n--- 3. PILHA DINÂMICA (LIFO) ---");
            PilhaDinamica pilha = new PilhaDinamica();
            pilha.Inserir(3);
            pilha.Inserir(5);
            pilha.Inserir(7);
            Console.Write("Pilha (Topo -> Base): ");
            pilha.Mostrar(); // [ 7 5 3 ]

            Console.WriteLine($"Removido do topo: {pilha.Remover()} (esperado: 7)");
            Console.Write("Pilha após remoção: ");
            pilha.Mostrar(); // [ 5 3 ]

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("   Fim dos Testes do Projeto 2 com Sucesso!");
            Console.WriteLine("==============================================================");
        }
    }
}
