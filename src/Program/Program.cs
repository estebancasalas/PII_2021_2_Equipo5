﻿//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using Telegram.Bot;
using Telegram.Bot.Args;

using Library;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;

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

        private static IHandler comienzoHandler = new ComienzoHandler();

        /// <summary>
        /// Donde se ejecuta valores, se inicializa el bot.
        /// </summary>
        public static void Main()
        {
            comienzoHandler.SetNext(new BuscarPublicacionHandler())
                           .SetNext(new CrearEmprendedorHandler())
                           .SetNext(new CrearPublicacionHandler())
                           .SetNext(new EmpresaCantidadTrabajadores())
                           .SetNext(new HistorialHandler())
                           .SetNext(new InvitarHandler())
                           .SetNext(new RegistrarEmpresarioHandler())
            .SetNext(new NullHandler());

            // Sección donde se crean los administradores
            Administrador juan = new Administrador(1566567912, "Ionas Josponis");

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

            // Detengo la escucha de mensajes.
            bot.StopReceiving();

            // Se actualizan las listas
            listaAdministradores = Singleton<ListaAdministradores>.Instance;
            listaDeUsuario = Singleton<ListaDeUsuario>.Instance;
            listaEmprendedores = Singleton<ListaEmprendedores>.Instance;
            listaEmpresa = Singleton<ListaEmpresa>.Instance;
            listaInvitaciones = Singleton<ListaInvitaciones>.Instance;
            listaTransacciones = Singleton<ListaTransacciones>.Instance;
            registroPublicaciones = Singleton<RegistroPublicaciones>.Instance;

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
            string respuesta;
            Mensaje mensaje = new Mensaje(messageEventArgs.Message.Chat.Id, messageEventArgs.Message.Text);
            ListaDeUsuario listaUsuario = Singleton<ListaDeUsuario>.Instance;
            ITelegramBotClient client = TelegramBot.Instance.Client;
            if (!listaUsuario.EstaRegistrado(mensaje.Id))
            {
                Usuario usuario = new Usuario(mensaje.Id, new EstadoUsuario());
                listaUsuario.Add(usuario);
            }

            if (mensaje.Text != "/salir")
            {
                try
                {
                    respuesta = comienzoHandler.Handle(mensaje);
                }
                catch (OpcionInvalidaException e)
                {
                    respuesta = e.Message;
                }
                catch (FormatException e)
                {
                    respuesta = e.Message;
                }
                catch (IndexOutOfRangeException e)
                {
                    respuesta = e.Message;
                }
                catch (YaRegistradoException e)
                {
                    respuesta = e.Message;
                }
                catch (SinPermisoException e)
                {
                    respuesta = e.Message;
                }
            }
            else
            {
                int indice2 = listaUsuario.Buscar(mensaje.Id);
                listaUsuario.ListaUsuarios[indice2].Estado = new EstadoUsuario();
                respuesta = "Gracias por usar nuestro bot, esperamos que te haya ayudado. Si quieres continuar utilizando nuestro bot vuelve a escribir un /comandos .";
            }

            await client.SendTextMessageAsync(chatId: mensaje.Id, text: respuesta);
        }
    }
}
