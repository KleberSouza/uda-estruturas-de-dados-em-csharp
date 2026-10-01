using System;

namespace SistemaClinica.Modelos
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string QueixaPrincipal { get; set; }
        public DateTime HoraChegada { get; set; }

        public Paciente(int id, string nome, int idade, string queixaPrincipal)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            QueixaPrincipal = queixaPrincipal;
            HoraChegada = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[Senha: {Id:D3}] {Nome}, {Idade} anos — '{QueixaPrincipal}' (Chegada: {HoraChegada:HH:mm:ss})";
        }
    }
}
