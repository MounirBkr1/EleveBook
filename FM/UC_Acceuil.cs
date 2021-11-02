using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleve_Book.FM
{
    public partial class UC_Acceuil : UserControl
    {

        private static UC_Acceuil User;


        public UC_Acceuil()
        {
            InitializeComponent();
        }

                //creer instance pour usercontrole
        public static UC_Acceuil Instance
        {
            get
            {
                if (User == null)
                {
                    User = new UC_Acceuil();
                }
                return User;
            }
        }
    }
}
