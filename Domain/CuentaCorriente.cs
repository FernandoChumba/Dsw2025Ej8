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
    }
}
