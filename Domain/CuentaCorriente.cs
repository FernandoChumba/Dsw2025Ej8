using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente
    {
        private decimal _comision { get; set; }
        public decimal limiteDeDescubierto { get; set; }

        public CuentaCorriente(string numero, decimal saldo, string[] titulares, decimal comision) :
            base(numero, saldo, titulares)
        {
            _comision = comision;


        }
        public override TipoCuenta GetTipo()
        {
            return TipoCuenta.CuentaCorriente;
        }
        public override void Depositar(decimal monto)
        {
            ValidarOperacion(monto); // Validación de estado y monto

            // Aplicar comisión antes de incrementar el saldo
            monto -= monto * _comision;

            if (monto <= 0)
            {
                throw new Excepciones.MontoNoValido(); // Si después de aplicar la comisión, el monto es no válido
            }

            _saldo += monto;
            Console.WriteLine($"El depósito fue de {monto}. Nuevo saldo: {_saldo}");
        }

        public override void Retirar(decimal monto)
        {
            ValidarOperacion(monto); // Validación de estado y monto

            // Verificar si hay suficiente saldo teniendo en cuenta el límite de descubierto
            if (_saldo - monto < limiteDeDescubierto)
            {
                throw new Excepciones.SaldoInsuficiente(); // Si el saldo es insuficiente
            }

            _saldo -= monto;
            Console.WriteLine($"Se retiró {monto}. Nuevo saldo: {_saldo}");

            // Si el saldo es negativo, se marca la cuenta como suspendida
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
                Console.WriteLine("La cuenta ha sido suspendida debido a saldo insuficiente.");
            }
        }
    }

}

}
