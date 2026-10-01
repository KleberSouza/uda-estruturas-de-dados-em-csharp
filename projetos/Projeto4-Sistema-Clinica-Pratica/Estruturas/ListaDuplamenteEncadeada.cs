using System;
using SistemaClinica.Modelos;

namespace SistemaClinica.Estruturas
{
    /// <summary>
    /// Lista Duplamente Encadeada para o registro e prontuário de atendimentos do dia.
    /// </summary>
    public class ListaDuplamenteEncadeada
    {
        private CelulaDupla? primeiro;
        private CelulaDupla? ultimo;
        private int tamanho;

        public ListaDuplamenteEncadeada()
        {
            primeiro = null;
            ultimo = null;
            tamanho = 0;
        }

        public int ObterTamanho() => tamanho;
        public bool EstaVazia() => tamanho == 0;

        public void InserirFim(Paciente x)
        {
            if (EstaVazia())
            {
                CelulaDupla tmp = new CelulaDupla(x);
                primeiro = tmp;
                ultimo = tmp;
            }
            else
            {
                CelulaDupla tmp = new CelulaDupla(x, ultimo, null);
                ultimo!.prox = tmp;
                ultimo = tmp;
            }
            tamanho++;
        }

        public Paciente RemoverFim()
        {
            if (EstaVazia())
                throw new Exception("Erro ao remover: lista vazia!");

            Paciente elemento = ultimo!.elemento!;

            if (tamanho == 1)
            {
                primeiro = null;
                ultimo = null;
            }
            else
            {
                ultimo = ultimo.ant;
                ultimo!.prox = null;
            }

            tamanho--;
            return elemento;
        }

        public void Mostrar()
        {
            if (EstaVazia())
            {
                Console.WriteLine("  [ Nenhum paciente atendido no histórico ]");
                return;
            }

            int pos = 1;
            for (CelulaDupla? i = primeiro; i != null; i = i.prox)
            {
                Console.WriteLine($"  {pos}º Atendido: {i.elemento}");
                pos++;
            }
        }

        public void MostrarInverso()
        {
            if (EstaVazia())
            {
                Console.WriteLine("  [ Nenhum paciente atendido no histórico ]");
                return;
            }

            int pos = 1;
            for (CelulaDupla? i = ultimo; i != null; i = i.ant)
            {
                Console.WriteLine($"  Último #{pos}: {i.elemento}");
                pos++;
            }
        }
    }
}
