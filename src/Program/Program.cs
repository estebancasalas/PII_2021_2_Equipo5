//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.IO;

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

            .SetNext(new NullHandler()); // bullying a este handler
            Mensaje mensaje = new Mensaje(0, "");

            // Se crean las listas
            ListaAdministradores listaAdministradores = new ListaAdministradores();
            ListaConversaciones listaConversaciones = new ListaConversaciones();
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            ListaEmprendedores listaEmprendedores = new ListaEmprendedores();
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            ListaInvitaciones listaInvitaciones = new ListaInvitaciones();
            ListaTransacciones listaTransacciones = new ListaTransacciones();
            RegistroPublicaciones registroPublicaciones = new RegistroPublicaciones();

            // Se guarda la direccion de las listas en las variables
            string administradores = File.ReadAllText(@"..\..\Datos_json\listaAdministradores.txt");
            string conversaciones = File.ReadAllText(@"..\..\Datos_json\listaConversaciones.txt");
            string usuarios = File.ReadAllText(@"..\..\Datos_json\listaUsuario.txt");
            string emprendedores = File.ReadAllText(@"..\..\Datos_json\listaEmprendedores.txt");
            string empresas = File.ReadAllText(@"..\..\Datos_json\listaEmpresas.txt");
            string invitaciones = File.ReadAllText(@"..\..\Datos_json\listaInvitaciones.txt");
            string transacciones = File.ReadAllText(@"..\..\Datos_json\listaTransacciones.txt");
            string publicaciones = File.ReadAllText(@"..\..\Datos_json\registroPublicaciones.txt");

            // Se cargan las listas con los datos guardados en los json.
            listaAdministradores.LoadFromJson(administradores);
            listaConversaciones.LoadFromJson(conversaciones);
            listaDeUsuario.LoadFromJson(usuarios);
            listaEmprendedores.LoadFromJson(emprendedores);
            listaEmpresa.LoadFromJson(empresas);
            listaInvitaciones.LoadFromJson(invitaciones);
            listaTransacciones.LoadFromJson(transacciones);
            registroPublicaciones.LoadFromJson(publicaciones);
            Administrador admin = new Administrador(1000, "Admin");
            Administrador.CrearInvitacion("Empresa1", "Montevideo", "Vet", "12344321");
            while (mensaje.Text != "/finalizar")
            {
                // Fijarse si estsa registrado y obtener el IUsuario.
                Console.WriteLine("ingrese un mensaje: \n Ingrese /finalizar para salir");
                mensaje.Text = Console.ReadLine();
                comienzoHandler.Handle(mensaje); // EstadoUsuario estado = esto

                // Como ya tenemos el objeto IUsuario, cambiamos su estado por que el nos devolvio el metodo Handle.
            }

            // Se actualizan las listas
            listaAdministradores = new ListaAdministradores();
            listaConversaciones = new ListaConversaciones();
            listaDeUsuario = new ListaDeUsuario();
            listaEmprendedores = new ListaEmprendedores();
            listaEmpresa = new ListaEmpresa();
            listaInvitaciones = new ListaInvitaciones();
            listaTransacciones = new ListaTransacciones();
            registroPublicaciones = new RegistroPublicaciones();

            // Se guardan en los json
            string guardarAdmin = listaAdministradores.ConvertToJson();
            string guardarConv = listaConversaciones.ConvertToJson();
            string guardarUsuario = listaDeUsuario.ConvertToJson();
            string guardarEmprend = listaEmprendedores.ConvertToJson();
            string guardarEmpresa = listaEmpresa.ConvertToJson();
            string guardarInvit = listaInvitaciones.ConvertToJson();
            string guardarTrans = listaTransacciones.ConvertToJson();
            string guardarPubli = registroPublicaciones.ConvertToJson();
            
            // Se guardan en los archivos de texto
            File.WriteAllText(@"..\..\Datos_json\listaAdministradores.txt", guardarAdmin);
            File.WriteAllText(@"..\..\Datos_json\listaConversaciones.txt", guardarConv);
            File.WriteAllText(@"..\..\Datos_json\listaUsuario.txt", guardarUsuario);
            File.WriteAllText(@"..\..\Datos_json\listaEmprendedores.txt", guardarEmprend);
            File.WriteAllText(@"..\..\Datos_json\listaEmpresas.txt", guardarEmpresa);
            File.WriteAllText(@"..\..\Datos_json\listaInvitaciones.txt", guardarInvit);
            File.WriteAllText(@"..\..\Datos_json\listaTransacciones.txt", guardarTrans);
            File.WriteAllText(@"..\..\Datos_json\registroPublicaciones.txt", guardarPubli);
        }
    }
}