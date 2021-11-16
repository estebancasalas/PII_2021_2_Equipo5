//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            IHandler buscarPublicacionHandler = new BuscarPublicacionHandler();
            IHandler comienzoHandler = new ComienzoHandler();
            IHandler comprarHandler = new ComprarHandler();
            IHandler crearEmprendedorHandler = new CrearEmprendedorHandler();
            IHandler crearPublicacionHandler = new CrearPublicacionHandler();
            IHandler crearUsuarioHandler = new CrearUsuarioHandler();
            IHandler empresaCantidadTrabajadores = new EmpresaCantidadTrabajadores();
            IHandler finalizarHandler = new FinalizarHandler();
            IHandler historialHandler = new HistorialHandler();
            IHandler invitarHandler = new InvitarHandler();
            IHandler registrarEmpresarioHandler = new RegistrarEmpresarioHandler();

            
            IHandler comienzo = new ComienzoHandler();
            Mensaje mensaje = new Mensaje(0 ,"/start");
            comienzo.Handle(mensaje);


        }
    }
}