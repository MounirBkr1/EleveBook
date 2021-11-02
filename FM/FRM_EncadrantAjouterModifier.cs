using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleve_Book.FM
{
    public partial class FRM_EncadrantAjouterModifier : Form
    {
        private UserControl usEncadrant;  //pr le remplacer par USER_List_Client
        CL.CLS__R_EncadrantTable classEn = new CL.CLS__R_EncadrantTable();
        UC_Encadrant_List userRE = new UC_Encadrant_List();
        public int IDProf;

        public FRM_EncadrantAjouterModifier(UserControl user)
        {
            InitializeComponent();
            this.usEncadrant = user;
        }

        String testObligatoire()
        {
            if (txtNom.Text == "" || txtNom.Text == "NOM")
                return "Entrer le Nom du Professeur";
            if (txtPrenom.Text == "" || txtPrenom.Text == "Prénom")
                return "Entrer le Prénom du Professeur";
            if (txtTelephone.Text == "" || txtTelephone.Text == "Telephone")
                return "Entrer le Téléphone du Professeur";

            if (txtEmail.Text == "" || txtEmail.Text == "Email")
                return "Entrer l'Email du Professeur";
            if (txtEmail.Text != "" || txtEmail.Text != "Email")
            {
                try
                {
                    new MailAddress(txtEmail.Text); //vérifier si email valide ou nn
                }
                catch
                {
                    return "Email invalide";
                }
            }

            if (imgProfil.Image == null)
                return "Entrer la photo du  Professeur";
            return null;
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)  //ASCII VALUE OF NUMBER FROM 0 TO 9
            {
                e.Handled = true;

            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

     
        private void btnTelechargerImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgProfil.Image = Image.FromFile(Op.FileName);

            }
        }

        private void btnDeletePHOTO_Click(object sender, EventArgs e)
        {
            imgProfil.Image = null;
        }

       

        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitre.Text == "AJOUTER UN ENCADRANT") //tous les champs remplis
            {


                //convertir image en format byte
                MemoryStream mr = new MemoryStream();
                imgProfil.Image.Save(mr, imgProfil.Image.RawFormat);
                byte[] byteImageProfil = mr.ToArray();  //convertir en byte


                if (classEn.Ajouter_REn(cmbGrade.Text, txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtEmail.Text, byteImageProfil, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Encadrant ajouté avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click(sender, e);  //vider tous les champs
                    (usEncadrant as FM.UC_Encadrant_List).ActualiserDataGridView();
                   
                }
                else
                {
                    MessageBox.Show("Ce nom et Prénom existent déja; \n Veuillez Ajouter un neauveau Encadrant !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            // ATTENTION : c'est ce qui devrait faire le bouton modifier 
            else  //si lblTitre  == modifier eleve
            {
                UC_Encadrant_List userPr = new UC_Encadrant_List();
                MemoryStream ms = new MemoryStream();
                imgProfil.Image.Save(ms, imgProfil.Image.RawFormat);
                byte[] byteImageProf = ms.ToArray();  //convertir image to format byt[]


                DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier !!", "MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    classEn.Modifier_REn(UC_Professeur_List.IDselectPr, cmbGrade.Text, txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtEmail.Text, byteImageProf, txtAutres.Text);
                    MessageBox.Show("Encadrant modifié avec succes", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEncadrant as FM.UC_Encadrant_List).ActualiserDataGridView();  //actualiser dataGridView
                    Close();
                  
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void btnActualiser_Click(object sender, EventArgs e)
        {
            txtNom.Text = "NOM"; txtNom.ForeColor = Color.Silver;
            txtPrenom.Text = "Prénom"; txtPrenom.ForeColor = Color.Silver;
            cmbGrade.SelectedIndex = 0; cmbGrade.ForeColor = Color.Gray;
            txtTelephone.Text = "Téléphone"; txtTelephone.ForeColor = Color.Silver;
            txtEmail.Text = "Email"; txtEmail.ForeColor = Color.Silver;
            txtAdresse.Text = "Adresse"; txtAdresse.ForeColor = Color.Silver;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;
            imgProfil.Image = null;
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
            if (txtNom.Text == "NOM")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.Black;
            }
        }
        #region TEXT ENTER AND LEAVE
        private void txtPrenom_Enter(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "Prénom")
            {
                txtPrenom.Text = "";
                txtPrenom.ForeColor = Color.Black;
            }
        }

        private void txtTelephone_Enter(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "Téléphone")
            {
                txtTelephone.Text = "";
                txtTelephone.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void cmbGrade_Enter(object sender, EventArgs e)
        {
            cmbGrade.ForeColor = Color.Black;
        }

        private void txtAdresse_Enter(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "Adresse")
            {
                txtAdresse.Text = "";
                txtAdresse.ForeColor = Color.Black;
            }
        }

        private void txtAutres_Enter(object sender, EventArgs e)
        {
            if (txtAutres.Text == "Autres.....")
            {
                txtAutres.Text = "";
                txtAutres.ForeColor = Color.Black;
            }
        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "NOM";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void txtPrenom_Leave(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "")
            {
                txtPrenom.Text = "Prénom";
                txtPrenom.ForeColor = Color.Silver;
            }
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "Téléphone";
                txtTelephone.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtAdresse_Leave(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "")
            {
                txtAdresse.Text = "Adresse";
                txtAdresse.ForeColor = Color.Silver;
            }
        }

        private void txtAutres_Leave(object sender, EventArgs e)
        {
            if (txtAutres.Text == "")
            {
                txtAutres.Text = "Autres.....";
                txtAutres.ForeColor = Color.Silver;
            }
        }
        #endregion
    }
}
