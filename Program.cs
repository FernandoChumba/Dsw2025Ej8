using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{

    class Program
    {
        static void Main()
        {
            // Creando un par de cuentas bancarias
            string[] titulares1 = { "Juan Pérez" };
            string[] titulares2 = { "Ana Gómez" };
            string[] titulares3 = { "Carlos Ruiz" };
            string[] titulares4 = { "Laura Díaz" };
            List<CuentaBancaria> cuentas = new List<CuentaBancaria>
            {
                new CuentaCorriente("CC123", 1000, titulares1, 0.05m) { limiteDeDescubierto = -500 },
                new CuentaCorriente("CC456", 1500, titulares2, 0.03m) { limiteDeDescubierto = -1000 },
                new CajaDeAhorro("CA789", -2000, titulares3) { tasaDeInteres = 0.04m },
                new CajaDeAhorro("CA012", 2500, titulares4) { tasaDeInteres = 0.02m }
            };

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                // Mostrar las cuentas disponibles
                Console.WriteLine("Seleccione una cuenta para operar:");
                for (int i = 0; i < cuentas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Cuenta: {cuentas[i]._numero} - Tipo: {cuentas[i].GetTipo()} - Saldo: ${cuentas[i]._saldo}");
                }

                // Seleccionar una cuenta
                Console.Write("Seleccione una cuenta (1-" + cuentas.Count + "): ");
                int opcionCuenta = Convert.ToInt32(Console.ReadLine()) - 1;
                if (opcionCuenta < 0 || opcionCuenta >= cuentas.Count)
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione una cuenta válida.");
                    continue;
                }

                // Menú de operaciones
                Console.WriteLine("\nMenú de operaciones");
                Console.WriteLine("1. Depósito");
                Console.WriteLine("2. Retiro");
                Console.WriteLine("3. Mostrar saldo");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción (1-4): ");
                string opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            // Depósito
                            Console.Write("Ingrese el monto a depositar: ");
                            decimal montoDeposito = Convert.ToDecimal(Console.ReadLine());
                            cuentas[opcionCuenta].Depositar(montoDeposito);
                            break;

                        case "2":
                            // Retiro
                            Console.Write("Ingrese el monto a retirar: ");
                            decimal montoRetiro = Convert.ToDecimal(Console.ReadLine());
                            cuentas[opcionCuenta].Retirar(montoRetiro);
                            break;

                        case "3":
                            // Mostrar saldo
                            cuentas[opcionCuenta].Mostrar();
                            break;

                        case "4":
                            // Salir
                            continuar = false;
                            Console.WriteLine("Saliendo del programa...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Por favor, ingrese una opción entre 1 y 4.");
                            break;
                    }
                }
                catch (Excepciones.SaldoInsuficiente ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Excepciones.CuentaNoActiva ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Excepciones.MontoNoValido ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Pausa antes de continuar
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

}
