using SistemaClinica.Modelos;

namespace SistemaClinica.Estruturas
{
    /// <summary>
    /// Representa a célula (nó) simples de encadeamento dinâmico.
    /// Contém o elemento (Paciente) e o ponteiro para a próxima célula (prox).
    /// </summary>
    public class Celula
    {
        public Paciente? elemento;
        public Celula? prox;

        // Construtor vazio: essencial para o Nó Sentinela ("café com leite")
        public Celula()
        {
            this.elemento = null;
            this.prox = null;
        }

        // Construtor com elemento
        public Celula(Paciente? elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }

        // Construtor com elemento e próximo nó
        public Celula(Paciente? elemento, Celula? prox)
        {
            this.elemento = elemento;
            this.prox = prox;
        }
    }
}
