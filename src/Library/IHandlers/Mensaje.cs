using System;

namespace Library
{
    public class Mensaje
    {
        public int Id{ get; set;}
        public string Text {get; set;}
        public Mensaje(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}