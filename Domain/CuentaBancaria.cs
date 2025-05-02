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

}
