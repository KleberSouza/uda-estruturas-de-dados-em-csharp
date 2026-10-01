using System;

namespace Projeto2_TADs_Dinamicas
{
    /// <summary>
    /// Fila Dinâmica Flexível com Nó Cabeça (Sentinela).
    /// </summary>
    public class FilaDinamica
    {
        private Celula primeiro;
        private Celula ultimo;

        /// <summary>
        /// Construtor: instancia a célula sentinela ("café com leite").
        /// Conforme slides: primeiro = new Celula(); ultimo = primeiro;
        /// </summary>
        public FilaDinamica()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public bool EstaVazia() => primeiro == ultimo;

        /// <summary>
        /// Insere no fim da fila sem necessidade de if de caso especial. Custo O(1).
        /// Conforme algoritmo dos slides:
        /// ultimo.prox = new Celula(x);
        /// ultimo = ultimo.prox;
        /// </summary>
        public void Inserir(int x)
        {
            ultimo.prox = new Celula(x);
            ultimo = ultimo.prox;
        }

        public void inserir(int x) => Inserir(x);
        public void Enfileirar(int x) => Inserir(x);

        /// <summary>
        /// Remove do início da fila em O(1).
        /// Conforme algoritmo dos slides:
        /// if (primeiro == ultimo) throw new Exception("Erro!");
        /// Celula tmp = primeiro;
        /// primeiro = primeiro.prox;
        /// int elemento = primeiro.elemento;
        /// tmp.prox = null;
        /// tmp = null;
        /// return elemento;
        /// </summary>
        public int Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro ao remover: fila dinâmica vazia!");

            Celula? tmp = primeiro;
            primeiro = primeiro.prox!;
            int elemento = primeiro.elemento;
            tmp.prox = null;
            tmp = null;
            return elemento;
        }

        public int remover() => Remover();
        public int Desenfileirar() => Remover();

        /// <summary>
        /// Retorna o elemento da frente da fila sem remover.
        /// </summary>
        public int Espiar()
        {
            if (EstaVazia())
                throw new Exception("Erro: fila dinâmica vazia!");

            return primeiro.prox!.elemento;
        }

        /// <summary>
        /// Mostra os elementos da fila do início para o fim.
        /// Conforme algoritmo dos slides:
        /// Console.Write("[ ");
        /// for (Celula i = primeiro.prox; i != null; i = i.prox) Console.Write(i.elemento + " ");
        /// Console.WriteLine("]");
        /// </summary>
        public void Mostrar()
        {
            Console.Write("[ ");
            for (Celula? i = primeiro.prox; i != null; i = i.prox)
            {
                Console.Write(i.elemento + " ");
            }
            Console.WriteLine("]");
        }

        public void mostrar() => Mostrar();
    }
}
