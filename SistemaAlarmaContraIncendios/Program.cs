using System;
using FireAlarmCore;
using System.Threading;

namespace SistemaAlarmaIncendios // Sistema de Alarma Contra Incendios UPN
{
    class Program
    {
        static void Main()
        {
            BuildingManager managerEdificio = new BuildingManager(); // Instancia del administrador de edificios para manejar temperaturas
            AlarmManager managerAlarma = new AlarmManager(); // Instancia del administrador de alarmas para manejar la activación de alarmas
            Console.Title = "Sistema de Alarma Contra Incendios UPN"; // Título de la consola
            Console.ForegroundColor = ConsoleColor.Cyan; // Cambiar color de texto a cian
            Console.BackgroundColor = ConsoleColor.Black; // Cambiar color de fondo
            Console.Clear(); // Limpiar la consola para iniciar el sistema

            int[] temps = managerEdificio.InicializarTemperaturas(4); // Inicializar temperaturas de 4 pisos del edificio
            int pisoElegido = 0; // Variable para almacenar el piso seleccionado por el usuario

            while (true) // Bucle principal del sistema
            {
                Console.Clear(); // Limpiar la consola para mostrar el menú principal
                Console.ForegroundColor = ConsoleColor.Cyan; // Cambiar color de texto a cian
                Console.WriteLine("║ SISTEMA DE ALARMA CONTRA INCENDIOS UPN ║"); // Título del sistema
                Console.WriteLine("║========================================║\n"); // Línea divisoria
                Console.WriteLine("║  Seleccione un piso para ver detalles  ║"); // Instrucción para el usuario
                Console.WriteLine("║----------------------------------------║"); // Línea divisoria
                Console.WriteLine("║  Temperaturas actuales:                ║"); // Mostrar las temperaturas actuales de los pisos
                Console.WriteLine("║----------------------------------------║"); // Línea divisoria
                Console.ForegroundColor = ConsoleColor.White; // Cambiar color de texto a blanco
                Console.BackgroundColor = ConsoleColor.Black; // Cambiar color de fondo
                Console.WriteLine("║                                        ║"); // Espacio en blanco para el diseño
                Console.ResetColor(); // Restablecer colores a los predeterminados
                Console.WriteLine("║ Piso  | Temperatura (°C)               ║"); // Encabezado de la tabla de temperaturas
                Console.WriteLine("║----------------------------------------║"); // Línea divisoria

                for (int i = 0; i < temps.Length; i++) // Bucle para mostrar las temperaturas de cada piso
                {
                    string alerta = temps[i] >= 81 ? " [ALERTA!]" : ""; // Mensaje de alerta si la temperatura es igual o superior a 81°C
                    Console.ForegroundColor = temps[i] >= 81 ? ConsoleColor.Red : ConsoleColor.White; // Cambiar color de texto a rojo si hay alerta, blanco si no
                    Console.WriteLine($"║ Piso {i + 1}: {temps[i]}°C{alerta}                          "); // Mostrar el número de piso y su temperatura
                    Console.ResetColor(); // Restablecer colores a los predeterminados
                    Console.WriteLine("║----------------------------------------║"); // Línea divisoria
                }

                Console.Write($"\nSeleccione piso (1-{temps.Length}) o {temps.Length + 1} para salir: "); // Instrucción para el usuario
                string opcion = Console.ReadLine(); // Leer la opción ingresada por el usuario
                Console.ResetColor(); // Restablecer colores a los predeterminados

                if (EsNumero(opcion)) // Validar si la opción ingresada es un número
                {
                    pisoElegido = int.Parse(opcion); // Convertir la opción ingresada a un número entero

                    if (pisoElegido == temps.Length + 1) // Verificar si el usuario desea salir del sistema
                        break; // Salir del bucle si el usuario selecciona la opción de salir

                    if (pisoElegido >= 1 && pisoElegido <= temps.Length) // Verificar si el número de piso ingresado es válido
                    {
                        MostrarDetallePiso(pisoElegido, temps[pisoElegido - 1], managerAlarma); // Mostrar los detalles del piso seleccionado
                    }
                    else // Si el número de piso ingresado no es válido
                    {
                        MostrarError($"Error: Ingrese número entre 1 y {temps.Length}"); // Mostrar mensaje de error
                    }
                }
                else // Si la opcion ingresada no es un numero valido 
                {
                    MostrarError("Error: Ingrese un número válido"); // Mostrar mensaje de error
                }
            }

            Console.Clear(); // Limpiar la consola antes de salir del sistema
            Console.WriteLine(" |----------------------------------------|"); // Línea divisoria
            Console.WriteLine(" | SISTEMA DE ALARMA CONTRA INCENDIOS UPN |"); // Título del sistema
            Console.WriteLine(" |----------------------------------------|"); // Línea divisoria
            Console.WriteLine(" |  Gracias por utilizar la aplicación    |"); // Mensaje de agradecimiento al usuario
            Console.WriteLine(" |----------------------------------------|"); // Línea divisoria
            Console.WriteLine(" |                                        |"); // Espacio en blanco para el diseño
            Console.WriteLine(" |    Universidad Privada del Norte       |"); // Nombre de la universidad
            Console.WriteLine(" |                                        |"); // Espacio en blanco para el diseño
            Console.WriteLine(" | * Curso:                               |"); // Curso del sistema
            Console.WriteLine(" |   - Fundamentos de algoritmos          |"); // Nombre del curso
            Console.WriteLine(" |----------------------------------------|"); // Línea divisoria
            Console.WriteLine("\n Seguro que quiere salir del sistema ?   "); // Pregunta al usuario si desea salir del sistema
            Console.WriteLine("\n Presionar cualquier tecla salir  ...... "); // Instrucción para el usuario
            Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de salir
        }

