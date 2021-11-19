//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.IO;
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
            IHandler comienzoHandler = new ComienzoHandler();
            comienzoHandler.SetNext(new BuscarPublicacionHandler())
                           .SetNext(new ComprarHandler())
                           .SetNext(new CrearEmprendedorHandler())
                           .SetNext(new CrearPublicacionHandler())
                           .SetNext(new EmpresaCantidadTrabajadores())
                           .SetNext(new HistorialHandler())
                           .SetNext(new InvitarHandler())
                           .SetNext(new RegistrarEmpresarioHandler())
            
            .SetNext(new NullHandler()); //bullying a este handler
            Mensaje mensaje = new Mensaje(0 ,"");

            ListaAdminastradores listaAdminastradores = Singleton<ListaAdminastradores>.Instance;
            ListaConversaciones listaConversaciones = Singleton<ListaConversaciones>.Instance;
            ListaDeUsuario listaDeUsuario = Singleton<ListaDeUsuario>.Instance;
            ListaEmprendedores listaEmprendedores = Singleton<ListaEmprendedores>.Instance;
            ListaEmpresa listaEmpresa = Singleton<ListaEmpresa>.Instance;
            ListaInvitaciones listaInvitaciones = Singleton<ListaInvitaciones>.Instance;
            ListaTransacciones listaTransacciones = Singleton<ListaTransacciones>.Instance;
            RegistroPublicaciones registroPublicaciones = Singleton<RegistroPublicaciones>.Instance;

            //string administradores = File.ReadAllText()

            //listaAdminastradores.LoadFromJson()
            while (mensaje.Text != "/finalizar")
            {
                Console.WriteLine("ingrese un mensaje: \n Ingrese /finalizar para salir");
                mensaje.Text = Console.ReadLine();
                comienzoHandler.Handle(mensaje);
            }
        }
    }
}