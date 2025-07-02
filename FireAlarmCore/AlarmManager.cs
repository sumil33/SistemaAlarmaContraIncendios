using System;
using System.Threading;

namespace FireAlarmCore
{
    public class AlarmManager // Clase para manejar la activación de alarmas
    {
        public void ActivarAlarma() // Método para activar la alarma
        {

            Console.ForegroundColor = ConsoleColor.Red; // Cambiar color de texto a rojo
            Console.BackgroundColor = ConsoleColor.Black; // Cambiar color de fondo 
            {
                // Secuencia básica de pitidos de alarma
                for (int i = 0; i < 3; i++) // Tres secuencias de pitidos
                {
                    // Pitido agudo
                    Console.Beep(1000, 300); // Frecuencia de 1000 Hz, duración de 300 ms
                    Thread.Sleep(100); // Pausa corta entre pitidos

                    // Pitido medio
                    Console.Beep(800, 300); // Frecuencia de 800 Hz, duración de 300 ms
                    Thread.Sleep(100); // Pausa corta entre pitidos 

                    // Pitido grave
                    Console.Beep(600, 500); // Frecuencia de 600 Hz, duración de 500 ms

                    // Pausa entre secuencias
                    if (i < 2) Thread.Sleep(500); // Pausa de 500 ms entre secuencias
                }
            }
        }
    }
}