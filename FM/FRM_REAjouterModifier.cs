using Eleve_Book.FM;
using MaterialSkin.Controls;
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

namespace Eleve_Book
{
    public partial class FRM_REAjouterModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLS_R_ElementairesTable classRE = new CL.CLS_R_ElementairesTable();
        UC_RE_List userRE = new UC_RE_List();
        public int IDEleve;


        public FRM_REAjouterModifier(UserControl userC)
        {
            InitializeComponent();
            this.usEleve = userC;
                    
        }


        String testObligatoire()
        {
            if (txtNom.Text == "" || txtNom.Text == "NOM")
                return "Entrer le Nom de l'élève";
             if (txtPrenom.Text == "" || txtPrenom.Text == "Prénom")
                return "Entrer le Prénom de l'élève";
             if (txtTelephone.Text == "" || txtTelephone.Text == "Téléphone")
                return "Entrer le Téléphone de l'élève";
            
             if (txtEmail.Text == "" || txtEmail.Text == "Email")
                return "Entrer l'Email de l'élève";
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
                return "Entrer une image Pour cet Eleve";
            return null;
        }

       
        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitre.Text == "AJOUTER  UN  ELEVE") //tous les champs remplis
            {

                
                //convertir image en format byte
                MemoryStream mr = new MemoryStream();
                imgProfil.Image.Save(mr, imgProfil.Image.RawFormat);
                byte[] byteImageEleve = mr.ToArray();  //convertir en byte


                if (classRE.Ajouter_Eleve(txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtEmail.Text, cmbGenre.Text, cmbNationalite.Text, cmbReligion.Text, txtAdresse.Text, byteImageEleve,txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Elève ajouté avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click_1(sender, e);  //vider tous les champs
                    (usEleve as FM.UC_RE_List).ActualiserDataGridViewRE();
                    //Close();
                    btnActualiser_Click_1(sender, e);
                }
                else
                {
                    MessageBox.Show("Ce nom et Prénom existent déja; \n Veuillez Ajouter un neauveau Elève !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            // ATTENTION : c'est ce qui devrait faire le bouton modifier 
            else  //si lblTitre  == modifier eleve
            {
                UC_RE_List userRE = new UC_RE_List();         
                MemoryStream ms = new MemoryStream();
                imgProfil.Image.Save(ms, imgProfil.Image.RawFormat);
                byte[] byteImageEleve = ms.ToArray();  //convertir image to format byt[]


                DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier", "MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    classRE.Modifier_Eleve(UC_RE_List.IDselect, txtNom.Text, txtPrenom.Text, txtTelephone.Text, txtEmail.Text, cmbGenre.Text, cmbNationalite.Text, cmbReligion.Text, txtAdresse.Text, byteImageEleve,txtAutres.Text);
                    MessageBox.Show("Elève modifié avec succes", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as FM.UC_RE_List).ActualiserDataGridViewRE();  //actualiser dataGridView
                    Close();
                    
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


       

        public void btnActualiser_Click_1(object sender, EventArgs e)
        {
            txtNom.Text = "NOM"; txtNom.ForeColor = Color.Gray;
            txtPrenom.Text = "Prénom"; txtPrenom.ForeColor = Color.Gray;

            txtAdresse.Text = "Adresse"; txtAdresse.ForeColor = Color.Silver;
            txtTelephone.Text = "Téléphone"; txtTelephone.ForeColor = Color.Silver;
            txtEmail.Text = "Email"; txtEmail.ForeColor = Color.Silver;
            cmbReligion.SelectedIndex = 0; cmbReligion.ForeColor = Color.Gray;
            cmbGenre.SelectedIndex = 0; cmbGenre.ForeColor = Color.Gray;
            cmbNationalite.SelectedIndex = 0; cmbNationalite.ForeColor = Color.Gray;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;
            imgProfil.Image = null;
        }

        private void btnTelechargerImage_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgProfil.Image = Image.FromFile(Op.FileName);

            }
        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            imgProfil.Image = null;
        }

        #region TEXT ENTER LEAVE
        private void txtNom_Enter_1(object sender, EventArgs e)
        {
            if (txtNom.Text == "NOM")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.Black;
            }
        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "NOM";
                txtNom.ForeColor = Color.Gray;
            }
        }


        private void txtPrenom_Enter(object sender, EventArgs e)
        {

            if (txtPrenom.Text == "Prénom")
            {
                txtPrenom.Text = "";
                txtPrenom.ForeColor = Color.Black;
            }
        }

        private void txtPrenom_Leave(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "")
            {
                txtPrenom.Text = "Prénom";
                txtPrenom.ForeColor = Color.Gray;
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

        private void txtAdresse_Enter(object sender, EventArgs e)
        {
            if (txtAdresse.Text == "Adresse")
            {
                txtAdresse.Text = "";
                txtAdresse.ForeColor = Color.Black;
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

       
        private void txtAutres_Enter(object sender, EventArgs e)
        {
            if (txtAutres.Text == "Autres.....")
            {
                txtAutres.Text = "";
                txtAutres.ForeColor = Color.Black;
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

        private void cmbNationalite_Enter(object sender, EventArgs e)
        {
            cmbNationalite.ForeColor = Color.Black;
        }

        private void cmbGenre_Enter(object sender, EventArgs e)
        {
            cmbGenre.ForeColor = Color.Black;
        }


        private void cmbReligion_Enter(object sender, EventArgs e)
        {
            cmbReligion.ForeColor = Color.Black;
        }

        private void txtTelephone_KeyPress_1(object sender, KeyPressEventArgs e)
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

        #endregion

        /*
         * #region FAIRE BOUGER LEFORMULAIRE AVEC DE LA SOURIS

        Point MouseCurrrnetPos, MouseNewPos, formPos, formNewPos;

        bool mouseDown = false;
        private void FRM_REAjouterModifier_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                // get the position of the mouse in the screen
                MouseNewPos = Control.MousePosition;
                formNewPos.X = MouseNewPos.X - MouseCurrrnetPos.X + formPos.X;
                formNewPos.Y = MouseNewPos.Y - MouseCurrrnetPos.Y + formPos.Y;
                Location = formNewPos;
                formPos = formNewPos;
                MouseCurrrnetPos = MouseNewPos;
            }
        }


        private void FRM_REAjouterModifier_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDown = false;
        }

        private void FRM_REAjouterModifier_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                MouseCurrrnetPos = Control.MousePosition;
                formPos = Location;
            }
        }
        #endregion
        */
    }
}
