
namespace _07_ByteBank
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }

        private double _saldo = 100;
        //Por convenção propriedades começam com letra maiuscula e atributos privados iniciam com underscore "_"     

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (_saldo <= valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;
        }

        //Usamos void quando o método/função não retorna nenhum valor.
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
