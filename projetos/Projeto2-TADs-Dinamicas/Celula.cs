namespace Projeto2_TADs_Dinamicas
{
    /// <summary>
    /// Célula (nó) fundamental para estruturas flexíveis / dinâmicas.
    /// </summary>
    public class Celula
    {
        public int elemento;
        public Celula? prox;

        public Celula() : this(0)
        {
        }

        public Celula(int x)
        {
            this.elemento = x;
            this.prox = null;
        }

        public Celula(int x, Celula? prox)
        {
            this.elemento = x;
            this.prox = prox;
        }
    }
}
