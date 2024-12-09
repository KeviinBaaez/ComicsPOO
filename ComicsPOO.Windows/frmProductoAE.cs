using ComicsPOO.Entidades;
using ComicsPOO.Windows.Helpers;

namespace ComicsPOO.Windows
{
    public partial class frmProductoAE : Form
    {
        private Producto? producto;
        TipoProducto tipoPro = TipoProducto.Comic;

        public frmProductoAE()
        {
            InitializeComponent();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                string descripcion = txtDescripcion.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);
                int stock = (int)nudStock.Value;
                if (rbtComic.Checked)
                {
                    string autor = txtAutor.Text;
                    TipoComic tipo = (TipoComic)cboTipo.SelectedItem!;
                    producto = new Comic(autor, tipo, descripcion, precio, stock);
                }
                else
                {
                    float altura = float.Parse(txtAltura.Text);
                    producto = new Figurita(descripcion, precio, stock, altura);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                MessageBox.Show("Ingrese la descripcion",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal d))
            {
                valido = false;
                MessageBox.Show("Precio mal ingresado",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if (rbtComic.Checked)
            {
                MostrarControles(true);
                if (string.IsNullOrEmpty(txtAutor.Text))
                {
                    valido = false;
                    MessageBox.Show("Ingrese el autor",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            if (rbtFigurita.Checked)
            {
                DeshabilitarControles();
                if (!float.TryParse(txtAltura.Text, out float f))
                {
                    valido = false;
                    MessageBox.Show("Altura mal ingresada",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            return valido;
        }

        private void DeshabilitarControles()
        {
            txtAltura.Enabled = false;
            txtAutor.Enabled = false;
            txtDescripcion.Enabled = false;
            cboTipo.Enabled = false;
            gbTipo.Enabled = false;
        }

        private void ManejarControles(TipoProducto tipoProducto)
        {
            if (tipoProducto == TipoProducto.Comic)
            {
                MostrarControles(true);
            }
            else
            {
                MostrarControles(false);
            }

        }

        private void MostrarControles(bool v)
        {
            lblAutor.Visible = v;
            txtAutor.Visible = v;
            lblTipo.Visible = v;
            cboTipo.Visible = v;

            lblAltura.Visible = !v;
            txtAltura.Visible = !v;

        }

        public Producto? GetProducto()
        {
            return producto;
        }

        private void frmProductoAE_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboTipoComic(ref cboTipo);
            ManejarControles(tipoPro);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void rbtComic_TabIndexChanged(object sender, EventArgs e)
        {
            tipoPro = TipoProducto.Comic;
            ManejarControles(tipoPro);
        }

        private void rbtFigurita_CheckedChanged(object sender, EventArgs e)
        {
            tipoPro = TipoProducto.Figurita;
            ManejarControles(tipoPro);
        }

        private void rbtComic_CheckedChanged(object sender, EventArgs e)
        {
            tipoPro = TipoProducto.Comic;
            ManejarControles(tipoPro);
        }
    }
}
