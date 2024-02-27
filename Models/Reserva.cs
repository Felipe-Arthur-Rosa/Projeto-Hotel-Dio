namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool capacidadeValida = hospedes.Count <= Suite.Capacidade;
            if (capacidadeValida)
            {
                Hospedes = hospedes;
            }
            else
            {
              throw new Exception("A quantidade de hóspedes excede a capacidade da suíte");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes != null)
            {
                return Hospedes.Count;
            }
        throw new Exception("Nenhum hóspede cadastrado");
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor;

            bool recebeDesconto = DiasReservados >= 10;
            if (recebeDesconto)
            {
                Suite.ValorDiaria = Suite.ValorDiaria * 0.9m;
                valor = DiasReservados * Suite.ValorDiaria;
                return valor;
            }
            valor = DiasReservados * Suite.ValorDiaria;
            return valor;
        }
    }
}