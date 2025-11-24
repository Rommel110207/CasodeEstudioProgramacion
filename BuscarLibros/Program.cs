using System;
using System.Collections.Generic;
using System.Linq;

namespace BuscarLibros
{
    public class Libro
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public override string ToString()
        {
            return $"[{Codigo}], {Titulo} || Autor: {Autor} ({AnioPublicacion}) Categoria {Categoria}";
        }
    }
    class Programa
    {
        static void Main(string[] args)
        {
            List<Libro> biblioteca = IniciarDatos();
            bool next = true;

            while (next)
            {
                Console.Clear();
                Console.WriteLine("°°°Biblioteca Estudiantil°°°");
                Console.WriteLine("1. Buscar por titulo (Lineal)");
                


                switch (Console.ReadLine())
                {
                    case "1":
                        BusquedaLinealTitulo(biblioteca);
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Presione una tecla para continuar...");

                        break;

                }
                if (next)
                {
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }

            }
        }
        static void BusquedaLinealTitulo(List<Libro> libros)
        {
            Console.Write("Ingrese el titulo del libro a buscar: ");
            string objetivo = Console.ReadLine();
            bool encontrado = false;

            foreach (var libro in libros)
            {
                if (libro.Titulo.Equals(objetivo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Libro encontrado:");
                    Console.WriteLine(libro);
                    encontrado = true;

                }
                if (!encontrado)
                {
                    Console.WriteLine("Libro no encontrado.");
                }
            }
        }
        
        static List<Libro> IniciarDatos()
        {
            return new List<Libro>
            {
                new Libro { Codigo = 1, Titulo = "C# Avanzado", Autor = "Juan Perez", AnioPublicacion = 2020, Descripcion = "Un libro avanzado sobre C# y .NET.", Categoria = "Programación" },
                new Libro { Codigo = 2, Titulo = "Introducción a Python", Autor = "Ana Gomez", AnioPublicacion = 2018, Descripcion = "Conceptos básicos de programación en Python.", Categoria = "Programación" },
                new Libro { Codigo = 3, Titulo = "Estructuras de Datos", Autor = "Luis Martinez", AnioPublicacion = 2015, Descripcion = "Análisis de estructuras de datos comunes.", Categoria = "Informática" },
                new Libro { Codigo = 4, Titulo = "Diseño de Algoritmos", Autor = "Maria Rodriguez", AnioPublicacion = 2021, Descripcion = "Técnicas para diseñar algoritmos eficientes.", Categoria = "Informática" },
                new Libro { Codigo = 5, Titulo = "Bases de Datos SQL", Autor = "Carlos Lopez", AnioPublicacion = 2019, Descripcion = "Fundamentos de bases de datos relacionales y SQL.", Categoria = "Bases de Datos" },
                new Libro { Codigo = 6, Titulo = "Desarrollo Web con JavaScript", Autor = "Sofia Hernandez", AnioPublicacion = 2022, Descripcion = "Guía para el desarrollo web utilizando JavaScript.", Categoria = "Desarrollo Web" },
            };
        }



    }
}
