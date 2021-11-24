// -----------------------------------------------------------------------
// <copyright file="EstadoUsuario.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library
{
    public class EstadoUsuario
    {
        private string handler;
        public string Handler
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
            this.handler = null;
            this.step = 0;
        }
    }
}