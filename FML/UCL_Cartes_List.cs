using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eleve_Book.FM
{
    public partial class UCL_Cartes_List : UserControl
    {
        private static UCL_Cartes_List UserCartes;
        private Db_EleveBookEntities4 db;
        LR_CartesTable REt = new LR_CartesTable();

        public static int IDselectCarte;


        public UCL_Cartes_List()
        {
            InitializeComponent();
        }

                //creer instance pour usercontrole
        public static UCL_Cartes_List Instance
        {
            get
            {
                if (UserCartes == null)
                {
                    UserCartes = new UCL_Cartes_List();
                }
                return UserCartes;
            }
        }

        private void UCL_Cartes_List_Load(object sender, EventArgs e)
        {
            cmbRecheche.SelectedIndex = 0;
            ActualiserDataGridViewCartes();
            pnlImage.Visible = false;
        }

        private string SelectVerifier()
        {
            int NombrelignesSelectionnés = 0;
            for (int i = 0; i < dgvRC.Rows.Count; i++)
            {
                //Rows[i].Cells[0] == colonne "ID select sur datagridView"
                if ((bool)dgvRC.Rows[i].Cells[0].Value == true)
                {
                    NombrelignesSelectionnés++;
                }
            }
            if (NombrelignesSelectionnés == 0)
            {
                return "Veuillez Selectionner un Eleve !!";
            }
            if (NombrelignesSelectionnés > 1)
            {
                return "Veuillez Selectioner un seul Elève !!";
            }
            return null;
        }

        public void ActualiserDataGridViewCartes()
        {
            db = new Db_EleveBookEntities4();
            dgvRC.Rows.Clear();

            foreach (var l in db.LR_CartesTable)
            {
                dgvRC.Rows.Add(false,null, l.Id, l.Nom_Eleve,l.Prenom_Eleve, l.CIN1_Eleve, l.CIN2_Eleve, l.CMIL1_Eleve, l.CMIL2_Eleve, l.CMUT1_Eleve, l.CMUT2_Eleve, l.Passeport_Eleve,l.Autres); ;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FRML_CartesAjouterModifier frmC = new FRML_CartesAjouterModifier(this);
            frmC.btnActualiser_Click(sender, e);

            frmC.ShowDialog();
        }

        public string Nom;
        private void btnModifier_Click(object sender, EventArgs e)
        {
            LR_CartesTable RC = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FRML_CartesAjouterModifier frmC = new FRML_CartesAjouterModifier(this);
                frmC.lblTitreCartes.Text = "MODIFIER DES CARTES";  // ???????????????????
                frmC.btnActualiser.Visible = false;

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {

                        IDselectCarte = (int)dgvRC.Rows[i].Cells[2].Value;  //row de select
                        
                       
                        RC = db.LR_CartesTable.SingleOrDefault(s => s.Id == IDselectCarte);
                        if (RC != null)
                        {
                            frmC.cmbNom.Text = dgvRC.Rows[i].Cells[3].Value.ToString();
                            frmC.cmbPrenom.Text = dgvRC.Rows[i].Cells[4].Value.ToString();
                            frmC.txtAutres.Text = dgvRC.Rows[i].Cells[12].Value.ToString();
                            try
                            {
                                if (RC.CIN1_Eleve != null)
                                {
                                    MemoryStream ms1 = new MemoryStream(RC.CIN1_Eleve); //convertir & display
                                    frmC.imgCIN1.Image = Image.FromStream(ms1);
                                }

                                if (RC.CIN2_Eleve != null)
                                {
                                    MemoryStream ms2 = new MemoryStream(RC.CIN2_Eleve);
                                    frmC.imgCIN2.Image = Image.FromStream(ms2);
                                }

                                if (RC.CMIL1_Eleve != null)
                                {
                                    MemoryStream ms3 = new MemoryStream(RC.CMIL1_Eleve);
                                    frmC.imgCMIL1.Image = Image.FromStream(ms3);
                                }
                                if (RC.CMIL2_Eleve != null)
                                {
                                    MemoryStream ms4 = new MemoryStream(RC.CMIL2_Eleve);
                                    frmC.imgCMIL2.Image = Image.FromStream(ms4);
                                }

                                if (RC.CMUT1_Eleve != null)
                                {
                                    MemoryStream ms5 = new MemoryStream(RC.CMUT1_Eleve);
                                    frmC.imgCMUT1.Image = Image.FromStream(ms5);
                                }
                                if (RC.CMUT2_Eleve != null)
                                {
                                    MemoryStream ms6 = new MemoryStream(RC.CMUT2_Eleve);
                                    frmC.imgCMUT2.Image = Image.FromStream(ms6);
                                }
                                if (RC.Passeport_Eleve != null)
                                {
                                    MemoryStream ms7 = new MemoryStream(RC.Passeport_Eleve);
                                    frmC.imgPasseport.Image = Image.FromStream(ms7);
                                }

                            }
                            catch 
                            {
                                MessageBox.Show("Echec du telechargement des Images!!!", "TELECHARGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                           
                        }
                    }
                }
                frmC.ShowDialog();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (SelectVerifier() == "Veuillez Selectionner un Eleve !!")
            {
                MessageBox.Show(SelectVerifier(), "SUPPRESSION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Etes-vous sur de supprimer!!", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    for (int i = 0; i < dgvRC.Rows.Count; i++) //nombre de ligne selectionnées
                    {
                        if ((bool)dgvRC.Rows[i].Cells[0].Value == true) //si ya ule ligne selectionnée
                        {
                            CL.CLSL_R_CartesTable CLSL_RC = new CL.CLSL_R_CartesTable();
                            int idSelect = (int)dgvRC.Rows[i].Cells[2].Value;
                            CLSL_RC.supprimer_RC(idSelect);  // sur classe database
                        }

                    }


                    ActualiserDataGridViewCartes();
                    MessageBox.Show("Elève supprimé avec succès", "SUPPRESSION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulée", "SUPPRESSION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbRecheche_SelectedIndexChanged(object sender, EventArgs e)
        {
            // activet le text de recherche si une option est choisie
            txtRecherche.Enabled = true;
            txtRecherche.Text = "";
        }

        private void txtRecherche_Enter(object sender, EventArgs e)
        {
            if (txtRecherche.Text == "Rechercher")
            {
                txtRecherche.Text = "";
                txtRecherche.ForeColor = Color.Black;
            }
        }

        private void txtRecherche_Leave(object sender, EventArgs e)
        {
            /*
            txtRecherche.Text = "Rechercher";
            txtRecherche.ForeColor = Color.Silver;
            */
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new Db_EleveBookEntities4();
            var listeRecherche = db.LR_CartesTable.ToList();  //liste de recherche == liste des eleves
            if (txtRecherche.Text != "")
            {
                switch (cmbRecheche.Text)
                {

                    case "NOM":
                        listeRecherche = listeRecherche.Where(s => s.Nom_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                }
            }
            dgvRC.Rows.Clear();
            //ajouter liste de rechrche dans dataGridView
            foreach (var l in listeRecherche)
            {
                dgvRC.Rows.Add(false,null, l.Id, l.Nom_Eleve,l.Prenom_Eleve, l.CIN1_Eleve, l.CIN2_Eleve, l.CMIL1_Eleve, l.CMIL2_Eleve, l.CMUT1_Eleve, l.CMUT2_Eleve, l.Passeport_Eleve,l.Autres); 
            }
        }

      

        private void btnCIN1_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);
                        if (rc != null) // s'il existe
                        {
                          
                            if (rc.CIN1_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.CIN1_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!","CONTENU VIDE",MessageBoxButtons.OK,MessageBoxIcon.Exclamation) ;
                                pnlImage.Visible = false;
                            }
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnClosePanelImage_Click(object sender, EventArgs e)
        {
            pnlImage.Visible = false;
        }

        private void btnCIN2_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);

                        if (rc != null) // s'il existe
                        {
                            if (rc.CIN2_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.CIN2_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!", "CONTENU VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pnlImage.Visible = false;
                            }
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnCMIL1_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);
                        if (rc != null) // s'il existe
                        {
                           
                            if (rc.CMIL1_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.CMIL1_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!", "CONTENU VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pnlImage.Visible = false;
                            }
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnCMIL2_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);
                        if (rc != null) // s'il existe
                        {
                            if (rc.CMIL2_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.CMIL2_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!", "CONTENU VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pnlImage.Visible = false;
                            }
                              
                           
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnCMUT1_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);
                        if (rc != null) // s'il existe
                        {
                           
                            if (rc.CMUT1_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.CMUT1_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!", "CONTENU VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pnlImage.Visible = false;
                            }
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnMUT2_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);
                        if (rc != null) // s'il existe
                        {
                           
                            if (rc.CMUT2_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.CMUT2_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!", "CONTENU VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pnlImage.Visible = false;
                            }
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnPasseport_Click(object sender, EventArgs e)
        {
            LR_CartesTable rc = new LR_CartesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "Selectionner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pnlImage.Visible = true;
                pnlImage.BringToFront();

                for (int i = 0; i < dgvRC.Rows.Count; i++)
                {
                    if ((bool)dgvRC.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {
                        int MYIDSELECT = (int)dgvRC.Rows[i].Cells[2].Value;
                        rc = db.LR_CartesTable.SingleOrDefault(s => s.Id == MYIDSELECT);
                        if (rc != null) // s'il existe
                        {
                          
                            if (rc.Passeport_Eleve != null)
                            {
                                MemoryStream ms = new MemoryStream(rc.Passeport_Eleve);
                                imgProfil.Image = System.Drawing.Image.FromStream(ms);
                            }
                            else
                            {
                                imgProfil.Image = null;
                                MessageBox.Show("Contenu vide; Veuillez renseigner cet image !!", "CONTENU VIDE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                pnlImage.Visible = false;
                            }
                            lblNomProfil.Text = "L'E/O  " + dgvRC.Rows[i].Cells[3].Value.ToString().ToUpper() + " " + dgvRC.Rows[i].Cells[4].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnTtriNom_Click(object sender, EventArgs e)
        {
            dgvRC.Sort(dgvRC.Columns[3], ListSortDirection.Ascending);
        }

        private void dgvRC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvRC.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }
    }
}
