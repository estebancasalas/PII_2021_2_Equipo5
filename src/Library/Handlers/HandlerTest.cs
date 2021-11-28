/*/* -----------------------------------------------------------------------
// <copyright file="HandlerTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Library
{
    /// <summary>
    /// Handler creado para los tests
    /// </summary>
    public class HandlerTest
    {
        public int paso;
        public IHandler next;
        public Mensaje msg;
        public HandlerTest(int pasos, Mensaje mensaje)
        {
            this.paso = pasos;
            this.msg = mensaje;
        }

        public void SetNext(IHandler handler)
        {
            this.next = handler;
        }

        public void Handle()
        {
            string text;
            int i = 0;
            while (i < this.paso)
            {
                text = this.next.Handle(this.msg);
                i++;
            }
        }
    }
}
*/