        static bool EsNumero(string texto) // Método para validar si el texto ingresado es un número
        {
            if (string.IsNullOrWhiteSpace(texto)) return false; // Verificar si el texto está vacío o es nulo
            foreach (char c in texto) // Bucle para verificar cada carácter del texto
            {
                if (!char.IsDigit(c)) return false; // Si algún carácter no es un dígito, retornar false
            }
            return true; // Retornar true si todos los caracteres son dígitos
        }

        static void MostrarDetallePiso(int numPiso, int tempActual, AlarmManager alarma) // Método para mostrar los detalles del piso seleccionado
        {
            Console.Clear(); // Limpiar la consola para mostrar los detalles del piso
            Console.ForegroundColor = ConsoleColor.Red; // Cambiar color de texto a rojo
            Console.BackgroundColor = ConsoleColor.Black; // Cambiar
            Console.WriteLine($"     DETALLES DEL PISO {numPiso}                                                              "); // Título de los detalles del piso
            Console.WriteLine("=============================================================\n"); // Línea divisoria
            Console.WriteLine($"       Temperatura actual: {tempActual}°C                   "); // Mostrar la temperatura actual del piso seleccionado
            Console.WriteLine("=============================================================\n"); // Línea divisoria

            Console.WriteLine("                   ╔══════════════════════╗"); // Dibujar un cuadro para mostrar la temperatura
            Console.WriteLine("                   ║                      ║"); // Espacio en blanco para el diseño
            Console.WriteLine($"                   ║        {tempActual} °C        ║"); // Mostrar la temperatura actual en el cuadro
            Console.WriteLine("                   ║                      ║"); // Espacio en blanco para el diseño
            Console.WriteLine("                   ╚══════════════════════╝"); // Dibujar el borde inferior del cuadro

            if (tempActual >= 81) // Verificar si la temperatura actual es igual o superior a 81°C
            {
                // ACTIVAR LA ALARMA PRIMERO
                alarma.ActivarAlarma(); // Activar la alarma sonora

                Console.ForegroundColor = ConsoleColor.Red; // Cambiar color de texto a rojo
                Console.BackgroundColor = ConsoleColor.Black; // Cambiar
                Console.Clear(); // Limpiar la consola para mostrar la alerta de incendio

                Console.WriteLine("\n===============================================================");
                Console.WriteLine("           ¡ALERTA! TEMPERATURA PELIGROSA!                     "); // Mensaje de alerta de incendio
                Console.WriteLine("===============================================================");
                Console.ResetColor();

                // Simulación de acciones de emergencia

                Console.WriteLine("\nAcciones realizadas:");
                Console.WriteLine("- Activación de alarma sonora");
                Console.WriteLine("- Notificación a personal de seguridad");
                Console.WriteLine("- Bomberos notificados");
                Console.WriteLine("- Evacuación de personas del piso");
                Console.WriteLine("- Evacuación completada");
                Console.WriteLine("- Incendio controlado");

                Console.WriteLine("\nAlarma activada. Personal de seguridad y bomberos notificados.");
                Console.WriteLine("El personal de seguridad y bomberos están en camino para controlar la situación.");
            }
            else // Si la temperatura actual es inferior a 81°C 
            {
                Console.ForegroundColor = ConsoleColor.Green; // Cambiar color de texto a verde
                Console.BackgroundColor = ConsoleColor.Black; // Cambiar color de fondo
                Console.Clear();
                Console.WriteLine("\n=============================================================");
                Console.WriteLine("                     ESTADO NORMAL                             ");
                Console.WriteLine("=============================================================");
                Console.ResetColor();
                Console.WriteLine("\nNo se requiere ninguna acción. La temperatura es segura.");
                Console.WriteLine("El sistema continuará monitoreando las temperaturas de los pisos.");
                Console.WriteLine("Si la temperatura supera los 80°C, se activará la alarma automáticamente.");
            }
            Console.WriteLine("\n=============================================================");
            Console.WriteLine(" Presione cualquier tecla para Volver a ver los pisos...");
            Console.ForegroundColor = ConsoleColor.White; // Cambiar color de texto a blanco
            Console.ResetColor(); // Restablecer colores a los predeterminados
            Console.ReadKey(); // Esperar a que el usuario presione una tecla antes de volver al menú principal
        }

