namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public string _numero { get; }
    public decimal _saldo { get; protected set; }

    public Estado _estado { get; protected set; }

    protected string[] _titulares { get; }

    protected CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }

    protected void ValidarOperacion(decimal monto)
    {
        if (_estado != Estado.Activa)
        {
            throw new Excepciones.CuentaNoActiva(_estado.ToString());
        }

        if (monto <= 0)
        {
            throw new Excepciones.MontoNoValido();
        }
    }



    public abstract TipoCuenta GetTipo();

    public abstract void Depositar(decimal monto);


    public abstract void Retirar(decimal monto);

    public virtual void AplicarInteres()
    {
        // Solo la CajaDeAhorro implementa interés
    }
    public void Mostrar()
    {
        Console.WriteLine($"Cuenta : {_numero} - Saldo:${_saldo}");
    }
}
