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
    public partial class FRML_ArretAjoutetModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLSL_ArretTable classArret = new CL.CLSL_ArretTable();
        UCL_Arret_List userRArret = new UCL_Arret_List();
        private Db_EleveBookEntities4 db;

        public FRML_ArretAjoutetModifier(UserControl user)
        {
            InitializeComponent();
            this.usEleve = user;
        }

        private void FRML_ArretAjoutetModifier_Load(object sender, EventArgs e)
        {
            if (lblTitre.Text == "AJOUTER UNE PUNITION")
            {
                db = new Db_EleveBookEntities4();
                this.cmbNom.DataSource = null;  //pour eviter l exception (Items collection cannot be modified when the DataSource property is set.')
                this.cmbNom.DataSource = null;
                cmbNom.DataSource = db.LR_ElementairesTable.ToList();  //display all data
                cmbNom.DisplayMember = "Nom_Eleve"; //display only name
                cmbNom.ValueMember = "Id"; //display who has this id

                cmbPrenom.DataSource = db.LR_ElementairesTable.ToList();  //display all data
                cmbPrenom.DisplayMember = "Prenom_Eleve"; //display only name
                cmbPrenom.ValueMember = "Nom_Eleve"; //display who has this id

                cmbNom.Text = "-- Choisir Nom --";
                cmbPrenom.Text = "-- Choisir Prénom --";
            }

            else
            {
                cmbNom.Enabled = false;
                cmbPrenom.Enabled = false;
            }
           
        }


        String testObligatoire()
        {
            
            if (cmbNom.Text == "choisir Elève")
                return "Veuillez choisir le Nom de l'élève parmis la liste ci dessous";
            
            return null;
        }

       


        public void btnActualiser_Click(object sender, EventArgs e)
        {
            if (lblTitre.Text == "AJOUTER DES RENSEIGNEMENTS SECONDAIRES")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.Gray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.Gray;
            }

            cmbPunition.SelectedIndex = 0; cmbPunition.ForeColor = Color.Gray;
            txtMotif.Text = "Motif de la Punition"; txtMotif.ForeColor = Color.Silver;
            txtDate.Text = "Date"; txtDate.ForeColor = Color.Silver;
            txtAutorite.Text = "Autorité"; txtAutorite.ForeColor = Color.Silver;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;
        }

        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Champs Obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitre.Text == "AJOUTER UNE PUNITION") //tous les champs remplis
            {
                
                
                if (classArret.Ajouter_RArret(cmbNom.Text, cmbPrenom.Text, cmbPunition.Text, txtMotif.Text, txtDate.Text, txtAutorite.Text, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Données ajoutées avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        this.Close();
                    (usEleve as FM.UCL_Arret_List).ActualiserDataGridView();

                }
                else
                {
                    MessageBox.Show("Ces données existent déja; \n Veuillez Ajouter un neauveau Elève !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }


            // ATTENTION : c'est ce qui devrait faire le bouton modifier 
            else  //si lblTitre  == modifier eleve
            {

                DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier ces données", "MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    classArret.Modifier_RArret(UCL_Arret_List.IDselect, cmbNom.Text, cmbPrenom.Text, cmbPunition.Text, txtMotif.Text, txtDate.Text, txtAutorite.Text, txtAutres.Text);
                    MessageBox.Show("Données modifiés avec succès", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as UCL_Arret_List).ActualiserDataGridView();  //actualiser dataGridView
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region TEXT ENTER AND LEAVE
        private void cmbNom_Enter(object sender, EventArgs e)
        {
            cmbNom.ForeColor = Color.Black;
        }
      

        private void cmbPrenom_Enter(object sender, EventArgs e)
        {
            cmbPrenom.ForeColor = Color.Black;
        }

        private void cmbPunition_Enter(object sender, EventArgs e)
        {
            cmbPunition.ForeColor = Color.Black;
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text == "Date")
            {
                txtDate.Text = "";
                txtDate.ForeColor = Color.Black;
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (txtDate.Text == "")
            {
                txtDate.Text = "Date";
                txtDate.ForeColor = Color.Silver;
            }
        }

              

        private void txtAutorite_Enter(object sender, EventArgs e)
        {
            if (txtAutorite.Text == "Autorité")
            {
                txtAutorite.Text = "";
                txtAutorite.ForeColor = Color.Black;
            }
        }

        private void txtAutorite_Leave(object sender, EventArgs e)
        {
            if (txtAutorite.Text == "")
            {
                txtAutorite.Text = "Autorité";
                txtAutorite.ForeColor = Color.Silver;
            }
        }

        private void txtMotif_Enter(object sender, EventArgs e)
        {
            if (txtMotif.Text == "Motif de la Punition")
            {
                txtMotif.Text = "";
                txtMotif.ForeColor = Color.Black;
            }
        }

        private void txtMotif_Leave(object sender, EventArgs e)
        {
            if (txtMotif.Text == "")
            {
                txtMotif.Text = "Motif de la Punition";
                txtMotif.ForeColor = Color.Silver;
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
        #endregion
    }
}
