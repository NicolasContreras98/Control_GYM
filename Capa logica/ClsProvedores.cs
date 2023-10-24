﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control_Gym.Capa_de_datos;

namespace Control_Gym.Capa_logica
{
    internal class ClsProvedores
    {
        public int Cod { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public ClsProvedores(int Cod, string Nombre, string Cuit, string Telefono, string Direccion, string Email) 
        {
            this.Cod = Cod;
            this.Nombre = Nombre;
            this.Cuit = Cuit;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Email = Email;
        }
        public ClsProvedores() { }
        public ClsProvedores(int cod, string nombre)
        {
            this.Cod=cod;
            this.Nombre=nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
        public void AgregarProv(string nombre, string cuit, string telefono, string direccion, string email)
        {
            CProveedoresD cProveedoresD = new CProveedoresD();
            cProveedoresD.AgregarProv(nombre, cuit,  telefono, direccion, email);

        }
        public void ModificarProv(int cod, string nombre, string cuit, string telefono, string direccion, string email)
        {
            CProveedoresD cProveedoresD = new CProveedoresD();
            cProveedoresD.ModificarProv(cod, nombre, cuit, telefono, direccion, email);
        }
        public void EliminarDatos(int cod, string nombre)
        {
            CProveedoresD cProveedoresD = new CProveedoresD();
            cProveedoresD.EliminarDatos(cod, nombre);
        }
        public DataTable CargarDatos()
        {

            CProveedoresD cProveedoresD = new CProveedoresD();
            DataTable tabla = new DataTable();
            tabla = cProveedoresD.CargarDatos();

            return tabla;
        }
        public DataTable Filtrar(string cod)
        {

            CProveedoresD cProveedoresD = new CProveedoresD();
            DataTable tabla = new DataTable();
            tabla = cProveedoresD.Filtrar(cod);

            return tabla;
        }
        public List<ClsProvedores> traerTiposProveedores()
        {
            CProveedoresD tiposD = new CProveedoresD();
            return tiposD.traerTiposProveedores();
        }
    }
}
