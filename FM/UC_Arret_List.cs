using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
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
    public partial class UC_Arret_List : UserControl
    {
       private static UC_Arret_List UserArret;
        private Db_EleveBookEntities4 db;
        R_ArretTable RS = new R_ArretTable();
        public static int IDselect;

        public UC_Arret_List()
        {
            InitializeComponent();
            txtRecherche.Enabled = false;
            db = new Db_EleveBookEntities4(); //instantiate database
        }
        //creer instance pour usercontrole
        public static UC_Arret_List Instance
        {
            get
            {
                if (UserArret == null)
                {
                    UserArret = new UC_Arret_List();
                }
                return UserArret;
            }
        }

        private void UC_Arret_List_Load(object sender, EventArgs e)
        {
            cmbRecheche.SelectedIndex = 0;
            ActualiserDataGridView();
        }

        private string SelectVerifier()
        {
            int NombrelignesSelectionnés = 0;
            for (int i = 0; i < dgvArret.Rows.Count; i++)
            {
                //Rows[i].Cells[0] == colonne "ID select sur datagridView"
                if ((bool)dgvArret.Rows[i].Cells[0].Value == true)
                {
                    NombrelignesSelectionnés++;
                }
            }
            if (NombrelignesSelectionnés == 0)
            {
                return " Veuillez Selectionner un Elève !!";
            }
            if (NombrelignesSelectionnés > 1)
            {
                return " Veuillez Selectionner un seul Elève !!";
            }
            return null;
        }

        public void ActualiserDataGridView()
        {
            db = new Db_EleveBookEntities4();
            dgvArret.Rows.Clear();

            foreach (var l in db.R_ArretTable)
            {
                dgvArret.Rows.Add(false,null, l.Id, l.Nom_Eleve,l.Prenom_Eleve, l.Punition_Eleve, l.motifArret_Eleve, l.DateArret_Eleve, l.AutoriteArret_Eleve,l.Autres);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FRM_ArretAjoutetModifier2 frmArret = new FRM_ArretAjoutetModifier2(this);
             frmArret.btnActualiser_Click(sender, e);

            frmArret.ShowDialog();
           
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            R_ArretTable RS = new R_ArretTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FRM_ArretAjoutetModifier2 frmRF = new FRM_ArretAjoutetModifier2(this);
                frmRF.lblTitre.Text = "MODIFIER UNE PUNITION";
                frmRF.btnActualiser.Visible = false;

                for (int i = 0; i < dgvArret.Rows.Count; i++)
                {
                    if ((bool)dgvArret.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {

                        IDselect = (int)dgvArret.Rows[i].Cells[2].Value;  //row de select

                        RS = db.R_ArretTable.SingleOrDefault(s => s.Id == IDselect);
                        if (RS != null)
                        {
                            frmRF.cmbNom.Text = dgvArret.Rows[i].Cells[3].Value.ToString();
                            frmRF.cmbPrenom.Text = dgvArret.Rows[i].Cells[4].Value.ToString();
                            //frmRS.cmbNom.Enabled = false;  //ne pas autoriser a modifier clée primaire
                            frmRF.cmbPunition.Text = dgvArret.Rows[i].Cells[5].Value.ToString();
                            frmRF.txtMotif.Text = dgvArret.Rows[i].Cells[6].Value.ToString();
                            frmRF.txtDate.Text = dgvArret.Rows[i].Cells[7].Value.ToString();
                            frmRF.txtAutorite.Text = dgvArret.Rows[i].Cells[8].Value.ToString();
                            frmRF.txtAutres.Text = dgvArret.Rows[i].Cells[9].Value.ToString();
                        }
                    }
                }
                frmRF.ShowDialog();
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
                DialogResult dr = MessageBox.Show("Etes vous sur de supprimer!!", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    for (int i = 0; i < dgvArret.Rows.Count; i++) //nombre de ligne selectionnées
                    {
                        if ((bool)dgvArret.Rows[i].Cells[0].Value == true) //si ya ule ligne selectionnée
                        {
                            CL.CLS_ArretTable cLS_Arret = new CL.CLS_ArretTable();
                            int idSelect = (int)dgvArret.Rows[i].Cells[2].Value;
                            cLS_Arret.supprimer_RArret(idSelect);  // sur classe database
                        }

                    }


                    ActualiserDataGridView();
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
            txtRecherche.ForeColor = Color.Silver
            */
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new Db_EleveBookEntities4();
            var listeRecherche = db.R_ArretTable.ToList();  //liste de recherche == liste des eleves
            if (txtRecherche.Text != "")
            {
                switch (cmbRecheche.Text)
                {
                    case "NOM":
                        listeRecherche = listeRecherche.Where(s => s.Nom_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;
                    case "DATE":
                        listeRecherche = listeRecherche.Where(s => s.DateArret_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "PUNITION":
                        listeRecherche = listeRecherche.Where(s => s.Punition_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "MOTIF":
                        listeRecherche = listeRecherche.Where(s => s.motifArret_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "AUTORITE":
                        listeRecherche = listeRecherche.Where(s => s.AutoriteArret_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;
                }
            }
            dgvArret.Rows.Clear();
            //ajouter liste de rechrche dans dataGridView
            foreach (var l in listeRecherche)
            {
                dgvArret.Rows.Add(false,null, l.Id, l.Nom_Eleve,l.Prenom_Eleve, l.Punition_Eleve, l.motifArret_Eleve, l.DateArret_Eleve, l.AutoriteArret_Eleve); //false= chechbox non coché
            }
        }

       

        private void btnExcel_Click(object sender, EventArgs e)
        {
            db = new Db_EleveBookEntities4();
            //download nuget "microsoft.ofice.interop.exec"
            try
            {
                using (SaveFileDialog SFD = new SaveFileDialog() { Filter = "Excel Workbook | *.xlsx", ValidateNames = true })
                {
                    if (SFD.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                        Worksheet ws = (Worksheet)app.ActiveSheet;
                        app.Visible = false;


                        //add  rows to exel file
                        ws.Cells[1, 1] = "NOM";
                        ws.Cells[1, 2] = "PRENOM";
                        ws.Cells[1, 3] = "PUNITION";
                        ws.Cells[1, 4] = "MOTIF";
                        ws.Cells[1, 5] = "DATE";
                        ws.Cells[1, 6] = "AUTORITE";                       
                        ws.Cells[1, 17] = "AUTRES";

                        //remplir tableau excelavec des données de la base de donnée
                        var lisetRE = db.R_ArretTable.ToList();
                        int i = 2;
                        foreach (var l in lisetRE)
                        {
                            ws.Cells[i, 1] = l.Nom_Eleve;
                            ws.Cells[i, 2] = l.Prenom_Eleve;
                            ws.Cells[i, 3] = l.Punition_Eleve;
                            ws.Cells[i, 4] = l.motifArret_Eleve;
                            ws.Cells[i, 5] = l.DateArret_Eleve;
                            ws.Cells[i, 6] = l.AutoriteArret_Eleve;                           
                            ws.Cells[i, 13] = l.Autres;
                            i++;
                        }

                        //-----stylyser excel-----------------------------------
                        ws.Range["A1:D1"].Interior.Color = Color.Blue; //bachground color
                                                                       // RANGE A1:D1 = 1ERE LIGNE
                        ws.Range["A1:D1"].Interior.Color = Color.White; // FORECOLOR
                        ws.Range["A1:D1"].Font.Size = 15;
                        ws.Range["A:D"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        //ws.Range["A1:D1"].Column.Width = 16;

                        //-------------------------------------------------
                        wb.SaveAs(SFD.FileName);
                        app.Quit();
                        MessageBox.Show("Sauvegarder avec succès dans EXCEL", "EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }

                }
            }
            catch
            {
                MessageBox.Show("Microssoft Excel non trouvé sur votre Machine", "EXCEL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRapportTOUT_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.R_ArretTable.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rpt_arret_tout.rdlc";
                frmRE.RPafficher.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", listREEleves));
                //ReportParameter date = new ReportParameter("date", DateTime.Now.ToString());
                //frmRE.RPafficher.LocalReport.SetParameters(new ReportParameter[] { date });
                frmRE.RPafficher.RefreshReport();
                frmRE.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            btnRapportTOUT_Click(sender, e);
        }

        private void btnRapportEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnTtriNom_Click(object sender, EventArgs e)
        {
            dgvArret.Sort(dgvArret.Columns[3], ListSortDirection.Ascending);
        }

        private void btnTriPunition_Click(object sender, EventArgs e)
        {
            dgvArret.Sort(dgvArret.Columns[5], ListSortDirection.Ascending);
        }

        private void btnTriDate_Click(object sender, EventArgs e)
        {
            dgvArret.Sort(dgvArret.Columns[6], ListSortDirection.Ascending);
        }

        private void dgvArret_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvArret.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }
    }
}
