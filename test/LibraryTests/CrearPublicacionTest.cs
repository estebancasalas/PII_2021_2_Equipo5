using System.Collections.Generic;
using Library;
using NUnit.Framework;


namespace LibraryTests
{
    /// <summary>
    /// Test del handler crear publicacion.
    /// </summary>
    [TestFixture]
    public class CrearPublicacionTest
    {
        private CrearPublicacionHandler publi;
        private Dictionary<string, string> diccionario = new Dictionary<string, string>();
        private Dictionary<string, string> diccionario2 = new Dictionary<string, string>();
        CrearPublicacionHandler handler = new CrearPublicacionHandler();
        EstadoUsuario estado = new EstadoUsuario();
        
        
        


        [SetUp]
        public void Setup()
        {
            ListaDeUsuario listaDeUsuario = new ListaDeUsuario();
            Usuario usuario = new Usuario(9999, estado);
            listaDeUsuario.Add(usuario);
            Empresario user = new Empresario(9999, estado, "Pablo");
            ListaEmpresa listaEmpresa = new ListaEmpresa();
            Empresa empresa = new Empresa("Niike", "Montevieo", "Ropa", "1234567890");
            empresa.ListaEmpresarios.Add(user);
            listaEmpresa.Add(empresa);
        }
        
        [Test]
        public void Case0Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 0;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese el material:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case1Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 1;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese la categoria:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case2Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 2;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese la unidad con la que cuantifica el material:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case3Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 3;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese el precio por unidad:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case4Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 4;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese la cantidad:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case5Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 5;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese habilitaciones necesarias para manipular el material:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case7Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 7;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese el título:"; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case8Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 8;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese palabras claves separadas con ',' : "; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case9Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 9;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese frequencia de disponibilidad: "; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        [Test]
        public void Case10Test()
        {
            Mensaje mensaje = new Mensaje(9999, "/crearpublicacion");
            estado.Step = 10;
            estado.Handler = "";
            handler.Handle(mensaje);
            string expected = "Ingrese dónde se encuentra: "; 
            Assert.AreEqual(expected, handler.TextResult.ToString());
        }

        /*
        [Test]
        public void PublicacionValidaTest()
        {
            this.diccionario2.Add("Ingrese el material:", "tela");
            this.diccionario2.Add("Ingrese la categoria:", "Textiles");
            this.diccionario2.Add("Ingrese la unidad con la que cuantifica el material:", "Metro");
            this.diccionario2.Add("Ingrese el precio por unidad:", "3");
            this.diccionario2.Add("Ingrese la cantidad:", "6");
            this.diccionario2.Add("Ingrese habilitaciones necesarias para manipular el material:", "a");
            this.diccionario2.Add("Ingrese el título:", "tela");
            this.diccionario2.Add("Ingrese palabras claves separadas con ',' : ", "a");
            this.diccionario2.Add("Ingrese frequencia de disponibilidad: ", "mensual");
            this.diccionario2.Add("Ingrese dónde se encuentra: ", "Av. 8 de Octubre 2738");
            this.diccionario2.Add("Ingrese nombre de la empresa: ", "Esteban telas");
            Mensaje mensaje = new Mensaje(1234, "/CrearPublicacion");
            Empresa empresa = new Empresa("Esteban telas", "Av. 8 de Octubre 2738", "textil", "1");
            Empresario empresario = new Empresario(mensaje.Id, new EstadoUsuario(), "juan");
            empresa.ListaEmpresarios.Add(empresario);
            EntaradaDeLaCadena lector = new LectorTest(this.diccionario2);
            this.publi = new CrearPublicacionHandler();
            this.publi.Input = lector;
            this.publi.SetNext(new NullHandler());
            this.publi.Handle(mensaje);
            List<Publicacion> listaPublicacion = Singleton<RegistroPublicaciones>.Instance.Activas;
            Publicacion expected = listaPublicacion.Find(x => x.Vendedor.Nombre == "Esteban telas");
            Assert.AreNotEqual(expected, null);
        }

        /// <summary>
        /// Test que verifica que los emprendedores no pueden crear publicaciones.
        /// </summary>
        [Test]
        public void PublicacionNoValidaTest()
        {
            this.diccionario.Add("Ingrese el material:", "tela");
            this.diccionario.Add("Ingrese la categoria:", "Textiles");
            this.diccionario.Add("Ingrese la unidad con la que cuantifica el material:", "Metro");
            this.diccionario.Add("Ingrese el precio por unidad:", "3");
            this.diccionario.Add("Ingrese la cantidad:", "6");
            this.diccionario.Add("Ingrese habilitaciones necesarias para manipular el material:", "a");
            this.diccionario.Add("Ingrese el título:", "tela");
            this.diccionario.Add("Ingrese palabras claves separadas con ',' : ", "a");
            this.diccionario.Add("Ingrese frequencia de disponibilidad: ", "mensual");
            this.diccionario.Add("Ingrese dónde se encuentra: ", "Av. 8 de Octubre 2738");
            this.diccionario.Add("Ingrese nombre de la empresa: ", "jose");
            Mensaje mensaje = new Mensaje(789, "/CrearPublicación");
            IUsuario emprendedor = new Emprendedor(789, "jose", string.Empty, string.Empty, string.Empty, string.Empty);
            EntaradaDeLaCadena lector = new LectorTest(this.diccionario);
            this.publi = new CrearPublicacionHandler();
            this.publi.Input = lector;
            this.publi.SetNext(new NullHandler());
            this.publi.Handle(mensaje);
            List<Publicacion> listaPublicacion = Singleton<RegistroPublicaciones>.Instance.Activas;
            Publicacion expected = listaPublicacion.Find(x => x.Vendedor.Nombre == "jose");
            Assert.AreEqual(expected, null);
        }
        */
    }
}
