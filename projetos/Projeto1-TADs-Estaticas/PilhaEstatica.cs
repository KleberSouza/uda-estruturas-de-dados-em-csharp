using System;

namespace Projeto1_TADs_Estaticas
{
    /// <summary>
    /// Pilha Estática de inteiros baseada em vetor (LIFO).
    /// </summary>
    public class PilhaEstatica
    {
        private int[] array;
        private int n; // Quantidade de elementos na pilha / topo

        /// <summary>
        /// Construtor padrão: inicializa vetor com capacidade 6.
        /// </summary>
        public PilhaEstatica() : this(6)
        {
        }

        /// <summary>
        /// Construtor com especificação de capacidade máxima do vetor.
        /// </summary>
        public PilhaEstatica(int tamanho)
        {
            array = new int[tamanho];
            n = 0;
        }

        public bool EstaVazia() => n == 0;
        public bool EstaCheia() => n >= array.Length;
        public int ObterTamanho() => n;

        /// <summary>
        /// Empilha um elemento no topo do vetor (InserirFim). Custo O(1).
        /// Conforme algoritmo dos slides:
        /// if (n >= array.Length) throw new Exception("Erro!");
        /// array[n] = x;
        /// n++;
        /// </summary>
        public void Inserir(int x)
        {
            if (n >= array.Length)
                throw new Exception("Erro ao empilhar: pilha cheia!");

            array[n] = x;
            n++;
        }

        public void inserir(int x) => Inserir(x);
        public void Empilhar(int x) => Inserir(x);

        /// <summary>
        /// Desempilha o elemento do topo do vetor (RemoverFim). Custo O(1).
        /// Conforme algoritmo dos slides:
        /// if (n == 0) throw new Exception("Erro!");
        /// return array[--n];
        /// </summary>
        public int Remover()
        {
            if (n == 0)
                throw new Exception("Erro ao desempilhar: pilha vazia!");

            return array[--n];
        }

        public int remover() => Remover();
        public int Desempilhar() => Remover();

        /// <summary>
        /// Retorna o elemento do topo sem desempilhar.
        /// </summary>
        public int Espiar()
        {
            if (n == 0)
                throw new Exception("Erro: pilha vazia!");

            return array[n - 1];
        }

        /// <summary>
        /// Mostra os elementos da pilha do topo para a base.
        /// </summary>
        public void Mostrar()
        {
            Console.Write("[ ");
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("]");
        }

        public void mostrar() => Mostrar();
    }
}
