using System;

namespace FireAlarmCore
{
    public class BuildingManager // Clase para manejar la inicialización de temperaturas en los pisos del edificio
    {
        Random rand = new Random(); // Generador de números aleatorios para simular temperaturas

        public int[] InicializarTemperaturas(int numPisos) // Método para inicializar las temperaturas de los pisos
        {
            if (numPisos <= 0) // Validación del número de pisos
            {
                Console.WriteLine("Advertencia: Número de pisos no válido. Usando valor por defecto (1 piso)."); // Mensaje de advertencia si el número de pisos es inválido
                numPisos = 1; // Asignar valor por defecto de 1 piso
            }

            int[] temps = new int[numPisos]; // Crear un arreglo para almacenar las temperaturas de cada piso

            for (int i = 0; i < numPisos; i++) // Bucle para asignar una temperatura aleatoria a cada piso
            {
                temps[i] = rand.Next(15, 100); // Generar una temperatura aleatoria entre 15 y 100 grados Celsius
            }
            return temps; // Retornar el arreglo de temperaturas inicializadas
        }
    }
}