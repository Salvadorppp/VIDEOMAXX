﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Videomax
{


    class Program
    {
        static Catalogo catalogo; //NECESITA EL static

        static void Main(string[] args)
        {
            catalogo = new Catalogo();

            int opcion = 0;
            do
            {
                Clear();
                WriteLine("\t\t\t\t\t-----------------------------------");
                WriteLine("\t\t\t\t\t[             VIDEOMAX            ]");
                WriteLine("\t\t\t\t\t-----------------------------------");
                WriteLine("\n\t\t\t\t\tOpciones: ");
                WriteLine("\t\t\t\t\t1. Buscar peliculas");
                WriteLine("\t\t\t\t\t2. Inventario");
                WriteLine("\t\t\t\t\t3. Ventas");
                WriteLine("\t\t\t\t\t0. Salir");

                Write("\n\t\t\t\t\tElige una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 0:
                        WriteLine("\n\t\t\t\t\t¡Gracias por utilizar el programa!");
                        break;

                    case 1:
                        BuscarPeliculas();
                        break;
                    case 2:
                        SubMenuInventario();
                        break;
                    case 3:
                        Ventas();
                        break;
                    default:
                        WriteLine("\n\t\t\t\t\t¡OPCIÓN NO IMPLEMENTADA!");


                        break;
                }
                WriteLine("Presione cualquier tecla para regresar al menú principal");
                WriteLine("Presione 0 para salir del programa");
                ReadKey();
            } while (opcion != 0);

        }


        //Un enumeracion crea un tipo de dato y solo puede tener dichos valores



        static void BuscarPeliculas() //Es static por el main
        {
            Clear();
            WriteLine("\t\t\t\t\t-----------------------------------");
            WriteLine("\t\t\t\t\t[             VIDEOMAX            ]");
            WriteLine("\t\t\t\t\t-----------------------------------");
            WriteLine("\t\t\t\t\t          BUSCAR PELÍCULAS         ");
            WriteLine("\n\t\t\t\t\tOpciones de filtrado: ");
            WriteLine("\t\t\t\t\t1. Todas");
            WriteLine("\t\t\t\t\t2. Por género");
            WriteLine("\t\t\t\t\t3. Por formato");
            WriteLine("\t\t\t\t\t4. Por intervalo de años");

            Write("\n\t\t\t\t\tElige una opción: ");
            OpcionBusqueda opcion = (OpcionBusqueda)Convert.ToInt32(Console.ReadLine()); //Hcemos un casting

            switch (opcion)
            {
                case OpcionBusqueda.Todas: //Esto es para utilizar los valores de la enumeración

                    PrintBusquedaPeliculas(catalogo.FindPeliculas(OpcionBusqueda.Todas));
                    break;

                case OpcionBusqueda.PorGenero:

                    List<Genero> generos = catalogo.GetAllGeneros();
                    PrintGeneros(generos);

                    int generoIndice = Convert.ToInt32(ReadLine());

                    PrintBusquedaPeliculas(catalogo.FindPeliculas(OpcionBusqueda.PorGenero, generos[generoIndice].Id));
                    break;

                case OpcionBusqueda.PorIntervaloDeAños:

                    int añoMinimo = -1;
                    Write("\nDesea especificar un año minimo [s/n]");
                    if (ReadLine().Trim().ToUpper()[0] == 'S')
                    {
                        añoMinimo = Convert.ToInt32(ReadLine());
                    }

                    int añoMaximo = -1;
                    Write("\nDesea especificar un año minimo [s/n]");
                    if (ReadLine().Trim().ToUpper()[0] == 'S')
                    {
                        añoMaximo = Convert.ToInt32(ReadLine());
                    }



                    PrintBusquedaPeliculas(catalogo.FindPeliculas(OpcionBusqueda.PorIntervaloDeAños, añoMinimo: añoMinimo, añoMaximo: añoMaximo));
                    break;

                case OpcionBusqueda.PorFormato:
                    List<Formato> formatos = catalogo.GetAllFormatos();
                    PrintFormatos(formatos);

                    int formatoIndice = Convert.ToInt32(ReadLine());


                    //PrintBusquedaPeliculas(catalogo.FindPeliculas(OpcionBusqueda.PorFormato,"" ,formatos[formatoIndice].Id));
                    PrintBusquedaPeliculas(catalogo.FindPeliculas(OpcionBusqueda.PorFormato, formatoId: formatos[formatoIndice].Id));//OTRA FORMA-POR NOMBRE
                    break;

                default:
                    WriteLine("\n¡OPCIÓN NO IMPLEMENTADA!");

                    break;

            }

        }

        static void PrintBusquedaPeliculas(List<PeliculaEnInventario> peliculas) //Dentro de <> va el tipo de dato de la lista
        {
            WriteLine("\n**** RESULTADO DE BÚSQUEDA ****");

            if (peliculas.Count > 0) //Count es el numero de elementosque hay en la lista
            {
                foreach (PeliculaEnInventario p in peliculas)
                {
                    WriteLine($"{p.Id} - {p.Titulo} - {p.Genero}.({p.Año}).   [VD:{p.DVD}, BR:{p.BlueRay}, UHDBR:{p.UHDBlueRay}].");
                }




            }
            else
            {
                WriteLine(" ¡No se encontraron resultados!");
            }

            ReadKey();


        }
        static void PrintGeneros(List<Genero> generos)
        {

            Clear();
            WriteLine("\n**** GENEROS ****");

            for (int i = 0; i < generos.Count; ++i)
            {
                WriteLine($"{i}. {generos[i].Descripcion}");
            }
        }

        static void PrintFormatos(List<Formato> formatos)
        {

            Clear();
            WriteLine("\n**** GENEROS ****");

            for (int i = 0; i < formatos.Count; ++i)
            {
                WriteLine($"{i}. {formatos[i].Descripcion}");
            }



        }
       
        static void SubMenuInventario()
        {
            catalogo = new Catalogo();

            int opcion = 0;
            do
            {
                Clear();
                WriteLine("\t\t\t\t\t-----------------------------------");
                WriteLine("\t\t\t\t\t[             VIDEOMAX            ]");
                WriteLine("\t\t\t\t\t-----------------------------------");
                WriteLine("\t\t\t\t\t             INVENTARIO            ");
                WriteLine("\n\t\t\t\t\tEliga una opción: ");
                WriteLine("\t\t\t\t\t1. Arribo de unidades");
                WriteLine("\t\t\t\t\t2. Reporte de faltantes");
                WriteLine("\t\t\t\t\t0. Salir");

                Write("\nElige una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {

                    case 0:
                        WriteLine("\n\t\t\t\t\t¡Gracias por utilizar el programa!");
                        break;

                    case 1:

                        WriteLine("Arribo de unidades por medio de (Escriba la letra):");
                        WriteLine(" a) ID de película");
                        WriteLine(" b) Texto o parte del texto");
                        char opcion1 = ReadLine().Trim().ToUpper()[0];
                        
                        if (opcion1 == 'A')
                        {       int peliculaID = -1;
                                Write("Escribe el ID (6 dígitos): ");
                                peliculaID = Convert.ToInt32(ReadLine());
                            if (catalogo.VerifyPelicula(peliculaID))
                            {
                                Pelicula pelicula = catalogo.GetPelicula(peliculaID);
                                
                                SubmenuAgregarInventario();
                               
                                
                            }
                            else
                            {
                                WriteLine("\n ID DE PELICULA INCORRECTO");
                                ReadKey();
                            }
                        }
                        else if (opcion1 == 'B')
                        {
                            
                            WriteLine("Escriba el Titulo de la pelicula o parte de ella: ");
                            string nombrepelicula = ReadLine().Trim().ToUpper();
                            
                            Pelicula titulo = nombrepelicula;
                            
                            if (catalogo.VerifyTitulo(nombrepelicula))
                            {
                                WriteLine("Exist");
                            }

                        }
                         else
                        {
                            WriteLine("nop");
                        }
                        
                        break;


                    case 2:

                        ReadKey();
                        break;
                    default:

                        WriteLine("\n¡OPCIÓN NO IMPLEMENTADA!");
                        ReadKey();
                        break;


                }

            } while (opcion != 0);

        }
        static void Ventas()
        {
            Clear();
            WriteLine("*****LISTADO DE COMPRAS*****");

        }
        static void SubmenuAgregarInventario()
        {
            Pelicula pelicula;
            //Preguntar el formato
            WriteLine("\nEscoge el formato de la prlícula");
            WriteLine("1. DVD \n 2. BlueRay \n 3. hdBlueray");
            int EscogerFormato = Convert.ToInt32(ReadLine());

            switch (EscogerFormato)
            {
                case 1:
                    WriteLine("Cantidad de artículos: "); //preguntar la cantidad 
                    int dvd = Convert.ToInt32(ReadLine());
                    catalogo.AgregarInventario(pelicula, dvd, 0, 0); //Enviar la cantidad 
                    break;
                case 2:
                    WriteLine("Cantidad de artículos: "); //preguntar la cantidad 
                    int blueray = Convert.ToInt32(ReadLine());
                    catalogo.AgregarInventario(pelicula, 0, blueray, 0); //Enviar la cantidad 
                    break;
                case 3:
                    WriteLine("Cantidad de artículos: "); //preguntar la cantidad 
                    int uhdBlueray = Convert.ToInt32(ReadLine());
                    catalogo.AgregarInventario(pelicula, 0, 0, uhdBlueray); //Enviar la cantidad 
                    break;
                default:
                    WriteLine(" FORMATO INVÁLIDO ");
                    ReadKey();
                    break;
            }
        }
    }


}