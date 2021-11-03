using System;
using System.Text;

namespace Library
{
    /// <summary>
    /// Handler encargado de crear un usuario. Implementa AbstractHandler porque interactúa con
    /// el usuario. Único Handler que tiene dos atributos Next, se envía el mensaje a uno de ellos
    /// en base a si el usuario está previamente registrado. Esto es para que no se saltee la verificación
    /// de usuario. De no ser por ambos Next, se podrían duplicar los usuarios.
    /// </summary>
    public class CrearUsuarioHandler : AbstractHandler
    {
        /// <summary>
        /// Atributo del segundo Next.
        /// </summary>
        public IHandler Next2; 
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="next">Handler de la subcadena</param>
        /// <param name="next2">Handler siguiente en la cadena principal</param>
        public CrearUsuarioHandler(AbstractHandler next, IHandler next2) 
        {
            this.Next = next;
            this.Next2 = next2;
        }
        /// <summary>
        /// Método que interpreta el mensaje. Si el mensaje es "/CrearUsuario", el método se encarga de 
        /// verificar que la Id no esté previamente registrada. En caso de que no lo esté, se envía el 
        /// mensaje a uno de los siguientes Handlers. 
        /// Si el mensaje es diferente a "/CrearUsuario", se manda el mensaje a otro Handler.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido como parámetro. Contiene Id y el texto a evaluar.</param>
        public override void Handle (Mensaje mensaje)
        {
            if (mensaje.Text == "/CrearUsuario")
            {
                VerificadorUsuario verificador = new VerificadorUsuario();
                if (!verificador.EstaRegistrado(mensaje.Id))
                {
                    mensaje.Text = Input.GetInput("Qué tipo de usuario desea crear? Ingrese /empresa o /emprendedor");
                    this.Next.Handle(mensaje); //Este deberia ser el handler de crear empresa o emprendedor
                }
            }
            else
            {
                Output.PrintLine("Usted ya esta registrado");
                this.Next2.Handle(mensaje);
            }
        }
    }
}