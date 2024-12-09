using ComicsPOO.Datos;
using ComicsPOO.Entidades;
using ComicsPOO.Windows.Helpers;

namespace ComicsPOO.Windows
{
    public partial class frmComics : Form
    {
        private Comiqueria? comiqueria;
        public frmComics()
        {
            InitializeComponent();
            comiqueria = new Comiqueria("Kevin");
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProductoAE frm = new frmProductoAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel) return;
            Producto? producto = frm.GetProducto();
            if (producto is null) return;
            var resultado = comiqueria!.AgregarProducto(producto);
            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje,
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GridHelper.MostrarDatosEnGrilla<Producto>(comiqueria.GetLista(), dgvDatos);
                CantidadTotal();
            }
            else
            {
                MessageBox.Show(resultado.mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CantidadTotal()
        {
            txtCantidad.Text = comiqueria!.GetCantidad().ToString();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            comiqueria!.GuardarDatos();
            Application.Exit();
        }


        private void frmComics_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboTipoProducto(ref tcboTipos);
            GridHelper.MostrarDatosEnGrilla<Producto>(comiqueria!.GetLista(), dgvDatos);
            CantidadTotal();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is null) return;
            Producto producto = (Producto)r.Tag;
            var resultado = comiqueria.QuitarProducto(producto.Codigo);
            if (resultado.exito)
            {
                MessageBox.Show(resultado.mensaje,
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GridHelper.MostrarDatosEnGrilla<Producto>(comiqueria.GetLista(), dgvDatos);
                CantidadTotal();
            }
            else
            {
                MessageBox.Show(resultado.mensaje,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tcboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoProducto tipo;
            tipo = (TipoProducto)tcboTipos.SelectedItem!;
            GridHelper.MostrarDatosEnGrilla<Producto>(comiqueria!.GetListaTipo(tipo), dgvDatos);
        }
    }
}
