using System;

namespace Projeto2_TADs_Dinamicas
{
    /// <summary>
    /// Lista Simplesmente Encadeada Flexível com Nó Cabeça (Sentinela).
    /// </summary>
    public class ListaEncadeada
    {
        private Celula primeiro;
        private Celula ultimo;

        /// <summary>
        /// Construtor: instancia a célula cabeça sentinela ("café com leite").
        /// Conforme slides: primeiro = new Celula(); ultimo = primeiro;
        /// </summary>
        public ListaEncadeada()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public bool EstaVazia() => primeiro == ultimo;

        /// <summary>
        /// Retorna a quantidade de elementos válidos da lista (após o nó sentinela).
        /// Conforme algoritmo dos slides: for (Celula i = primeiro.prox; i != null; i = i.prox, tamanho++);
        /// </summary>
        public int Tamanho()
        {
            int tamanho = 0;
            for (Celula? i = primeiro.prox; i != null; i = i.prox, tamanho++) ;
            return tamanho;
        }

        public int tamanho() => Tamanho();
        public int ObterTamanho() => Tamanho();

        /// <summary>
        /// Insere no início da lista (imediatamente após a sentinela). Custo O(1).
        /// Conforme algoritmo dos slides:
        /// Celula tmp = new Celula(x);
        /// tmp.prox = primeiro.prox;
        /// primeiro.prox = tmp;
        /// if (primeiro == ultimo) { ultimo = tmp; }
        /// tmp = null;
        /// </summary>
        public void InserirInicio(int x)
        {
            Celula? tmp = new Celula(x);
            tmp.prox = primeiro.prox;
            primeiro.prox = tmp;
            if (primeiro == ultimo)
            {
                ultimo = tmp;
            }
            tmp = null;
        }

        public void inserirInicio(int x) => InserirInicio(x);

        /// <summary>
        /// Insere no fim da lista conectando a nova célula a ultimo.prox. Custo O(1).
        /// Conforme algoritmo dos slides:
        /// ultimo.prox = new Celula(x);
        /// ultimo = ultimo.prox;
        /// </summary>
        public void InserirFim(int x)
        {
            ultimo.prox = new Celula(x);
            ultimo = ultimo.prox;
        }

        public void inserirFim(int x) => InserirFim(x);

        /// <summary>
        /// Insere um elemento em uma posição específica (0 até Tamanho). Custo O(n).
        /// Conforme algoritmo dos slides:
        /// if (pos == 0) inserirInicio(x);
        /// else if (pos == tamanho) inserirFim(x);
        /// else { ... }
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
                Celula? i = primeiro;
                for (int j = 0; j < pos; j++, i = i!.prox) ;

                Celula? tmp = new Celula(x);
                tmp.prox = i!.prox;
                i.prox = tmp;
                tmp = i = null;
            }
        }

        public void inserir(int x, int pos) => Inserir(x, pos);

        /// <summary>
        /// Remove o primeiro elemento válido da lista. Custo O(1).
        /// Conforme algoritmo dos slides:
        /// Celula tmp = primeiro;
        /// primeiro = primeiro.prox;
        /// int elemento = primeiro.elemento;
        /// tmp.prox = null;
        /// tmp = null;
        /// return elemento;
        /// </summary>
        public int RemoverInicio()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro ao remover: lista vazia!");

            Celula? tmp = primeiro;
            primeiro = primeiro.prox!;
            int elemento = primeiro.elemento;
            tmp.prox = null;
            tmp = null;
            return elemento;
        }

        public int removerInicio() => RemoverInicio();

        /// <summary>
        /// Remove o último elemento da lista caminhando até o penúltimo nó. Custo O(n).
        /// Conforme algoritmo dos slides:
        /// for (i = primeiro; i.prox != ultimo; i = i.prox);
        /// int elemento = ultimo.elemento;
        /// ultimo = i;
        /// i = ultimo.prox = null;
        /// return elemento;
        /// </summary>
        public int RemoverFim()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro ao remover: lista vazia!");

            Celula? i;
            for (i = primeiro; i!.prox != ultimo; i = i.prox) ;

            int elemento = ultimo.elemento;
            ultimo = i;
            ultimo.prox = null;
            i = null;
            return elemento;
        }

        public int removerFim() => RemoverFim();

        /// <summary>
        /// Remove o elemento de uma posição específica (0 até Tamanho - 1). Custo O(n).
        /// Conforme algoritmo dos slides:
        /// if (pos == 0) elemento = removerInicio();
        /// else if (pos == tamanho - 1) elemento = removerFim();
        /// else { ... }
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
                Celula? i = primeiro;
                for (int j = 0; j < pos; j++, i = i!.prox) ;

                Celula? tmp = i!.prox;
                elemento = tmp!.elemento;
                i.prox = tmp.prox;
                tmp.prox = null;
                i = tmp = null;
            }
            return elemento;
        }

        public int remover(int pos) => Remover(pos);

        /// <summary>
        /// Inverte a ordem dos elementos da lista simples.
        /// Conforme exercício resolvido no slide (slide 35 de Lista Dupla / Lista Simples):
        /// Celula i = primeiro.prox; Celula j = ultimo; Celula k;
        /// while (i != j && j.prox != i) { swap(i, j); ... }
        /// </summary>
        public void Inverter()
        {
            if (primeiro == ultimo || primeiro.prox == ultimo)
                return;

            Celula? i = primeiro.prox;
            Celula? j = ultimo;
            Celula? k;

            while (i != j && j!.prox != i)
            {
                int tmp = i!.elemento;
                i.elemento = j.elemento;
                j.elemento = tmp;

                i = i.prox;
                for (k = primeiro; k!.prox != j; k = k.prox) ;
                j = k;
            }
        }

        public void inverte() => Inverter();

        /// <summary>
        /// Pesquisa se um número está contido na lista.
        /// </summary>
        public bool Pesquisar(int x)
        {
            for (Celula? i = primeiro.prox; i != null; i = i.prox)
            {
                if (i.elemento == x)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Imprime todos os elementos válidos da lista (após o nó cabeça).
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
