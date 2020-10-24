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
        FrmAutor formulario = null;
        public FrmAutores()
        {
            InitializeComponent();
            TraerAutores("");//Esto en un principio me Trae toda la tabla

            //Sucribimos el evento => DELEGADO
            txtFiltro.TextChanged += txtFiltro_TextChanged;//Estamos Filtandro por Apellido y Nombre


            //Creamos un Double click que nos abra de la fila seleccionada y nos traiga toda la data
            dgvAutores.DoubleClick += dgvAutores_DoubleClick;
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

        private void dgvAutores_DoubleClick(object sender, EventArgs e)
        {
            //El frmAutor RECIBE UN tipo AUTOR con lo cual creamos un objeto del mismo y lo llenamos
            //con la data de las filas clickeada
            Modelo.Autor data = new Modelo.Autor();
            data.ID =  Convert.ToInt32(  dgvAutores.CurrentRow.Cells["ID"].Value );
            data.Apellido = dgvAutores.CurrentRow.Cells["Apellido"].Value.ToString();
            data.Nombre = dgvAutores.CurrentRow.Cells["Nombre"].Value.ToString();

            
            if (formulario == null)
            {
                //Enviamos este objeto creado al Nuevo Formulario
                formulario = new FrmAutor(data);
                //Podemos Setiar la ubicacion, en este caso Centrada
                formulario.StartPosition = FormStartPosition.CenterScreen;
                //Mostramos el objeto del Formulario

                formulario.FormClosed += (o, args) => formulario = null; 
            }

            

            formulario.Show();//Lo muestro
            formulario.BringToFront();    //Lo traigo al Frente

            //Cuando vuelve del Form Edicion de Autor
            //Actualizo asi que llamo al metodo que me trae todos los datos
            LogicaBI.Autor bi = new LogicaBI.Autor();
            bi.TraerTodos();
        }

    }
}
