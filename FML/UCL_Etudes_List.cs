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
    public partial class UCL_Etudes_List : UserControl
    {
        private static UCL_Etudes_List UserREt;
        private Db_EleveBookEntities4 db;
        LR_EtudesTable REt = new LR_EtudesTable();

        public static int IDselectREt;

        public UCL_Etudes_List()
        {
            InitializeComponent();
        }

        //creer instance pour usercontrole
        public static UCL_Etudes_List Instance
        {
            get
            {
                if (UserREt == null)
                {
                    UserREt = new UCL_Etudes_List();
                }
                return UserREt;
            }
        }

        private void UCL_Etudes_List_Load(object sender, EventArgs e)
        {
            cmbRecheche.SelectedIndex = 0;
            ActualiserDataGridViewEtudes();
        }

        private string SelectVerifier()
        {
            int NombrelignesSelectionnés = 0;
            for (int i = 0; i < dgvREtudesList.Rows.Count; i++)
            {
                //Rows[i].Cells[0] == colonne "ID select sur datagridView"
                if ((bool)dgvREtudesList.Rows[i].Cells[0].Value == true)
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

        public void ActualiserDataGridViewEtudes()
        {
            db = new Db_EleveBookEntities4();
            dgvREtudesList.Rows.Clear();

            foreach (var l in db.LR_EtudesTable)
            {
                dgvREtudesList.Rows.Add(false, null, l.Id, l.Nom_Eleve, l.Prenom_Eleve, l.classe_Eleve, l.Option_Eleve, l.Filiere_Eleve, l.SousOption_Eleve, l.AnneeBac_Eleve, l.FiliereBac_Eleve, l.NoteBac_Eleve, l.Lycee_Eleve, l.Note_1A_Eleve, l.Note_2A_Eleve, l.Note_3A_Eleve, l.Note_4A_Eleve, l.Note_5A_Eleve, l.Note_5A_Eleve, l.Autres);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FRML_EtudesAjouterModifier frmREt = new FRML_EtudesAjouterModifier(this);
            frmREt.btnActualiser_Click(sender, e);

            frmREt.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            LR_EtudesTable RS = new LR_EtudesTable();
            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FRML_EtudesAjouterModifier frmREt = new FRML_EtudesAjouterModifier(this);
                frmREt.lblTitreREtudes.Text = "MODIFIER DES DONNEES FAMILIALES";
                frmREt.btnActualiser.Visible = false;

                for (int i = 0; i < dgvREtudesList.Rows.Count; i++)
                {
                    if ((bool)dgvREtudesList.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {

                        IDselectREt = (int)dgvREtudesList.Rows[i].Cells[2].Value;  //row de select

                        RS = db.LR_EtudesTable.SingleOrDefault(s => s.Id == IDselectREt);
                        if (RS != null)
                        {
                            frmREt.cmbNom.Text = dgvREtudesList.Rows[i].Cells[3].Value.ToString();
                            frmREt.cmbPrenom.Text = dgvREtudesList.Rows[i].Cells[4].Value.ToString();
                            //frmRS.cmbNom.Enabled = false;  //ne pas autoriser a modifier clée primaire
                            frmREt.cmbClassEleve.Text = dgvREtudesList.Rows[i].Cells[5].Value.ToString();
                            frmREt.cmbOption.Text = dgvREtudesList.Rows[i].Cells[6].Value.ToString();
                            frmREt.cmbFiliere.Text = dgvREtudesList.Rows[i].Cells[7].Value.ToString();
                            frmREt.cmbSousOption.Text = dgvREtudesList.Rows[i].Cells[8].Value.ToString();
                            frmREt.cmbAnneeBac.Text = dgvREtudesList.Rows[i].Cells[9].Value.ToString();
                            frmREt.cmbFilereBac.Text = dgvREtudesList.Rows[i].Cells[10].Value.ToString();
                            frmREt.txtNoteBac.Text = dgvREtudesList.Rows[i].Cells[11].Value.ToString();
                            frmREt.txtLycee.Text = dgvREtudesList.Rows[i].Cells[12].Value.ToString();
                            frmREt.txtNote1A.Text = dgvREtudesList.Rows[i].Cells[13].Value.ToString();
                            frmREt.txtNote2A.Text = dgvREtudesList.Rows[i].Cells[14].Value.ToString();
                            frmREt.txtNote3A.Text = dgvREtudesList.Rows[i].Cells[15].Value.ToString();
                            frmREt.txtNote4A.Text = dgvREtudesList.Rows[i].Cells[16].Value.ToString();
                            frmREt.txtNote5A.Text = dgvREtudesList.Rows[i].Cells[17].Value.ToString();
                            frmREt.txtNoteBac.Text = dgvREtudesList.Rows[i].Cells[18].Value.ToString();
                            frmREt.txtAutres.Text  = dgvREtudesList.Rows[i].Cells[19].Value.ToString();

                        }
                    }
                }
                frmREt.ShowDialog();
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

                    for (int i = 0; i < dgvREtudesList.Rows.Count; i++) //nombre de ligne selectionnées
                    {
                        if ((bool)dgvREtudesList.Rows[i].Cells[0].Value == true) //si ya ule ligne selectionnée
                        {
                            CL.CLSL_R_EtudesTable cLS_REt = new CL.CLSL_R_EtudesTable();
                            int idSelect = (int)dgvREtudesList.Rows[i].Cells[2].Value;
                            cLS_REt.supprimer_Et(idSelect);  // sur classe database
                        }

                    }


                    ActualiserDataGridViewEtudes();
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
            txtRecherche.Text = "Rechercher";
            txtRecherche.ForeColor = Color.Silver;
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            db = new Db_EleveBookEntities4();
            var listeRecherche = db.LR_EtudesTable.ToList();  //liste de recherche == liste des eleves
            if (txtRecherche.Text != "")
            {
                switch (cmbRecheche.Text)
                {

                    case "NOM":
                        listeRecherche = listeRecherche.Where(s => s.Nom_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "CLASSE":
                        listeRecherche = listeRecherche.Where(s => s.classe_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;



                    case "OPTION":
                        listeRecherche = listeRecherche.Where(s => s.Option_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "FILIERE":
                        listeRecherche = listeRecherche.Where(s => s.Filiere_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "SOUS-OPTION":
                        listeRecherche = listeRecherche.Where(s => s.SousOption_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;

                    case "FILIERE BAC":
                        listeRecherche = listeRecherche.Where(s => s.FiliereBac_Eleve.IndexOf(txtRecherche.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                        //fait comparaison du nom recherché avec les nom de la liste meme avec qlq lettres
                        break;
                }
            }
            dgvREtudesList.Rows.Clear();
            //ajouter liste de rechrche dans dataGridView
            foreach (var l in listeRecherche)
            {
                dgvREtudesList.Rows.Add(false,null, l.Id,l.Nom_Eleve,l.Prenom_Eleve, l.classe_Eleve, l.Option_Eleve, l.FiliereBac_Eleve, l.SousOption_Eleve, l.AnneeBac_Eleve, l.FiliereBac_Eleve, l.NoteBac_Eleve, l.Lycee_Eleve, l.Note_1A_Eleve, l.Note_2A_Eleve, l.Note_3A_Eleve, l.Note_4A_Eleve, l.Note_5A_Eleve, l.Note_5A_Eleve,l.Autres); //false= chechbox non coché
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
                        ws.Cells[1, 3] = "CLASSE";
                        ws.Cells[1, 4] = "OPTION";
                        ws.Cells[1, 5] = "FILIERE";
                        ws.Cells[1, 6] = "SOUS-OPTION";                       
                        ws.Cells[1, 7] = "NOTE 1°ANNEE";
                        ws.Cells[1, 8] = "NOTE 2°ANNEE";
                        ws.Cells[1, 9] = "NOTE 3°ANNEE";
                        ws.Cells[1, 10] = "NOTE 4°ANNEE";
                        ws.Cells[1, 11] = "NOTE 5°ANNEE";
                        ws.Cells[1, 12] = "NOTE GLOBALE";
                        ws.Cells[1, 13] = "ANNEE BAC";
                        ws.Cells[1, 14] = "FILIERE BAC";
                        ws.Cells[1, 15] = "NOTE BAC";
                        ws.Cells[1, 16] = "LYCEE";
                        ws.Cells[1, 17] = "AUTRES";

                        //remplir tableau excelavec des données de la base de donnée
                        var lisetRE = db.LR_EtudesTable.ToList();
                        int i = 2;
                        foreach (var l in lisetRE)
                        {
                            ws.Cells[i, 1] = l.Nom_Eleve;
                            ws.Cells[i, 2] = l.Prenom_Eleve;
                            ws.Cells[i, 3] = l.classe_Eleve;
                            ws.Cells[i, 4] = l.Option_Eleve;
                            ws.Cells[i, 5] = l.Filiere_Eleve;
                            ws.Cells[i, 6] = l.SousOption_Eleve;
                            ws.Cells[i, 7] = l.Note_1A_Eleve;
                            ws.Cells[i, 8] = l.Note_2A_Eleve;
                            ws.Cells[i, 9] = l.Note_3A_Eleve;
                            ws.Cells[i, 10] = l.Note_4A_Eleve;
                            ws.Cells[i, 11] = l.Note_5A_Eleve;
                            ws.Cells[i, 12] = l.Note_Globale_Eleve;
                            ws.Cells[i, 11] = l.AnneeBac_Eleve;
                            ws.Cells[i, 11] = l.FiliereBac_Eleve;
                            ws.Cells[i, 11] = l.NoteBac_Eleve;
                            ws.Cells[i, 11] = l.Lycee_Eleve;
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
                        MessageBox.Show("Sauvegarder avecsucces dans EXCEL", "EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
                var listREEleves = db.R_EtudesTable.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_rEtude_tout.rdlc";
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
            btnRapportTOUT_Click( sender,  e);
        }

        private void btnRapportFiliere_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.LR_EtudesTable.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_rEtude_filiere.rdlc";
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

        private void btnRapportClasse_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.LR_EtudesTable.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_rEtude_classe.rdlc";
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

        private void btnRapportNotes_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.LR_EtudesTable.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_rEtudes_notes.rdlc";
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

        private void btnTtriNom_Click(object sender, EventArgs e)
        {
            dgvREtudesList.Sort(dgvREtudesList.Columns[3], ListSortDirection.Ascending);
        }

        private void btnTriclasse_Click(object sender, EventArgs e)
        {
            dgvREtudesList.Sort(dgvREtudesList.Columns[5], ListSortDirection.Ascending);
        }

        private void btnTriFiliere_Click(object sender, EventArgs e)
        {
            dgvREtudesList.Sort(dgvREtudesList.Columns[6], ListSortDirection.Ascending);
        }

        private void btnTtriOption_Click(object sender, EventArgs e)
        {
            dgvREtudesList.Sort(dgvREtudesList.Columns[7], ListSortDirection.Ascending);
        }

        private void dgvREtudesList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //colonne N° Qui s'incrément automatiquement==> datagridView event RowPrePaint
            dgvREtudesList.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }
    }
}
