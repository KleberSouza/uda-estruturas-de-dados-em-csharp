using System;

namespace Projeto3_Lista_Duplamente_Encadeada
{
    /// <summary>
    /// Lista Duplamente Encadeada Flexível com Nó Cabeça (Sentinela) e Navegação Bidirecional.
    /// </summary>
    public class ListaDuplamenteEncadeada
    {
        private CelulaDupla primeiro;
        private CelulaDupla ultimo;

        /// <summary>
        /// Construtor: instancia a célula cabeça sentinela ("café com leite").
        /// Conforme slides:
        /// primeiro = new CelulaDupla();
        /// ultimo = primeiro;
        /// </summary>
        public ListaDuplamenteEncadeada()
        {
            primeiro = new CelulaDupla();
            ultimo = primeiro;
        }

        public bool EstaVazia() => primeiro == ultimo;

        /// <summary>
        /// Retorna a quantidade de elementos válidos da lista dupla (após o nó sentinela).
        /// Conforme algoritmo dos slides: for (CelulaDupla i = primeiro.prox; i != null; i = i.prox, tamanho++);
        /// </summary>
        public int Tamanho()
        {
            int tamanho = 0;
            for (CelulaDupla? i = primeiro.prox; i != null; i = i.prox, tamanho++) ;
            return tamanho;
        }

        public int tamanho() => Tamanho();
        public int ObterTamanho() => Tamanho();

        /// <summary>
        /// Insere no início da lista logo após o nó sentinela. Custo O(1).
        /// Conforme algoritmo dos slides:
        /// CelulaDupla tmp = new CelulaDupla(x);
        /// tmp.ant = primeiro;
        /// tmp.prox = primeiro.prox;
        /// primeiro.prox = tmp;
        /// if (primeiro == ultimo) {
        ///     ultimo = tmp;
        /// } else {
        ///     tmp.prox.ant = tmp;
        /// }
        /// tmp = null;
        /// </summary>
        public void InserirInicio(int x)
        {
            CelulaDupla? tmp = new CelulaDupla(x);
            tmp.ant = primeiro;
            tmp.prox = primeiro.prox;
            primeiro.prox = tmp;

            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            else
            {
                tmp.prox!.ant = tmp;
            }

            tmp = null;
        }

        public void inserirInicio(int x) => InserirInicio(x);

        /// <summary>
        /// Insere no fim da lista conectando o novo nó ao ponteiro último. Custo O(1).
        /// Conforme algoritmo dos slides:
        /// ultimo.prox = new CelulaDupla(x);
        /// ultimo.prox.ant = ultimo;
        /// ultimo = ultimo.prox;
        /// </summary>
        public void InserirFim(int x)
        {
            ultimo.prox = new CelulaDupla(x);
            ultimo.prox.ant = ultimo;
            ultimo = ultimo.prox;
        }

        public void inserirFim(int x) => InserirFim(x);

        /// <summary>
        /// Remove o primeiro elemento válido da lista. Custo O(1).
        /// Conforme algoritmo dos slides:
        /// if (primeiro == ultimo) throw new Exception("Erro!");
        /// CelulaDupla tmp = primeiro;
        /// primeiro = primeiro.prox;
        /// int elemento = primeiro.elemento;
        /// tmp.prox = primeiro.ant = null;
        /// tmp = null;
        /// return elemento;
        /// </summary>
        public int RemoverInicio()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro ao remover: lista vazia!");

            CelulaDupla? tmp = primeiro;
            primeiro = primeiro.prox!;
            int elemento = primeiro.elemento;
            tmp.prox = null;
            primeiro.ant = null;
            tmp = null;

            return elemento;
        }

        public int removerInicio() => RemoverInicio();

        /// <summary>
        /// Remove o último nó da lista duplamente encadeada em tempo constante O(1).
        /// Conforme algoritmo dos slides:
        /// if (primeiro == ultimo) throw new Exception("Erro!");
        /// int elemento = ultimo.elemento;
        /// ultimo = ultimo.ant;
        /// ultimo.prox.ant = null;
        /// ultimo.prox = null;
        /// return elemento;
        /// </summary>
        public int RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro ao remover: lista vazia!");

            int elemento = ultimo.elemento;
            ultimo = ultimo.ant!;
            ultimo.prox!.ant = null;
            ultimo.prox = null;