        static void MostrarError(string mensaje) // Método para mostrar mensajes de error

        {

            Console.ForegroundColor = ConsoleColor.Red; // Cambiar color de texto a rojo
            Console.WriteLine(" ║-------------------------------------------║"); // Línea divisoria
            Console.WriteLine(" ║                                           ║"); // Espacio en blanco para el diseño
            Console.WriteLine($" ║\n> {mensaje} porfavor ║"); // Mostrar mensaje de error
            Console.WriteLine(" ║                                           ║"); // Espacio en blanco para el diseño
            Console.WriteLine(" ║-------------------------------------------║"); // Línea divisoria
            Console.ResetColor(); // Restablecer colores a los predeterminados
            System.Threading.Thread.Sleep(1500); // Esperar 1.5 segundos antes de continuar 
            Console.Clear(); // Limpiar la consola después de mostrar el mensaje de error





            Console.ForegroundColor = ConsoleColor.Cyan; // Cambiar color de texto a cian
            Console.WriteLine("║ SISTEMA DE ALARMA CONTRA INCENDIOS UPN ║"); // Título del sistema
            Console.WriteLine("║========================================║\n"); // Línea divisoria
            Console.WriteLine("║  Seleccione un piso para ver detalles  ║"); // Instrucción para el usuario
            Console.WriteLine("║----------------------------------------║"); // Línea divisoria
            Console.WriteLine("║  Temperaturas actuales:                ║"); // Mostrar las temperaturas actuales de los pisos
            Console.WriteLine("║----------------------------------------║"); // Línea divisoria
            Console.ForegroundColor = ConsoleColor.White; // Cambiar color de texto a blanco
            Console.BackgroundColor = ConsoleColor.Black; // Cambiar color de fondo
            Console.WriteLine("║                                        ║"); // Espacio en blanco para el diseño
            Console.ResetColor(); // Restablecer colores a los predeterminados
            Console.WriteLine("║ Piso  | Temperatura (°C)               ║"); // Encabezado de la tabla de temperaturas
            Console.WriteLine("║----------------------------------------║"); // Línea divisoria
            Console.WriteLine("║                                        ║"); // Espacio en blanco para el diseño
            for (int i = 0; i < 4; i++) // Bucle para mostrar las temperaturas de cada piso
            {
                Console.WriteLine($"║ Piso {i + 1}: {new Random().Next(15, 100)}°C                          "); // Mostrar el número de piso y una temperatura aleatoria
                Console.WriteLine("║----------------------------------------║"); // Línea divisoria
            }
            Console.WriteLine("\nSeleccione piso (1-4) o 5 para salir: "); // Instrucción para el usuario


        }
    }
}