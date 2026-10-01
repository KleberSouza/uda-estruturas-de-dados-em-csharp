using System;

namespace Projeto1_TADs_Estaticas
{
    /// <summary>
    /// Fila Estática Circular de inteiros baseada em vetor (FIFO).
    /// </summary>
    public class FilaCircularEstatica
    {
        private int[] array;
        private int primeiro;
        private int ultimo;

        /// <summary>
        /// Construtor padrão: inicializa fila circular com capacidade útil de 5 elementos.
        /// </summary>
        public FilaCircularEstatica() : this(5)
        {
        }

        /// <summary>
        /// Construtor com tamanho especificado. Aloca array de tamanho + 1 para a posição de controle.
        /// </summary>
        public FilaCircularEstatica(int tamanho)
        {
            array = new int[tamanho + 1];
            primeiro = ultimo = 0;
        }

        public bool EstaVazia() => primeiro == ultimo;
        public bool EstaCheia() => ((ultimo + 1) % array.Length) == primeiro;

        /// <summary>
        /// Insere elemento no fim da fila circular.
        /// Conforme algoritmo dos slides:
        /// if (((ultimo + 1) % array.Length) == primeiro) throw new Exception("Erro!");
        /// array[ultimo] = x;
        /// ultimo = (ultimo + 1) % array.Length;
        /// </summary>
        public void Inserir(int x)
        {
            if (((ultimo + 1) % array.Length) == primeiro)
                throw new Exception("Erro ao inserir: fila circular cheia!");

            array[ultimo] = x;
            ultimo = (ultimo + 1) % array.Length;
        }

        public void inserir(int x) => Inserir(x);
        public void Enfileirar(int x) => Inserir(x);

        /// <summary>
        /// Remove elemento do início da fila circular.
        /// Conforme algoritmo dos slides:
        /// if (primeiro == ultimo) throw new Exception("Erro!");
        /// int resp = array[primeiro];
        /// primeiro = (primeiro + 1) % array.Length;
        /// return resp;
        /// </summary>
        public int Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro ao remover: fila circular vazia!");

            int resp = array[primeiro];
            primeiro = (primeiro + 1) % array.Length;
            return resp;
        }

        public int remover() => Remover();
        public int Desenfileirar() => Remover();

        /// <summary>
        /// Imprime os elementos da fila circular do primeiro até o último.
        /// Conforme algoritmo dos slides:
        /// int i = primeiro;
        /// while (i != ultimo) { Console.Write(array[i] + " "); i = (i + 1) % array.Length; }
        /// </summary>
        public void Mostrar()
        {
            Console.Write("[ ");
            int i = primeiro;
            while (i != ultimo)
            {
                Console.Write(array[i] + " ");
                i = (i + 1) % array.Length;
            }
            Console.WriteLine("]");
        }

        public void mostrar() => Mostrar();
    }
}
