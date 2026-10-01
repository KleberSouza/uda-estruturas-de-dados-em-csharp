namespace Projeto3_Lista_Duplamente_Encadeada
{
    /// <summary>
    /// Célula Dupla com referências bidirecionais (ant e prox).
    /// </summary>
    public class CelulaDupla
    {
        public int elemento;
        public CelulaDupla? prox;
        public CelulaDupla? ant;

        public CelulaDupla() : this(0)
        {
        }

        public CelulaDupla(int x)
        {
            this.elemento = x;
            this.prox = this.ant = null;
        }

        public CelulaDupla(int x, CelulaDupla? ant, CelulaDupla? prox)
        {
            this.elemento = x;
            this.ant = ant;
            this.prox = prox;
        }
    }
}
