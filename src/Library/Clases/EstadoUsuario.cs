// -----------------------------------------------------------------------
// <copyright file="EstadoUsuario.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    public class EstadoUsuario
    {
        private IHandler handler;
        public IHandler Handler
        {
            get { return this.handler; }
            set { this.handler = value; }
        }
        private int step;
        public int Step
        {
            get { return this.step; }
            set { this.step = value; }
        }

        public EstadoUsuario()
        {
            this.Handler = new NullHandler();
            this.step = 0;
        }
    }
}