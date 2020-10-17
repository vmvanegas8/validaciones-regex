using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidacionesRegex
{
    public partial class frmvalidaciones : Form
    {
        public frmvalidaciones()
        {
            InitializeComponent();
        }

        Validaciones validaciones = new Validaciones();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frmvalidaciones_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            if(!validaciones.vacio(txtnombre, errorProvider1, "Este campo es requerido"))
            {
                if(validaciones.isText(txtnombre, errorProvider1, "Este no es un nombre valido"))
                {
                    if (!validaciones.vacio(txtcodigo, errorProvider1, "Este campo es requerido"))
                    {
                        if (validaciones.isNumber(txtcodigo, errorProvider1, "Debe ser un numero"))
                        {
                            if(!validaciones.vacio(txtemail, errorProvider1, "Este campo es requerido"))
                            {
                                if (validaciones.isEmailValid(txtemail, errorProvider1, "No es un email valido"))
                                {
                                    if (!validaciones.vacio(txtpassword, errorProvider1, "Este campo es requerido"))
                                    {
                                        if (validaciones.isPasswordValid(txtpassword, errorProvider1, "La contraseña no cumple el formato"))
                                        {
                                            lblmsg.Text = "valido";
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
