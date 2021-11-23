// -----------------------------------------------------------------------
// <copyright file="CrearPublicacionHandler.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler para crear una publicación. Implementa AbstractHandler porque interactúa
    /// con el usuario.
    /// </summary>
    public class CrearPublicacionHandler : AbstractHandler
    {
        private string nombreMaterial;
        private string categoria;

        private string unidad;

        private double costo;

        private double cantidad;

        private string habilitaciones;

        private string titulo;

        private string palabrasClave;

        private string frecuencia;

        private string localizacion;

        /// <summary>
        /// Método que interpreta el mensaje. Si el mensaje es "/CrearPublicación", el método pide los
        /// datos de materiales y llama a la clase CrearMaterial para cumplir con el SRP. Luego, se
        /// llama a la clase CrearPublicacion por la misma razón.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle(Mensaje mensaje)
        {
            ListaEmpresa lista = new ListaEmpresa();
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            if (mensaje.Text.ToLower() == "/crearpublicacion")
            {
                if (lista.Verificar(mensaje.Id))
                {
                    int indice = listaUsuario.Buscar(mensaje.Id);
                    EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;
                    estado.Handler = this;
                    switch (estado.Step)
                    {
                        case 0:
                        Console.WriteLine("Ingrese el material:");
                        estado.Step++;
                        break;

                        case 1:
                        this.nombreMaterial = mensaje.Text;
                        Console.WriteLine("Ingrese la categoria:");
                        estado.Step++;
                        break;

                        case 2:
                        this.categoria = mensaje.Text;
                        Console.WriteLine("Ingrese la unidad con la que cuantifica el material:");
                        estado.Step++;
                        break;

                        case 3:
                        this.unidad = mensaje.Text;
                        Console.WriteLine("Ingrese el precio por unidad:");
                        estado.Step++;
                        break;

                        case 4:
                        this.costo = Convert.ToDouble(mensaje.Text);
                        Console.WriteLine("Ingrese la cantidad:");
                        estado.Step++;
                        break;

                        case 5:
                        this.cantidad = Convert.ToDouble(mensaje.Text);
                        Console.WriteLine("Ingrese habilitaciones necesarias para manipular el material:");
                        estado.Step++;
                        break;

                        case 6:
                        this.habilitaciones = mensaje.Text;
                        estado.Step++;
                        break;

                        case 7:
                        Console.WriteLine("Ingrese el título:");
                        estado.Step++;
                        break;

                        case 8:
                        this.titulo = mensaje.Text;
                        Console.WriteLine("Ingrese palabras claves separadas con ',' : ");
                        estado.Step++;
                        break;

                        case 9:
                        this.palabrasClave = mensaje.Text;
                        Console.WriteLine("Ingrese frequencia de disponibilidad: ");
                        estado.Step++;
                        break;

                        case 10:
                        this.frecuencia = mensaje.Text;
                        Console.WriteLine("Ingrese dónde se encuentra: ");
                        estado.Step++;
                        break;

                        case 11:
                        this.localizacion = mensaje.Text;
                        IUbicacionProvider ubicacionProvider = new UbicacionProvider();
                        IUbicacion ubi = ubicacionProvider.GetUbicacion(this.localizacion);
                        Material material = new Material(this.nombreMaterial, this.costo, this.cantidad, this.unidad, this.habilitaciones, this.categoria);
                        Empresa empresa = Singleton<ListaEmpresa>.Instance.Buscar(mensaje.Id);
                        Publicacion publicacion = new Publicacion(this.titulo, material, this.palabrasClave, this.frecuencia, ubi, empresa);
                        estado = new EstadoUsuario();
                        break;
                    }
                }
                else
                {
                    Output.PrintLine("Para crear publicaciones debe pertenecer a una empresa. Ingrese un comando nuevo:\n");
                }
            }
            else
            {
                this.GetNext().Handle(mensaje);
            }
        }
    }
}