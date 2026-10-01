using System;

namespace Projeto2_TADs_Dinamicas
{
    /// <summary>
    /// Pilha Dinâmica Flexível (LIFO).
    /// </summary>
    public class PilhaDinamica
    {
        private Celula? topo;

        /// <summary>
        /// Construtor: a pilha flexível inicia sem nós e com topo nulo.
        /// Conforme slides: topo = null;
        /// </summary>
        public PilhaDinamica()
        {
            topo = null;
        }

        public bool EstaVazia() => topo == null;

        /// <summary>
        /// Insere no topo da pilha em tempo constante O(1).
        /// Conforme algoritmo dos slides:
        /// Celula tmp = new Celula(x);
        /// tmp.prox = topo;
        /// topo = tmp;
        /// tmp = null;
        /// </summary>
        public void Inserir(int x)
        {
            Celula? tmp = new Celula(x);
            tmp.prox = topo;
            topo = tmp;
            tmp = null;
        }

        public void inserir(int x) => Inserir(x);
        public void Empilhar(int x) => Inserir(x);

        /// <summary>
        /// Remove do topo da pilha em tempo constante O(1).
        /// Conforme algoritmo dos slides:
        /// if (topo == null) throw new Exception("Erro!");
        /// int elemento = topo.elemento;
        /// Celula tmp = topo;
        /// topo = topo.prox;
        /// tmp.prox = null;
        /// tmp = null;
        /// return elemento;
        /// </summary>
        public int Remover()
        {
            if (topo == null)
                throw new Exception("Erro ao remover: pilha dinâmica vazia!");

            int elemento = topo.elemento;
            Celula? tmp = topo;
            topo = topo.prox;
            tmp.prox = null;
            tmp = null;
            return elemento;
        }

        public int remover() => Remover();
        public int Desempilhar() => Remover();

        /// <summary>
        /// Retorna o elemento do topo sem remover.
        /// </summary>
        public int Espiar()
        {
            if (EstaVazia())
                throw new Exception("Erro: pilha dinâmica vazia!");

            return topo!.elemento;
        }

        /// <summary>
        /// Mostra os elementos do topo em direção à base.
        /// Conforme algoritmo dos slides:
        /// Console.Write("[ ");
        /// for (Celula i = topo; i != null; i = i.prox) Console.Write(i.elemento + " ");
        /// Console.WriteLine("]");
        /// </summary>
        public void Mostrar()
        {
            Console.Write("[ ");
            for (Celula? i = topo; i != null; i = i.prox)
            {
                Console.Write(i.elemento + " ");
            }
            Console.WriteLine("]");
        }

        public void mostrar() => Mostrar();
    }
}
