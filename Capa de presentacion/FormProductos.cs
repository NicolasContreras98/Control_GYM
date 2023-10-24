﻿using Control_Gym.Capa_de_datos;
using Control_Gym.Capa_logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Gym.Capa_de_presentacion
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }
        private CTipoProducto cTipoProducto = new CTipoProducto();
        private ClsProvedores cProveedor = new ClsProvedores();
        private void FormProductos_Load(object sender, EventArgs e)
        {

            CProducto CProductoD = new CProducto();
            dgvProductos.DataSource = CProductoD.MostrarDatos();
            List<CTipoProducto> tipos_productos = cTipoProducto.traerTiposProductos();
            cmbTipoProducto.DataSource = tipos_productos;
            List<ClsProvedores> tipos_provedores = cProveedor.traerTiposProveedores();
            cmbProveedor.DataSource= tipos_provedores;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       

        private void btnModificar_Click(object sender, EventArgs e)
        {
            long cod_producto;

            if (string.IsNullOrWhiteSpace(txtCodProducto.Text))
            {
                MessageBox.Show("El campo Código de Producto no puede estar vacío.");
                return;
            }

            if (!long.TryParse(txtCodProducto.Text.Trim(), out cod_producto))
            {
                MessageBox.Show("El campo Código de Producto debe ser un número válido.");
                return;
            }

            string cod = txtCod.Text;
            int cod_proveedor = Convert.ToInt32(cmbProveedor.Text);
            int cod_tipo_producto = Convert.ToInt32(cmbTipoProducto.Text);
            string nombre = txtNombre.Text;
            DateTime fecha_venc = dtpFechaVenc.Value;
            decimal precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
            decimal preciocosto = Convert.ToDecimal(txtCosto.Text);
            decimal ganancia = Convert.ToDecimal(txtGanancia.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            CProducto CProductoD = new CProducto();
            CProductoD.ModificarProducto(cod, cod_producto, cod_proveedor, cod_tipo_producto, nombre, fecha_venc, precioventa, preciocosto, ganancia, stock);
            dgvProductos.DataSource = CProductoD.MostrarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            CProducto CProductoD = new CProducto();
            string cod = txtCod.Text;
            string nombre = txtNombre.Text;
            CProductoD.EliminarProducto(cod, nombre);


            txtCodProducto.Text = "";
            cmbTipoProducto.Text = "";
            cmbProveedor.Text = "";
            txtCod.Text = "";
            txtNombre.Text = "";
            dtpFechaVenc.Text ="";
            txtPrecioVenta.Text = "";
            txtCosto.Text = "";
            txtGanancia.Text = "";
            txtStock.Text = "";
            dgvProductos.DataSource = CProductoD.MostrarDatos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            long cod_producto;

            if (string.IsNullOrWhiteSpace(txtCodProducto.Text))
            {
                MessageBox.Show("El campo Código de Producto no puede estar vacío.");
                return;
            }

            if (!long.TryParse(txtCodProducto.Text.Trim(), out cod_producto))
            {
                MessageBox.Show("El campo Código de Producto debe ser un número válido.");
                return;
            }

            int cod_proveedor = cProveedor.Cod;
            int cod_tipo_producto = cTipoProducto.Cod_tipo_producto;
            string nombre = txtNombre.Text;
            DateTime fecha_venc = dtpFechaVenc.Value;
            decimal preciocosto = Convert.ToDecimal(txtCosto.Text);
            decimal precioventa = Convert.ToDecimal(txtPrecioVenta.Text);  
            decimal resultado=(precioventa - preciocosto);
            txtGanancia.Text = resultado.ToString();
            decimal ganancia = Convert.ToDecimal(txtGanancia.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            CProducto CProductoD = new CProducto();
            CProductoD.GuardarProducto(cod_producto, cod_proveedor, cod_tipo_producto, nombre, fecha_venc, preciocosto, precioventa, ganancia, stock);
            dgvProductos.DataSource = CProductoD.MostrarDatos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Text = dgvProductos.Rows[e.RowIndex].Cells["cod_producto"].FormattedValue.ToString(); ;
            txtCodProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["cod_producto"].FormattedValue.ToString();
            cmbProveedor.Text = dgvProductos.Rows[e.RowIndex].Cells["cod_proveedor"].FormattedValue.ToString();
            cmbTipoProducto.Text = dgvProductos.Rows[e.RowIndex].Cells["cod_tipo_producto"].FormattedValue.ToString();
            txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells["nombre"].FormattedValue.ToString();
            txtPrecioVenta.Text = dgvProductos.Rows[e.RowIndex].Cells["precio_venta"].FormattedValue.ToString();
            txtCosto.Text = dgvProductos.Rows[e.RowIndex].Cells["precio_costo"].FormattedValue.ToString();
            txtGanancia.Text = dgvProductos.Rows[e.RowIndex].Cells["ganancia"].FormattedValue.ToString();
            txtStock.Text = dgvProductos.Rows[e.RowIndex].Cells["stock"].FormattedValue.ToString();
            dtpFechaVenc.Text = dgvProductos.Rows[e.RowIndex].Cells["fecha_venc"].FormattedValue.ToString();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedItem != null)
            {
                ClsProvedores proveedorSeleccionado = (ClsProvedores)cmbProveedor.SelectedItem;
                int cod_proveedor = proveedorSeleccionado.Cod;
                cProveedor.Cod = cod_proveedor;
            }
        }

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoProducto.SelectedItem != null)
            {
                CTipoProducto seleccion = (CTipoProducto)cmbTipoProducto.SelectedItem;
                int cod_tipo_producto = seleccion.Cod_tipo_producto;
                cTipoProducto.Cod_tipo_producto = cod_tipo_producto;
            }
        }

        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            CProducto cProducto = new CProducto();
            if (txtBuscar.Text != "")
            {
                string cod = txtBuscar.Text;
                dgvProductos.DataSource = cProducto.Filtrar(cod);
            }
            else
            {
                cProducto.MostrarDatos();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CProducto cProducto = new CProducto();


            if (txtBuscar.Text != "")
            {
                string cod = txtBuscar.Text;
                dgvProductos.DataSource = cProducto.Filtrar(cod);
            }
            else
            {
                dgvProductos.DataSource = cProducto.MostrarDatos();
            }

        }
    }
}