            return elemento;
        }

        public int removerFim() => RemoverFim();

        /// <summary>
        /// Insere em qualquer posição da lista duplamente encadeada. Custo O(n).
        /// Conforme algoritmo dos slides:
        /// if (pos == 0) inserirInicio(x);
        /// else if (pos == tamanho) inserirFim(x);
        /// else {
        ///     CelulaDupla i = primeiro;
        ///     for (int j = 0; j < pos; j++, i = i.prox);
        ///     CelulaDupla tmp = new CelulaDupla(x);
        ///     tmp.ant = i;
        ///     tmp.prox = i.prox;
        ///     tmp.ant.prox = tmp.prox.ant = tmp;
        ///     tmp = i = null;
        /// }
        /// </summary>
        public void Inserir(int x, int pos)
        {
            int tam = Tamanho();
            if (pos < 0 || pos > tam)
            {
                throw new Exception("Erro ao inserir: posição inválida!");
            }
            else if (pos == 0)
            {
                InserirInicio(x);
            }
            else if (pos == tam)
            {
                InserirFim(x);
            }
            else
            {
                CelulaDupla? i = primeiro;
                for (int j = 0; j < pos; j++, i = i!.prox) ;

                CelulaDupla? tmp = new CelulaDupla(x);
                tmp.ant = i;
                tmp.prox = i!.prox;
                tmp.ant!.prox = tmp;
                tmp.prox!.ant = tmp;
                tmp = i = null;
            }
        }

        public void inserir(int x, int pos) => Inserir(x, pos);

        /// <summary>
        /// Remove de qualquer posição da lista duplamente encadeada. Custo O(n).
        /// Conforme algoritmo dos slides:
        /// if (pos == 0) elemento = removerInicio();
        /// else if (pos == tamanho - 1) elemento = removerFim();
        /// else {
        ///     CelulaDupla i = primeiro.prox;
        ///     for (int j = 0; j < pos; j++, i = i.prox);
        ///     i.ant.prox = i.prox;
        ///     i.prox.ant = i.ant;
        ///     elemento = i.elemento;
        ///     i.prox = i.ant = null;
        ///     i = null;
        /// }
        /// </summary>
        public int Remover(int pos)
        {
            int elemento, tam = Tamanho();
            if (primeiro == ultimo || pos < 0 || pos >= tam)
            {
                throw new Exception("Erro ao remover: posição inválida ou lista vazia!");
            }
            else if (pos == 0)
            {
                elemento = RemoverInicio();
            }
            else if (pos == tam - 1)
            {
                elemento = RemoverFim();
            }
            else
            {
                CelulaDupla? i = primeiro.prox;
                for (int j = 0; j < pos; j++, i = i!.prox) ;

                i!.ant!.prox = i.prox;
                i.prox!.ant = i.ant;
                elemento = i.elemento;
                i.prox = null;
                i.ant = null;
                i = null;
            }

            return elemento;
        }

        public int remover(int pos) => Remover(pos);

        /// <summary>
        /// Inverte a ordem dos elementos da lista duplamente encadeada.
        /// Conforme algoritmo exato dos slides (slide 33 de Lista Dupla):
        /// CelulaDupla i = primeiro.prox; CelulaDupla j = ultimo;
        /// while (i != j && j.prox != i) {
        ///     int tmp = i.elemento;
        ///     i.elemento = j.elemento;
        ///     j.elemento = tmp;
        ///     i = i.prox;
        ///     j = j.ant;
        /// }
        /// </summary>
        public void Inverter()
        {
            if (primeiro == ultimo || primeiro.prox == ultimo)
                return;

            CelulaDupla? i = primeiro.prox;
            CelulaDupla? j = ultimo;

            while (i != j && j!.prox != i)
            {
                int tmp = i!.elemento;
                i.elemento = j.elemento;
                j.elemento = tmp;

                i = i.prox;
                j = j.ant;
            }
        }

        public void inverte() => Inverter();

        /// <summary>
        /// Mostra os elementos da lista em ordem direta (do primeiro ao último).
        /// Conforme algoritmo dos slides:
        /// Console.Write("[ ");
        /// for (CelulaDupla i = primeiro.prox; i != null; i = i.prox) Console.Write(i.elemento + " ");
        /// Console.WriteLine("]");
        /// </summary>
        public void Mostrar()
        {
            Console.Write("[ ");
            for (CelulaDupla? i = primeiro.prox; i != null; i = i.prox)
            {
                Console.Write(i.elemento + " ");
            }
            Console.WriteLine("]");
        }

        public void mostrar() => Mostrar();
        public void MostrarDireto() => Mostrar();

        /// <summary>
        /// Mostra os elementos da lista em ordem reversa (do último até a sentinela).
        /// Conforme algoritmo dos slides:
        /// Console.Write("[ ");
        /// for (CelulaDupla i = ultimo; i != primeiro; i = i.ant) Console.Write(i.elemento + " ");
        /// Console.WriteLine("]");
        /// </summary>
        public void MostrarInverso()
        {
            Console.Write("[ ");
            for (CelulaDupla? i = ultimo; i != primeiro; i = i!.ant)
            {
                Console.Write(i!.elemento + " ");
            }
            Console.WriteLine("]");
        }

        public void mostrarInverso() => MostrarInverso();
        public void MostrarReverso() => MostrarInverso();
    }
}
