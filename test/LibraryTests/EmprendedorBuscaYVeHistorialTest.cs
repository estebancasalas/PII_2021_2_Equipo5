//Emprendedor: buscar publicacion y ver historial

// <copyright file="RegistrarEmpresarioTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Library;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class EmprendedorBuscaYVeHistorialTest
    {
        private Publicacion a;
        private Publicacion b;
        private Publicacion c;
        private Mensaje mensaje = new Mensaje(1234, string.Empty);
        private EstadoUsuario estado = new EstadoUsuario();
        private BuscarPublicacionHandler handler = new BuscarPublicacionHandler();
        private IHandler nullHandler = new NullHandler();
        private Usuario user;

        
        
        [SetUp]
        
        public void Setup()
        {
            Emprendedor emprendedor1 = new Emprendedor(1234,"Juan","Montevideo","Textiles","Ninguna","Ninguna");
            Emprendedor emprendedor2 = new Emprendedor(1234,"Juan","Montevideo","Textiles","Ninguna","Ninguna");
            Emprendedor emprendedor3 = new Emprendedor(1234,"Juan","Montevideo","Textiles","Ninguna","Ninguna");
            
            
            Empresa empresa1 = new Empresa("Empresa1", "UbicacionEmpresa1", "maderero", "123", "091234567");
            Empresa empresa2 = new Empresa("Empresa2", "UbicacionEmpresa2", "plastico", "1232", "099557959");
            Empresa empresa3 = new Empresa("Empresa3", "UbicacionEmpresa3", "electrica", "1233", "098998895");
            
            
            
            
            Material madera = new Material("PMadera", 1, 2, "Cantidad", "Habilitación1", "/Quimicos");
            Material dos = new Material("Material2", 3, 4, "Cantidad", "Habilitación1", "/Plasticos");
            Material tres = new Material("Material3", 5, 6, "Cantidad", "Habilitación1", "/Electricos");

            IUbicacion alfa = new Ubicacion("Uruguay", "Montevideo", "8 de Octubre 1234", null, null, null);
            IUbicacion beta = new Ubicacion("Uruguay", "Salto", null, null, null, null);
            IUbicacion gamma = new Ubicacion("Uruguay", "Tacuarembo", null, null, null, null);


            this.a = new Publicacion("1", madera, "madera", "todos los dias", alfa, empresa1);
            this.b = new Publicacion("2", dos, "plastico", "todos los dias", beta, empresa2);
            this.c = new Publicacion("3", tres, "electrico", "todos los dias", gamma, empresa3);

            this.user = new Usuario(1234, this.estado);
            ListaDeUsuario lista = new ListaDeUsuario();
            lista.Add(this.user);

            this.handler.SetNext(this.nullHandler);
        }
        



        [Test]
        public void EmprendedorBuscaPublicacionTest()
        {
            
        }

        [Test]
        public void EmprendedorVeHistorialTest()
        {}
    }
}