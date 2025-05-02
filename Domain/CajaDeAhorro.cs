using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal tasaDeInteres { get; set; }

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
            : base(numero, saldo, titulares)
        //no llamo a tasaDeInteres en constructor
        {


        }
        public override TipoCuenta GetTipo()
        {
            return TipoCuenta.CajaDeAhorro;
        }

        //Excepciones
        public class MontoNoValido : Exception
        {
            public MontoNoValido() : base("El monto recibido no es válido (debe ser mayor a cero") { }
            public MontoNoValido(string message) : base(message) { }
        }
        public class CuentaNoActiva : Exception
        {
            public CuentaNoActiva(String estado) : base($"No se puede operar con la cuenta {estado}.")
            {

            }
        }



        public override void Depositar(decimal monto)
        {
            ValidarOperacion(monto);
            _saldo += monto;
            Console.WriteLine($"El depósito fue de {monto}. Nuevo saldo: {_saldo}");
        }
        public override void Retirar(decimal monto)
        {
            ValidarOperacion(monto);

            // Verifica si hay saldo suficiente
            if (monto > _saldo)
            {
                _estado = Estado.Suspendida;
                Console.WriteLine("La cuenta ha sido suspendida debido a saldo insuficiente.");
                throw new Excepciones.SaldoInsuficiente();
            }

            // Realiza el retiro si hay saldo suficiente
            _saldo -= monto;
            Console.WriteLine($"Se retiró {monto}. Nuevo saldo: {_saldo}");
        }

        public override void AplicarInteres()
        {
            _saldo += _saldo * tasaDeInteres;
        }
    }
}
