// using System;
// using System.Text;

// namespace Library
// {
//    /// <summary>
//    /// ?? 
//    /// </summary>
//    public class AceptarInvitacionHandler : AbstarctHandler
//    {
//         private string codigo;

//         public void Handle(Mensaje mensaje)
//         {
//             Console.Write ("Asi que usted pertenece a una empresa, porfavor escriba el codigo que le otorgaron: ");
//             this.codigo = Console.ReadLine();
//             if (ListaCodigosValidos.CodigosValidos.Contains(codigo))
//             {
//                 this.Next.Handle(mensaje);
//             }
//         }
//    }
// }