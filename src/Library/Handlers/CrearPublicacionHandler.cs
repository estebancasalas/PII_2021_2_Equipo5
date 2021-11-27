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
        /// <returns>Retorna la respuesta a la petición del usuario.</returns>
        public override string Handle(Mensaje mensaje)
        {
            ListaEmpresa lista = new ListaEmpresa();
            ListaDeUsuario listaUsuario = new ListaDeUsuario();
            int indice = listaUsuario.Buscar(mensaje.Id);
            EstadoUsuario estado = listaUsuario.ListaUsuarios[indice].Estado;

            if (mensaje.Text.ToLower() == "/crearpublicacion" || estado.Handler == "/crearpublicacion")
            {
                this.TextResult = new StringBuilder();
                if (lista.Verificar(mensaje.Id))
                {
                    this.TextResult = new StringBuilder();
                    estado.Handler = "/crearpublicacion";
                    switch (estado.Step)
                    {
                        case 0:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("Ingrese el material:");
                        estado.Step++;
                        break;

                        case 1:
                        this.TextResult = new StringBuilder();
                        this.nombreMaterial = mensaje.Text;
                        this.TextResult.Append("Ingrese la categoria:");
                        estado.Step++;
                        break;

                        case 2:
                        this.TextResult = new StringBuilder();
                        this.categoria = mensaje.Text;
                        this.TextResult.Append("Ingrese la unidad con la que cuantifica el material:");
                        estado.Step++;
                        break;

                        case 3:
                        this.TextResult = new StringBuilder();
                        this.unidad = mensaje.Text;
                        this.TextResult.Append("Ingrese el precio por unidad:");
                        estado.Step++;
                        break;

                        case 4:
                        this.TextResult = new StringBuilder();
                        this.costo = Convert.ToDouble(mensaje.Text);
                        this.TextResult.Append("Ingrese la cantidad:");
                        estado.Step++;
                        break;

                        case 5:
                        this.TextResult = new StringBuilder();
                        this.cantidad = Convert.ToDouble(mensaje.Text);
                        this.TextResult.Append("Ingrese habilitaciones necesarias para manipular el material:");
                        estado.Step++;
                        break;

                        case 6:
                        this.TextResult = new StringBuilder();
                        this.habilitaciones = mensaje.Text;
                        estado.Step++;
                        break;

                        case 7:
                        this.TextResult = new StringBuilder();
                        this.TextResult.Append("Ingrese el título:");
                        estado.Step++;
                        break;

                        case 8:
                        this.TextResult = new StringBuilder();
                        this.titulo = mensaje.Text;
                        this.TextResult.Append("Ingrese palabras claves separadas con ',' : ");
                        estado.Step++;
                        break;

                        case 9:
                        this.TextResult = new StringBuilder();
                        this.palabrasClave = mensaje.Text;
                        this.TextResult.Append("Ingrese frequencia de disponibilidad: ");
                        estado.Step++;
                        break;

                        case 10:
                        this.TextResult = new StringBuilder();
                        this.frecuencia = mensaje.Text;
                        this.TextResult.Append("Ingrese dónde se encuentra: ");
                        estado.Step++;
                        break;

                        case 11:
                        this.TextResult = new StringBuilder();
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
                    this.TextResult.Append("Para crear publicaciones debe pertenecer a una empresa.");
                }

                return this.TextResult.ToString();
            }
            else
            {
                return this.GetNext().Handle(mensaje);
            }
        }
    }
}