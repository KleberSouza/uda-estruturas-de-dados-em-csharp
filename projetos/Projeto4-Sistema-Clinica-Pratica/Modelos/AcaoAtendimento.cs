using System;

namespace SistemaClinica.Modelos
{
    public enum TipoAcao
    {
        ChegadaPaciente,
        ChamadaAtendimento
    }

    public class AcaoAtendimento
    {
        public TipoAcao Tipo { get; set; }
        public Paciente PacienteAfetado { get; set; }
        public string Descricao { get; set; }
        public DateTime Momento { get; set; }

        public AcaoAtendimento(TipoAcao tipo, Paciente paciente, string descricao)
        {
            Tipo = tipo;
            PacienteAfetado = paciente;
            Descricao = descricao;
            Momento = DateTime.Now;
        }
    }
}
