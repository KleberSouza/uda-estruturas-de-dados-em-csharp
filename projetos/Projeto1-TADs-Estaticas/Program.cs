using System;

namespace Projeto1_TADs_Estaticas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("==============================================================");
            Console.WriteLine("   PROJETO 1: TADs LINEARES ESTÁTICAS EM C# (VETORES)        ");
            Console.WriteLine("==============================================================\n");

            // 1. Teste da Lista Estática
            Console.WriteLine("--- 1. LISTA LINEAR (Slide Exemplo: I(1), IF(7), IF(9), II(3), I(8,3), I(4,2)) ---");
            ListaEstatica lista = new ListaEstatica(6);
            lista.InserirInicio(1);
            lista.InserirFim(7);
            lista.InserirFim(9);
            lista.InserirInicio(3);
            lista.Inserir(8, 3);
            lista.Inserir(4, 2);
            Console.Write("Lista após inserções: ");
            lista.Mostrar(); // [ 3 1 4 7 8 9 ]

            Console.WriteLine("\nExecutando remoções do slide (removerInicio, removerFim, remover(2)):");
            int x1 = lista.RemoverInicio(); // 3
            int x2 = lista.RemoverFim();    // 9
            int x3 = lista.Remover(2);       // 7
            Console.WriteLine($"Elementos removidos: {x1}, {x2}, {x3}");
            Console.Write("Lista final: ");
            lista.Mostrar(); // [ 1 4 8 ]

            // 2. Teste da Fila Circular Estática
            Console.WriteLine("\n--- 2. FILA CIRCULAR (Slide Exemplo: I(1), I(3), I(5), I(7), I(9), R(), R(), I(4)...) ---");
            FilaCircularEstatica fila = new FilaCircularEstatica(5);
            fila.Inserir(1);
            fila.Inserir(3);
            fila.Inserir(5);
            fila.Inserir(7);
            fila.Inserir(9);
            Console.Write("Fila cheia: ");
            fila.Mostrar();

            Console.WriteLine($"Removido: {fila.Remover()} (esperado: 1)");
            Console.WriteLine($"Removido: {fila.Remover()} (esperado: 3)");
            fila.Inserir(4);
            fila.Inserir(6);
            Console.Write("Fila após remoções e novas inserções circulares: ");
            fila.Mostrar();

            // 3. Teste da Pilha Estática
            Console.WriteLine("\n--- 3. PILHA ESTÁTICA (Slide Exemplo: IF e RF) ---");
            PilhaEstatica pilha = new PilhaEstatica(6);
            pilha.Inserir(1);
            pilha.Inserir(3);
            pilha.Inserir(5);
            pilha.Inserir(7);
            Console.Write("Pilha: ");
            pilha.Mostrar(); // [ 7 5 3 1 ]

            Console.WriteLine($"Removido do topo: {pilha.Remover()} (esperado: 7)");
            Console.WriteLine($"Removido do topo: {pilha.Remover()} (esperado: 5)");
            Console.Write("Pilha final: ");
            pilha.Mostrar(); // [ 3 1 ]

            Console.WriteLine("\n==============================================================");
            Console.WriteLine("   Fim dos Testes do Projeto 1 com Sucesso!");
            Console.WriteLine("==============================================================");
        }
    }
}
