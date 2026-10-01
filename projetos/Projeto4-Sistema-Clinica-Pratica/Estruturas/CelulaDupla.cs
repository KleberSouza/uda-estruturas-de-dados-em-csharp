using SistemaClinica.Modelos;

namespace SistemaClinica.Estruturas
{
    /// <summary>
    /// Representa a célula de encadeamento duplo (nó bidirecional).
    /// Contém o elemento (Paciente) e os ponteiros para a célula anterior (ant) e próxima (prox).
    /// </summary>
    public class CelulaDupla
    {
        public Paciente? elemento;
        public CelulaDupla? ant;
        public CelulaDupla? prox;

        public CelulaDupla(Paciente? elemento, CelulaDupla? ant = null, CelulaDupla? prox = null)
        {
            this.elemento = elemento;
            this.ant = ant;
            this.prox = prox;
        }
    }
}
