using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Handler para crear una publicación. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class CrearPublicacionHandler : AbstractHandler
    {
        string nombreMaterial {get; set;}
        string categoria {get; set;}
        string unidad {get; set;}
        double costo {get; set;}
        double cantidad {get; set;}
        string habilitaciones {get; set;}
        string titulo {get; set;}
        string palabrasClave {get; set;}
        string frecuencia {get; set;}
        string localizacion {get; set;}

        /// <summary>
        /// Método que interpreta el mensaje. Si el mensaje es "/CrearPublicación", el método pide los
        /// datos de materiales y llama a la clase CrearMaterial para cumplir con el SRP. Luego, se
        /// llama a la clase CrearPublicacion por la misma razón.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override string Handle(Mensaje mensaje)
        {
            ListaEmpresa lista = new ListaEmpresa();
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/crearpublicacion")
            {
                if (lista.Verificar(mensaje.Id))
                { 
                    int indice = listaUsuario.Buscar(mensaje.Id);
                    EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
                    estado.handler = this;
                    switch(estado.step)
                    {
                        case 0:
                        Console.WriteLine("Ingrese el material:");
                        estado.step = estado.step + 1;
                        break;
                        
                        case 1: 
                        this.nombreMaterial = mensaje.Text;
                        Console.WriteLine("Ingrese la categoria:");
                        estado.step = estado.step + 1;
                        break;

                        case 2:
                        this.categoria = mensaje.Text;
                        Console.WriteLine("Ingrese la unidad con la que cuantifica el material:");
                        estado.step = estado.step + 1;
                        break;

                        case 3:
                        this.unidad = mensaje.Text;
                        Console.WriteLine("Ingrese el precio por unidad:");
                        estado.step = estado.step + 1;
                        break;

                        case 4:
                        this.costo = Convert.ToDouble(mensaje.Text);
                        Console.WriteLine("Ingrese la cantidad:");
                        estado.step = estado.step + 1;
                        break;

                        case 5:
                        this.cantidad = Convert.ToDouble(mensaje.Text);
                        Console.WriteLine("Ingrese habilitaciones necesarias para manipular el material:");
                        estado.step = estado.step + 1;
                        break;

                        case 6:
                        this.habilitaciones = mensaje.Text;
                        estado.step = estado.step + 1;
                        break;

                        case 7: 
                        Console.WriteLine("Ingrese el título:");
                        estado.step = estado.step + 1;
                        break;

                        case 8:
                        this.titulo = mensaje.Text;
                        Console.WriteLine("Ingrese palabras claves separadas con ',' : ");
                        estado.step = estado.step + 1;
                        break;

                        case 9:
                        this.palabrasClave = mensaje.Text;
                        Console.WriteLine("Ingrese frequencia de disponibilidad: ");
                        estado.step = estado.step + 1;
                        break;

                        case 10:
                        this.frecuencia = mensaje.Text;
                        Console.WriteLine("Ingrese dónde se encuentra: ");
                        estado.step = estado.step + 1;
                        break;

                        case 11:
                        this.localizacion = mensaje.Text;
                        IUbicacionProvider ubicacionProvider = new UbicacionProvider();
                        IUbicacion ubi = ubicacionProvider.GetUbicacion(localizacion);
                        Material material = new Material(nombreMaterial, costo, cantidad, unidad, habilitaciones, categoria); 
                        Empresa empresa = Singleton<ListaEmpresa>.Instance.Buscar(mensaje.Id);
                        Publicacion publicacion = new Publicacion (titulo, material, palabrasClave, frecuencia, ubi, empresa);
                        estado = new EstadoUsuario();
                        break;
                    }
                    return this.TextResult.ToString();
                }
                else
                {
                    Output.PrintLine("Para crear publicaciones debe pertenecer a una empresa. Ingrese un comando nuevo:\n");
                    return this.TextResult.ToString();
                }
            }
            else 
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}