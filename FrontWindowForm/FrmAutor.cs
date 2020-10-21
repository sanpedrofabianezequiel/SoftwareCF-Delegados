using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontWindowForm
{
    public partial class FrmAutor : Form
    {
        //En el constructor recibimos el Modelo Autor para Modificar 
        public FrmAutor(Modelo.Autor autor)
        {
            InitializeComponent();
            lblID.Text = autor.ID.ToString();
            txtApellido.Text = autor.Apellido.ToString();
            txtNombre.Text = autor.Nombre.ToString();

            //Delegamos el boton Confirmar
            btnConfirmar.Click += btnConfirmar_Click;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Utilizamos la capa de BI que conecta  a la BD
            LogicaBI.Autor bi = new LogicaBI.Autor();
            Modelo.Autor obj = new Modelo.Autor();
            obj.ID = Convert.ToInt32(lblID.Text);
            obj.Nombre = txtNombre.Text.ToString();
            obj.Apellido = txtApellido.Text.ToString();


            bi.Modificar(obj);

            MessageBox.Show("Datos Modificados");
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
