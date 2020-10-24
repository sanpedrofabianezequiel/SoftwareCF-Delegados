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
            btnBorrar.Click += btnConfirmar_Click;
           // btnBorrar.Click += btnBorrar_Click;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Utilizamos la capa de BI que conecta  a la BD
            LogicaBI.Autor bi = new LogicaBI.Autor();
            Modelo.Autor obj = new Modelo.Autor();
            obj.ID = Convert.ToInt32(lblID.Text);
            obj.Nombre = txtNombre.Text.ToString();
            obj.Apellido = txtApellido.Text.ToString();


            #region Misma Funcionalidad para Eliminar un Autor
            //Castiamos el SENDER para determinar que nos enviaron 
            if (sender !=  null)
            {
                if (sender is Button)
                {
                    if (sender.GetType() == typeof(Button))
                    {
                        //Castiamos
                        Button boton = sender as Button;
                        //Determinamos el id o Name del boton que viene como en JAVA
                        switch (boton.Name)
                        {
                            case "btnConfirmar":
                                bi.Modificar(obj);
                                break;
                            case "btnBorrar":
                                bi.Borrar(obj.ID);
                                break;
                            default:
                                break;
                        }
                    }
                }
              
            }

            #endregion

           

            MessageBox.Show("Datos Modificados");
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void btnBorrar_Click(object sender, EventArgs e)
        //{
        //    LogicaBI.Autor bi = new LogicaBI.Autor();
        //    //Neceistmos Suscribir a los eventos/delegados en el load
        //    Modelo.Autor obj = new Modelo.Autor();
        //    bi.Borrar(obj.ID);
        //    //OTRA FORMA SERIA CON EL SENDER casteandolo para solo hacer un metodo Click
        //}
    }
}
