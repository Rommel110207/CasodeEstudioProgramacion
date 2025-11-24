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
                Console.WriteLine("2. Buscar por autor (Binaria)");
                Console.WriteLine("3. Ver libro mas reciente y mas antiguo");
                Console.WriteLine("4.Buscar coincidencia entre descripciones ");
                Console.WriteLine("5. Ver catalogo completo");
                Console.WriteLine("0. Salir");
                Console.Write("\n Seleccione una opcion: ");


                switch (Console.ReadLine())
                {
                    case "1":
                        BusquedaLinealTitulo(biblioteca);
                        break;
                    case "2":
                        BusquedaBinariaAutor(biblioteca);
                        break;
                    case "3":
                        BuscarExtremos(biblioteca);
                        break;
                    case "4":
                        BusquedaEnDescripcion(biblioteca);
                        break;
                    case "5":
                        ImprimirLista(biblioteca);
                        break;
                    case "0":
                        next = false;
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
        static void BusquedaBinariaAutor(List<Libro> libros)
        {
            List<Libro> librosOrdenados = libros.OrderBy(l => l.Autor).ToList();

            Console.Write("\n Ingrese el autor del libro a buscar: ");
            Console.WriteLine("Ingrese el nombre del libro");
            string objetivo = Console.ReadLine();
            int izquierda = 0;
            int derecha = librosOrdenados.Count - 1;
            bool encontrado = false;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;
                int comparacion = string.Compare(librosOrdenados[medio].Autor, objetivo, StringComparison.OrdinalIgnoreCase);
                if (comparacion == 0)
                {
                    Console.WriteLine("\n Libro encontrado:");
                    Console.WriteLine(librosOrdenados[medio]);
                    encontrado = true;
                    break;
                }
                else if (comparacion < 0)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("\n Libro no encontrado.");
            }


        }
        static void BuscarExtremos(List<Libro> libros)
        {
            if (libros.Count == 0) return;
            Libro masReciente = libros[0];
            Libro masAntiguo = libros[0];

            foreach (var libro in libros)
            {
                if (libro.AnioPublicacion > masReciente.AnioPublicacion)
                {
                    masReciente = libro;
                }
                if (libro.AnioPublicacion < masAntiguo.AnioPublicacion)
                {
                    masAntiguo = libro;
                }
                Console.WriteLine("\n -- Analisis Temporal --");
                Console.WriteLine($"Libro mas reciente: {masReciente}");
                Console.WriteLine($"Libro mas antiguo: {masAntiguo}");

            }

        }
        static void BusquedaEnDescripcion(List<Libro> libros)
        {
            Console.Write("\nIngrese término a buscar en descripciones (ej. 'programación'): ");
            string termino = Console.ReadLine();
            int contador = 0;

            foreach (var libro in libros)
            {
                // Búsqueda manual de subcadena (simulada con IndexOf para simplicidad)
                if (libro.Descripcion.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"- Coincidencia en '{libro.Titulo}': {libro.Descripcion}");
                    contador++;
                }
            }

            if (contador == 0) Console.WriteLine("No hubo coincidencias.");

        }
        static void ImprimirLista(List<Libro> libros)
        {
            Console.WriteLine("\n -- Catalogo Completo --");
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
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