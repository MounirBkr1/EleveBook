using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleve_Book.FM
{
    public partial class FRML_RSAjouterModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLSL_R_SecondaireTable classRS = new CL.CLSL_R_SecondaireTable();
        UCL_RS_List userRS = new UCL_RS_List();
        private Db_EleveBookEntities4 db;

        public FRML_RSAjouterModifier(UserControl userC)
        {
            InitializeComponent();
            this.usEleve = userC;



        }

        private void FRML_RSAjouterModifier_Load(object sender, EventArgs e)
        {
            db = new Db_EleveBookEntities4();
            if (lblTitreRS.Text == "AJOUTER  RENSEIGNEMENTS  SECONDAIRES")
            {
                
                this.cmbNom.DataSource = null;  //pour eviter l exception (Items collection cannot be modified when the DataSource property is set.')
                this.cmbNom.DataSource = null;
                cmbNom.DataSource = db.LR_ElementairesTable.ToList();  //display all data
                cmbNom.DisplayMember = "Nom_Eleve"; //display only name
                cmbNom.ValueMember = "Id"; //display who has this id

                cmbPrenom.DataSource = db.LR_ElementairesTable.ToList();  //display all data
                cmbPrenom.DisplayMember = "Prenom_Eleve"; //display only name
                cmbPrenom.ValueMember = "Nom_Eleve"; //display who has this id

                cmbNom.Text = "-- Choisir Elève --";
                cmbPrenom.Text = "-- Choisir Prénom --";
            }

            else
            {
                cmbNom.Enabled = false;
                cmbPrenom.Enabled = false;
            }


          
            cmbRegion.DataSource = db.Regions.ToList();
            cmbRegion.DisplayMember = "region1";  //sur modelEntity c'est ecrit "region1" et pas "region"
            cmbRegion.ValueMember = "rgID";

            cmbVille.Enabled = false;

        }




        String testObligatoire()
        {
            if (cmbNom.Text == "-- choisir Nom --")
                return "Veuillez choisir le Nom de l'élève parmis la liste ci dessous";
            if (cmbPrenom.Text == "-- Choisir Prénom --")
                return "Veuillez choisir le Prénom de l'élève parmis la liste ci dessous";
            return null;
        }



        public void btnActualiser_Click(object sender, EventArgs e)
        {
            if (lblTitreRS.Text == "AJOUTER  RENSEIGNEMENTS  SECONDAIRES")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.DimGray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.DimGray;
            }

            cmbNom.ForeColor = Color.Gray;
            cmbPrenom.ForeColor = Color.Gray;
            txtDateNaissance.Text = "Date de Naissance"; txtDateNaissance.ForeColor = Color.Silver;
            txtLieuNaissance.Text = "Lieu de Naissance"; txtLieuNaissance.ForeColor = Color.Silver;

            //cmbRegion.SelectedIndex = 0; cmbRegion.ForeColor = Color.Gray;
            //cmbVille.SelectedIndex = 0; cmbVille.ForeColor = Color.Gray;
            cmbGSanguin.SelectedIndex = 0; cmbGSanguin.ForeColor = Color.Gray;

            txtSomme.Text = "N° Somme"; txtSomme.ForeColor = Color.Silver;
            txtCIN.Text = "N° CIN"; txtCIN.ForeColor = Color.Silver;
            txtCCP.Text = "N° CCP"; txtCCP.ForeColor = Color.Silver;
            txtCM.Text = "N° C.Militaire"; txtCM.ForeColor = Color.Silver;
            txtAutres.Text = "Autres....."; txtAutres.ForeColor = Color.Silver;

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Champs Obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitreRS.Text == "AJOUTER  RENSEIGNEMENTS  SECONDAIRES") //tous les champs remplis
            {

                if (classRS.Ajouter_RS(cmbNom.Text, cmbPrenom.Text, cmbRegion.Text, cmbVille.Text, txtDateNaissance.Text, txtLieuNaissance.Text, cmbGSanguin.Text, txtSomme.Text, txtCIN.Text, txtCCP.Text, txtCM.Text, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Données ajoutées avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click(sender, e);  //vider tous les champs
                    (usEleve as FM.UCL_RS_List).ActualiserDataGridViewRS();

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
                    classRS.Modifier_RS(UCL_RS_List.IDselectRS, cmbNom.Text, cmbPrenom.Text, cmbRegion.Text, cmbVille.Text, txtDateNaissance.Text, txtLieuNaissance.Text, cmbGSanguin.Text, txtSomme.Text, txtCIN.Text, txtCCP.Text, txtCM.Text, txtAutres.Text);
                    MessageBox.Show("Elève modifié avec succès", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as UCL_RS_List).ActualiserDataGridViewRS();  //actualiser dataGridView
                    Close();                   
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region text enter  & text leave
        private void txtDateNaissance_Enter(object sender, EventArgs e)
        {
            if (txtDateNaissance.Text == "Date de Naissance")
            {
                txtDateNaissance.Text = "";
                txtDateNaissance.ForeColor = Color.Black;
            }
        }

        private void txtLieuNaissance_Enter(object sender, EventArgs e)
        {
            if (txtLieuNaissance.Text == "Lieu de Naissance")
            {
                txtLieuNaissance.Text = "";
                txtLieuNaissance.ForeColor = Color.Black;
            }
        }

        private void txtSomme_Enter(object sender, EventArgs e)
        {
            if (txtSomme.Text == "N° Somme")
            {
                txtSomme.Text = "";
                txtSomme.ForeColor = Color.Black;
            }
        }

        private void txtCIN_Enter(object sender, EventArgs e)
        {
            if (txtCIN.Text == "N° CIN")
            {
                txtCIN.Text = "";
                txtCIN.ForeColor = Color.Black;
            }
        }

        private void txtCCP_Enter(object sender, EventArgs e)
        {
            if (txtCCP.Text == "N° CCP")
            {
                txtCCP.Text = "";
                txtCCP.ForeColor = Color.Black;
            }
        }

        private void txtCM_Enter(object sender, EventArgs e)
        {

            if (txtCM.Text == "N° C.Militaire")
            {
                txtCM.Text = "";
                txtCM.ForeColor = Color.Black;
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

        private void txtDateNaissance_Leave(object sender, EventArgs e)
        {
            if (txtDateNaissance.Text == "")
            {
                txtDateNaissance.Text = "Date de Naissance";
                txtDateNaissance.ForeColor = Color.Silver;
            }
        }

        private void txtLieuNaissance_Leave(object sender, EventArgs e)
        {
            if (txtLieuNaissance.Text == "")
            {
                txtLieuNaissance.Text = "Lieu de Naissance";
                txtLieuNaissance.ForeColor = Color.Silver;
            }
        }

        private void txtSomme_Leave(object sender, EventArgs e)
        {
            if (txtSomme.Text == "")
            {
                txtSomme.Text = "N° Somme";
                txtSomme.ForeColor = Color.Silver;
            }
        }

        private void txtCIN_Leave(object sender, EventArgs e)
        {
            if (txtCIN.Text == "")
            {
                txtCIN.Text = "N° CIN";
                txtCIN.ForeColor = Color.Silver;
            }
        }

        private void txtCCP_Leave(object sender, EventArgs e)
        {
            if (txtCCP.Text == "")
            {
                txtCCP.Text = "N° CCP";
                txtCCP.ForeColor = Color.Silver;
            }
        }

        private void txtCM_Leave(object sender, EventArgs e)
        {
            if (txtCM.Text == "")
            {
                txtCM.Text = "N° C.Militaire";
                txtCM.ForeColor = Color.Silver;
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

        private void cmbNom_Enter(object sender, EventArgs e)
        {
            cmbNom.ForeColor = Color.Black;
        }

        private void cmbPrenom_Enter(object sender, EventArgs e)
        {
            cmbPrenom.ForeColor = Color.Black;
        }
        private void cmbRegion_Enter(object sender, EventArgs e)
        {
            cmbRegion.ForeColor = Color.Black;
        }

 private void cmbVille_Enter(object sender, EventArgs e)
        {
            cmbVille.ForeColor = Color.Black;
        }


private void cmbGSanguin_Enter(object sender, EventArgs e)
        {
            cmbGSanguin.ForeColor = Color.Black;
        }




        #endregion

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVille.Enabled = true;
            db = new Db_EleveBookEntities4();
            int cid;
            bool parseOk = Int32.TryParse(cmbRegion.SelectedValue.ToString(), out cid);

            var stateName = from st in db.RProvinces where st.rgID.Value.Equals(cid) select new { st.Id, st.province };
            var comboState = stateName.ToList();


            if (comboState.Count > 0)
            {
                cmbVille.DataSource = comboState;
                cmbVille.DisplayMember = "province";
                cmbVille.ValueMember = "Id";
            }

        }
    }
    

}
