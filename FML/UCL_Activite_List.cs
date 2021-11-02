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
    public partial class UCL_Activite_List : UserControl
    {
        private static UCL_Activite_List UserRAct;
        private Db_EleveBookEntities4 db;
        public static int IDselect;

      
            
        public static string paraUC,aguerrissemntUC, corveteEte, semaineEleve, gantBlanc, permisConduire, najeur, fumeur;    

    
        public UCL_Activite_List()
        {
            InitializeComponent();
           
            txtRecherche.Enabled = false;
            db = new Db_EleveBookEntities4();
           
    }

        private void UCL_Activite_List_Load(object sender, EventArgs e)
        {
            cmbRecheche.SelectedIndex = 0;
            ActualiserDataGridViewAct();
            txtRecherche.Enabled = false;
        }

     
        public static UCL_Activite_List Instance
        {
            get
            {
                if (UserRAct == null)
                {
                    UserRAct = new UCL_Activite_List();
                }
                return UserRAct;
            }
        }

       
        public void ActualiserDataGridViewAct()
        {
            db = new Db_EleveBookEntities4();
            dgvRAList.Rows.Clear();

            foreach (var s in db.LR_Activites)
            {
                dgvRAList.Rows.Add(false,null, s.Id, s.Nom_Eleve, s.Prenom_Eleve, s.Parachutisme, s.Aguerissement_marin, s.Corvette_ete, s.Semaine_eleve, s.Gant_blanc, s.Permis_conduire,s.Najeur,s.Fumeur, s.Autres);
            }
        }

        //vérifie et compte le nombre de ligne selectionnées
        public string SelectVerifier()
        {
            int NombrelignesSelectionnés = 0;
            for (int i = 0; i < dgvRAList.Rows.Count; i++)
            {
                //Rows[i].Cells[0] == colonne "ID select sur datagridView"
                if ((bool)dgvRAList.Rows[i].Cells[0].Value == true)
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FRML_ActiviteAjouterModifier frc = new FRML_ActiviteAjouterModifier(this);
            frc.btnActualiser_Click(sender, e);
            frc.ShowDialog();
        }

      

        private void btnModifier_Click(object sender, EventArgs e)
        {
            LR_Activites RE = new LR_Activites();
           

            if (SelectVerifier() != null)
            {
                MessageBox.Show(SelectVerifier(), "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FRML_ActiviteAjouterModifier frmRA = new FRML_ActiviteAjouterModifier(this);
                frmRA.lblTitre.Text = "MODIFIER UNE ACTIVITE";
                frmRA.btnActualiser.Visible = false;
                frmRA.cmbNom.Enabled = false;

                for (int i = 0; i < dgvRAList.Rows.Count; i++)
                {
                    if ((bool)dgvRAList.Rows[i].Cells[0].Value == true) // si ligne selectionnée
                    {

                        IDselect = (int)dgvRAList.Rows[i].Cells[2].Value;  //row de select

                        RE = db.LR_Activites.SingleOrDefault(s => s.Id == IDselect);
                        

                        if (RE != null)
                        {
                             
                            frmRA.cmbNom.Text = dgvRAList.Rows[i].Cells[3].Value.ToString();                          
                            frmRA.cmbPrenom.Text = dgvRAList.Rows[i].Cells[4].Value.ToString();

                          
                            paraUC = dgvRAList.Rows[i].Cells[5].Value.ToString(); 
                            //////
                            
                        
                            ////////////                            
                            
                            aguerrissemntUC = dgvRAList.Rows[i].Cells[6].Value.ToString();
                            if (aguerrissemntUC == "X")
                                frmRA.cbAguerissement.Checked = true;
                            else
                                frmRA.cbAguerissement.Checked = false;

                            corveteEte = dgvRAList.Rows[i].Cells[7].Value.ToString();
                            if (corveteEte == "X")
                                frmRA.cbCorvetteEte.Checked = true;
                            else
                                frmRA.cbCorvetteEte.Checked = false;

                          semaineEleve = dgvRAList.Rows[i].Cells[8].Value.ToString();
                            if (semaineEleve == "X")
                                frmRA.cbSemaineEleve.Checked = true;
                            else
                                frmRA.cbSemaineEleve.Checked = false;

                           gantBlanc = dgvRAList.Rows[i].Cells[9].Value.ToString();
                            if (gantBlanc == "X")
                                frmRA.cbGuantsBlancs.Checked = true;
                            else
                                frmRA.cbGuantsBlancs.Checked = false;

                           permisConduire = dgvRAList.Rows[i].Cells[10].Value.ToString();
                            if (permisConduire == "X")
                                frmRA.cbPermisConduire.Checked = true;
                            else
                                frmRA.cbPermisConduire.Checked = false;

                           najeur = dgvRAList.Rows[i].Cells[11].Value.ToString();
                            if (najeur == "X")
                                frmRA.cbNajeur.Checked = true;
                            else
                                frmRA.cbNajeur.Checked = false;

                            fumeur = dgvRAList.Rows[i].Cells[12].Value.ToString();
                            if (fumeur == "X")
                                frmRA.cbFumeur.Checked = true;
                            else
                                frmRA.cbFumeur.Checked = false;

                            frmRA.txtAutres.Text = dgvRAList.Rows[i].Cells[13].Value.ToString();                        


                        }
                    }
                }
                frmRA.ShowDialog();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (SelectVerifier() == "Veuillez Selectionner un Elève !!")
            {
                MessageBox.Show(SelectVerifier(), "SUPPRESSION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("êtes vous sûr de supprimer!!", "SUPPRESSION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    for (int i = 0; i < dgvRAList.Rows.Count; i++) //nombre de ligne selectionnées
                    {
                        if ((bool)dgvRAList.Rows[i].Cells[0].Value == true) //si ya ule ligne selectionnée
                        {
                            CL.CLSL_ActivitesTable cLS_Act = new CL.CLSL_ActivitesTable();
                            int idSelect = (int)dgvRAList.Rows[i].Cells[2].Value;
                            cLS_Act.supprimer_Eleve(idSelect);  // sur classe database
                        }

                    }


                    ActualiserDataGridViewAct();
                    MessageBox.Show("Elève supprimé avec succès", "SUPPRESSION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Suppression annulée", "SUPPRESSION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                        ws.Cells[1, 3] = "PARACHUTISME";
                        ws.Cells[1, 4] = "AGUERISSEMENT";
                        ws.Cells[1, 5] = "CORVETTE ETE";
                        ws.Cells[1, 6] = "SEMAINE ELEVE";
                        ws.Cells[1, 7] = "GANTS BLANCS";
                        ws.Cells[1, 8] = "PERMIS DE CONDUIRE";
                        ws.Cells[1, 9] = "NAJEUR";
                        ws.Cells[1, 10] = "FUMEUR";
                        ws.Cells[1, 11] = "AUTRES";

                        //remplir tableau excelavec des données de la base de donnée
                        var lisetRE = db.LR_Activites.ToList();
                        int i = 2;
                        foreach (var l in lisetRE)
                        {
                            ws.Cells[i, 1] = l.Nom_Eleve;
                            ws.Cells[i, 2] = l.Prenom_Eleve;
                            ws.Cells[i, 3] = l.Parachutisme;
                            ws.Cells[i, 4] = l.Aguerissement_marin;
                            ws.Cells[i, 5] = l.Corvette_ete;
                            ws.Cells[i, 6] = l.Semaine_eleve;
                            ws.Cells[i, 7] = l.Gant_blanc;
                            ws.Cells[i, 8] = l.Permis_conduire;
                            ws.Cells[i, 9] = l.Najeur;
                            ws.Cells[i, 10] = l.Fumeur;
                            ws.Cells[i, 11] = l.Autres;
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

        private void btnRapportTout_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.LR_Activites.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_ra_tout.rdlc";
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

        private void btnRapportNajeur_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.LR_Activites.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_ra_najeur.rdlc";
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

        private void btnRapportFumeur_Click(object sender, EventArgs e)
        {
            try
            {
                Rapport.FRM_RapportRE frmRE = new Rapport.FRM_RapportRE();
                db = new Db_EleveBookEntities4();
                var listREEleves = db.LR_Activites.ToList();
                frmRE.RPafficher.LocalReport.ReportEmbeddedResource = "Eleve_Book.Rapport.rptl_ra_fumeur.rdlc";
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
            btnRapportTout_Click(sender, e);
        }



        private void btnTtriNom_Click(object sender, EventArgs e)
        {
            dgvRAList.Sort(dgvRAList.Columns[3], ListSortDirection.Ascending);
        }

        private void btnTriNajeur_Click(object sender, EventArgs e)
        {
            dgvRAList.Sort(dgvRAList.Columns[11], ListSortDirection.Ascending);
        }

        private void btnTriFumeur_Click(object sender, EventArgs e)
        {
            dgvRAList.Sort(dgvRAList.Columns[12], ListSortDirection.Ascending);
        }

        private void dgvRAList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvRAList.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }


    }
}
