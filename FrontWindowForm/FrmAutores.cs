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
    public partial class FrmAutores : Form
    {
        public FrmAutores()
        {
            InitializeComponent();
            TraerAutores("");//Esto en un principio me Trae toda la tabla

            //Sucribimos el evento => DELEGADO
            txtFiltro.TextChanged += txtFiltro_TextChanged;
        }
        //Este nuestro Front y podes usar Las clases de Logica que traen mediante su context la data
        //public void TraerAutores()
        //{
        //    LogicaBI.Autor obj = new LogicaBI.Autor();
        //    //Insertamos la data en el GV
        //    //NECESITAMOS QUE ESTE FRONTEND agreamos la conexion en el app.config
        //    dgvAutores.DataSource = obj.TraerTodos();
        //}

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //Cada vez que el usuario escriba una letra, se dispara este evento y busca segun
            //la cadena recibida
            TraerAutores(txtFiltro.Text);
            
        }
        public void TraerAutores(string Letra)
        {
            LogicaBI.Autor bi = new LogicaBI.Autor();
            dgvAutores.DataSource= bi.TraerTodos(Letra);
        }
    }
}
