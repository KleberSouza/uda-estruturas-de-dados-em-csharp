using System;

namespace Projeto1_TADs_Estaticas
{
    /// <summary>
    /// Lista Linear Estática de inteiros baseada em vetor.
    /// </summary>
    public class ListaEstatica
    {
        private int[] array;
        private int n; // Quantidade de elementos inseridos

        /// <summary>
        /// Construtor padrão: inicializa vetor com tamanho 6.
        /// </summary>
        public ListaEstatica() : this(6)
        {
        }

        /// <summary>
        /// Construtor com especificação de capacidade máxima do vetor.
        /// </summary>
        public ListaEstatica(int tamanho)
        {
            array = new int[tamanho];
            n = 0;
        }

        public int ObterTamanho() => n;
        public int tamanho() => n;
        public bool EstaVazia() => n == 0;
        public bool EstaCheia() => n >= array.Length;

        /// <summary>
        /// Insere no início do array deslocando os elementos existentes para a direita.
        /// Conforme algoritmo dos slides: for (int i = n; i > 0; i--) array[i] = array[i-1];
        /// </summary>
        public void InserirInicio(int x)
        {
            if (n >= array.Length)
                throw new Exception("Erro ao inserir: lista cheia!");

            // Desloca elementos para o fim do array
            for (int i = n; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = x;
            n++;
        }

        public void inserirInicio(int x) => InserirInicio(x);

        /// <summary>
        /// Insere no fim do array na posição n. Custo O(1).
        /// Conforme algoritmo dos slides: array[n] = x; n++;
        /// </summary>
        public void InserirFim(int x)
        {
            if (n >= array.Length)
                throw new Exception("Erro ao inserir: lista cheia!");

            array[n] = x;
            n++;
        }

        public void inserirFim(int x) => InserirFim(x);

        /// <summary>
        /// Insere um elemento em uma posição específica, deslocando os elementos à direita.
        /// Conforme algoritmo dos slides: for (int i = n; i > pos; i--) array[i] = array[i-1];
        /// </summary>
        public void Inserir(int x, int pos)
        {
            if (n >= array.Length || pos < 0 || pos > n)
                throw new Exception("Erro ao inserir: posição inválida ou lista cheia!");

            // Desloca elementos para o fim do array
            for (int i = n; i > pos; i--)
            {
                array[i] = array[i - 1];
            }

            array[pos] = x;
            n++;
        }

        public void inserir(int x, int pos) => Inserir(x, pos);

        /// <summary>
        /// Remove o elemento do início do array e desloca os elementos para a esquerda.
        /// Conforme algoritmo dos slides: int resp = array[0]; n--; for (int i = 0; i < n; i++) array[i] = array[i+1];
        /// </summary>
        public int RemoverInicio()
        {
            if (n == 0)
                throw new Exception("Erro ao remover: lista vazia!");

            int resp = array[0];
            n--;

            for (int i = 0; i < n; i++)
            {
                array[i] = array[i + 1];
            }

            return resp;
        }

        public int removerInicio() => RemoverInicio();

        /// <summary>
        /// Remove o elemento do fim do array em tempo constante O(1).
        /// Conforme algoritmo dos slides: return array[--n];
        /// </summary>
        public int RemoverFim()
        {
            if (n == 0)
                throw new Exception("Erro ao remover: lista vazia!");

            return array[--n];
        }

        public int removerFim() => RemoverFim();

        /// <summary>
        /// Remove o elemento de uma posição específica e desloca os elementos para a esquerda.
        /// Conforme algoritmo dos slides: int resp = array[pos]; n--; for (int i = pos; i < n; i++) array[i] = array[i+1];
        /// </summary>
        public int Remover(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
                throw new Exception("Erro ao remover: posição inválida ou lista vazia!");

            int resp = array[pos];
            n--;

            for (int i = pos; i < n; i++)
            {
                array[i] = array[i + 1];
            }

            return resp;
        }

        public int remover(int pos) => Remover(pos);

        /// <summary>
        /// Imprime os elementos da lista linear conforme formato dos slides: [ 3 1 4 7 8 9 ]
        /// </summary>
        public void Mostrar()
        {
            Console.Write("[ ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("]");
        }

        public void mostrar() => Mostrar();
    }
}
