using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidacionesRegex
{
    class Validaciones
    {
        public bool vacio (TextBox textbox, ErrorProvider error, string msgError)
        {
            if(textbox.Text == "")
            {
                error.SetError(textbox, msgError);
                return true;
            } else
            {
                error.Clear();
                return false;
            }
        }

        public bool isText(TextBox textbox, ErrorProvider error, string msgError)
        {
            Regex formato = new Regex(@"^[a-zA-Z]+$");
            if (!formato.IsMatch(textbox.Text))
            {
                error.SetError(textbox, msgError);
                return false;
            }
            else
            {
                error.Clear();
                return true;
            }
        }

        public bool isNumber(TextBox textbox, ErrorProvider error, string msgError)
        {
            Regex formato = new Regex(@"^[0 - 9] *$");
            if (!formato.IsMatch(textbox.Text))
            {
                error.SetError(textbox, msgError);
                return false;
            }
            else
            {
                error.Clear();
                return true;
            }
        }

        public bool isEmailValid(TextBox textbox, ErrorProvider error, string msgError)
        {
            Regex formato = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!formato.IsMatch(textbox.Text))
            {
                error.SetError(textbox, msgError);
                return false;
            }
            else
            {
                error.Clear();
                return true;
            }
        }

        public bool isPasswordValid(TextBox textbox, ErrorProvider error, string msgError)
        {
            Regex formato = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{9,}$");
            if (!formato.IsMatch(textbox.Text))
            {
                error.SetError(textbox, msgError);
                return false;
            }
            else
            {
                error.Clear();
                return true;
            }
        }
    }
}
