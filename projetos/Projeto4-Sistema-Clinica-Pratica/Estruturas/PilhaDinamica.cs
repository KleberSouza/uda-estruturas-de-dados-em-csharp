using System;
using SistemaClinica.Modelos;

namespace SistemaClinica.Estruturas
{
    /// <summary>
    /// Pilha Dinâmica sem sentinela com ponteiro de topo para histórico de ações e Desfazer (LIFO).
    /// </summary>
    public class PilhaDinamica
    {
        private Celula? topo;

        public PilhaDinamica()
        {
            topo = null;
        }

        public bool EstaVazia() => topo == null;

        public void Inserir(Paciente x)
        {
            Celula? tmp = new Celula(x, topo);
            topo = tmp;
            tmp = null;
        }

        public void Empilhar(Paciente x) => Inserir(x);

        public Paciente Remover()
        {
            if (EstaVazia())
                throw new Exception("Erro ao remover: pilha dinâmica vazia!");

            Paciente elemento = topo!.elemento!;
            Celula? tmp = topo;
            topo = topo.prox;
            tmp.prox = null;
            tmp = null;
            return elemento;
        }

        public Paciente Desempilhar() => Remover();
    }
}
