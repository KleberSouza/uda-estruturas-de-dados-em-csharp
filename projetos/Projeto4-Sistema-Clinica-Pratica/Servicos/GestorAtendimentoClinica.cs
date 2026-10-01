using System;
using SistemaClinica.Estruturas;
using SistemaClinica.Modelos;

namespace SistemaClinica.Servicos
{
    public class GestorAtendimentoClinica
    {
        private FilaDinamica filaEspera;
        private PilhaDinamica historicoDesfazer;
        private ListaDuplamenteEncadeada pacientesAtendidos;
        private int contadorId;

        public GestorAtendimentoClinica()
        {
            filaEspera = new FilaDinamica();
            historicoDesfazer = new PilhaDinamica();
            pacientesAtendidos = new ListaDuplamenteEncadeada();
            contadorId = 1;
        }

        public int TotalAtendidos => pacientesAtendidos.ObterTamanho();

        public Paciente RegistrarChegada(string nome, int idade, string queixa)
        {
            Paciente novo = new Paciente(contadorId++, nome, idade, queixa);
            filaEspera.Enfileirar(novo);
            return novo;
        }

        public Paciente? ChamarProximo()
        {
            if (filaEspera.EstaVazia())
                return null;

            Paciente atendido = filaEspera.Desenfileirar();
            pacientesAtendidos.InserirFim(atendido);
            historicoDesfazer.Empilhar(atendido);
            return atendido;
        }

        public string DesfazerUltimaChamada()
        {
            if (historicoDesfazer.EstaVazia())
                return "Nenhuma chamada recente para desfazer.";

            Paciente desfeito = historicoDesfazer.Desempilhar();
            pacientesAtendidos.RemoverFim();
            filaEspera.InserirInicio(desfeito);
            return $"[DESFAZER]: Chamada de {desfeito.Nome} cancelada. O paciente retornou para o início da fila de espera!";
        }

        public void ExibirFila() => filaEspera.Mostrar();
        public void ExibirAtendidosDireto() => pacientesAtendidos.Mostrar();
        public void ExibirAtendidosReverso() => pacientesAtendidos.MostrarInverso();
    }
}
