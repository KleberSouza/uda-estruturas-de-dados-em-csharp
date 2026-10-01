using System;
using SistemaClinica.Modelos;

namespace SistemaClinica.Estruturas
{
    /// <summary>
    /// Fila Dinâmica com nó sentinela para controle de atendimento de pacientes (FIFO).
    /// </summary>
    public class FilaDinamica
    {
        private Celula primeiro;
        private Celula ultimo;

        public FilaDinamica()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public bool EstaVazia() => primeiro == ultimo;

        public void Inserir(Paciente x)
        {
            ultimo.prox = new Celula(x);
            ultimo = ultimo.prox;
        }

        public void Enfileirar(Paciente x) => Inserir(x);

        public Paciente Remover()
        {
            if (EstaVazia())
                throw new Exception("Erro ao remover: fila dinâmica vazia!");

            Celula? tmp = primeiro;
            primeiro = primeiro.prox!;
            Paciente elemento = primeiro.elemento!;
            tmp.prox = null;
            tmp = null;
            return elemento;
        }

        public Paciente Desenfileirar() => Remover();

        /// <summary>
        /// Insere no início da fila (logo após a sentinela), utilizado pelo mecanismo de Undo.
        /// </summary>
        public void InserirInicio(Paciente x)
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

        public void Mostrar()
        {
            if (EstaVazia())
            {
                Console.WriteLine("  [ Fila de espera vazia ]");
                return;
            }

            int pos = 1;
            for (Celula? i = primeiro.prox; i != null; i = i.prox)
            {
                Console.WriteLine($"  {pos}º da Fila: {i.elemento}");
                pos++;
            }
        }
    }
}
