using System;
using System.Text;
using System.Collections.Generic;

namespace Library
{
    public class VerHistorial : IComandos
    {
        public void EjecutarComando()
        {
            StringBuilder Resultado = new StringBuilder ("Tus transacciones son: \n ");
            bool encontrar = false;
            int i = 0;
                        
            while (!encontrar && i < RegistrosHistoriales.Historiales.Count)  
            {
                if (mensaje.Id == RegistrosHistoriales.Historiales[i].id) 
                {
                    encontrar = true; 
                }
                else 
                {
                    i += 1;
                }
            }
            // mover foreach a otra clase y encontrar registro. Ver los puntos 
            foreach (Publicacion publicacion in RegistrosHistoriales.Historiales[i].Transacciones)
            {
                Resultado.Append($"{cantidad} de {material} desde la siguente publicacion{publicacion}\n");
            } 
        } 
        //Arreglar errores

        

    }
}