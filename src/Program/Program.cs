//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.IO;

using Telegram.Bot;
using Telegram.Bot.Args;

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

        public static IHandler ComienzoHandler = new ComienzoHandler();

        public static void Main()
        {
            ComienzoHandler.SetNext(new BuscarPublicacionHandler())
                           .SetNext(new ComprarHandler())
                           .SetNext(new CrearEmprendedorHandler())
                           .SetNext(new CrearPublicacionHandler())
                           .SetNext(new EmpresaCantidadTrabajadores())
                           .SetNext(new HistorialHandler())
                           .SetNext(new InvitarHandler())
                           .SetNext(new RegistrarEmpresarioHandler())
            .SetNext(new NullHandler()); //bullying a este handler
            Mensaje mensaje = new Mensaje(0 ,"");

            // Se crean las listas
            ListaAdministradores listaAdministradores = new ListaAdministradores();
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            ListaEmprendedores listaEmprendedores = new ListaEmprendedores();
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            ListaInvitaciones listaInvitaciones = new ListaInvitaciones();
            ListaTransacciones listaTransacciones = new ListaTransacciones();
            RegistroPublicaciones registroPublicaciones = new RegistroPublicaciones();

            // Se guarda la direccion de las listas en las variables
            string administradores = File.ReadAllText(@"..\..\Datos_json\listaAdministradores.txt");
            string usuarios = File.ReadAllText(@"..\..\Datos_json\listaUsuario.txt");
            string emprendedores = File.ReadAllText(@"..\..\Datos_json\listaEmprendedores.txt");
            string empresas = File.ReadAllText(@"..\..\Datos_json\listaEmpresas.txt");
            string invitaciones = File.ReadAllText(@"..\..\Datos_json\listaInvitaciones.txt");
            string transacciones = File.ReadAllText(@"..\..\Datos_json\listaTransacciones.txt");
            string publicaciones = File.ReadAllText(@"..\..\Datos_json\registroPublicaciones.txt");

            // Se cargan las listas con los datos guardados en los json.
            listaAdministradores.LoadFromJson(administradores);
            listaDeUsuario.LoadFromJson(usuarios);
            listaEmprendedores.LoadFromJson(emprendedores);
            listaEmpresa.LoadFromJson(empresas);
            listaInvitaciones.LoadFromJson(invitaciones);
            listaTransacciones.LoadFromJson(transacciones);
            registroPublicaciones.LoadFromJson(publicaciones);

            // Obtengo una instancia de TelegramBot
            TelegramBot telegramBot = TelegramBot.Instance;
            Console.WriteLine($"Hola soy el Bot de P2, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");

            // Obtengo el cliente de Telegram
            ITelegramBotClient bot = telegramBot.Client;

            // Asigno un gestor de mensajes
            bot.OnMessage += OnMessage;

            // Inicio la escucha de mensajes
            bot.StartReceiving();

            Console.WriteLine("Presiona una tecla para terminar");
            Console.ReadKey();

            // Detengo la escucha de mensajes
            bot.StopReceiving();

            // Se actualizan las listas
            listaAdministradores = new ListaAdministradores();
            listaDeUsuario = new ListaDeUsuario();
            listaEmprendedores = new ListaEmprendedores();
            listaEmpresa = new ListaEmpresa();
            listaInvitaciones = new ListaInvitaciones();
            listaTransacciones = new ListaTransacciones();
            registroPublicaciones = new RegistroPublicaciones();

            // Se guardan en los json
            string guardarAdmin = listaAdministradores.ConvertToJson();
            string guardarUsuario = listaDeUsuario.ConvertToJson();
            string guardarEmprend = listaEmprendedores.ConvertToJson();
            string guardarEmpresa = listaEmpresa.ConvertToJson();
            string guardarInvit = listaInvitaciones.ConvertToJson();
            string guardarTrans = listaTransacciones.ConvertToJson();
            string guardarPubli = registroPublicaciones.ConvertToJson();

            // Se guardan en los archivos de texto
            File.WriteAllText(@"..\..\Datos_json\listaAdministradores.txt", guardarAdmin);
            File.WriteAllText(@"..\..\Datos_json\listaUsuario.txt", guardarUsuario);
            File.WriteAllText(@"..\..\Datos_json\listaEmprendedores.txt", guardarEmprend);
            File.WriteAllText(@"..\..\Datos_json\listaEmpresas.txt", guardarEmpresa);
            File.WriteAllText(@"..\..\Datos_json\listaInvitaciones.txt", guardarInvit);
            File.WriteAllText(@"..\..\Datos_json\listaTransacciones.txt", guardarTrans);
            File.WriteAllText(@"..\..\Datos_json\registroPublicaciones.txt", guardarPubli);
        }

         private static async void OnMessage(object sender, MessageEventArgs messageEventArgs)
         {
             Mensaje mensaje = new Mensaje(messageEventArgs.Message.Chat.Id, messageEventArgs.Message.Text);
             while (mensaje.Text != "/finalizar")
            {
                // Fijarse si estsa registrado y obtener el IUsuario.
                Console.WriteLine("ingrese un mensaje: \n Ingrese /finalizar para salir");
                mensaje.Text = Console.ReadLine();
                ComienzoHandler.Handle(mensaje);

                //Como ya tenemos el objeto IUsuario, cambiamos su estado por que el nos devolvio el metodo Handle.
            }
         }
    }
}