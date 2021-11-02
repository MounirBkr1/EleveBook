using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eleve_Book.FM;
using Microsoft.Reporting.WinForms;

namespace Eleve_Book
{
    public partial class FRM_Menu : Form
    {
        private Db_EleveBookEntities4 db;
        private bool showHidePasword; // show or hide password

        bool cycleIngenieurSelected = false;//définir quel cycle est choisi

        public FRM_Menu()
        {
            InitializeComponent();
            customizeDesign();
            pnlBoule.Top = imgAcceuil.Top;
            pnlGauche.Size = new Size(1, 662);
            pnlConnexion.Visible = true;
            pnlCycle.Visible = false;


            DisableFormulaire();  //disable all
            db = new Db_EleveBookEntities4();
            btnSeConnecter.Enabled = false;

            txtNom.Text = "Nom d'utilisateur";
            txtNom.ForeColor = Color.Silver;
            txtMotdePasse.Text = "Mot de passe";
            txtNom.ForeColor = Color.Silver;
            showHidePasword = false;
            //btnShowHidePassword.Image = Properties.Resources.showPassword;

        }

        public void FRM_Menu_Load(object sender, EventArgs e)
        {
            //btnSeConnecter_Click(sender, e);  //afficher panel connexion

        }
        //desactiver et activer selon conexion
        public void DisableFormulaire()
        {
            //disable all
            imgAcceuil.Enabled = false;
            imgEleves.Enabled = false;
            imgProf.Enabled = false;
            imgEncadrant.Enabled = false;
            imgCyclIng.Enabled = false;
            imgcyclLic.Enabled = false;
            imgConnexion.Enabled = false;
            imgSlideReduceSize.Enabled = false;
            imgCyclIng.Visible = false;
            imgcyclLic.Visible=false;

            //panelAll.Visible = false;
            pnlLogo.Visible = false;
            pnlGauche.Size = new Size(1, 650);
            txtNom.Text = "Nom d'utilisateur";
            txtMotdePasse.Text = "Mot de passe";
        }
        public void EnableFormulaire()
        {
            imgAcceuil.Enabled = true;
            imgEleves.Enabled = true;
            imgProf.Enabled = true;
            imgEncadrant.Enabled = true;
            imgCyclIng.Enabled = true;
            imgcyclLic.Enabled = true;
            imgSlideReduceSize.Enabled = true;
            imgCyclIng.Visible = true;
            imgcyclLic.Visible = true;

            imgConnexion.Enabled = true;

            //panelAll.Visible = true;
            pnlLogo.Visible = true;
            pnlGauche.Size = new Size(269, 662);
        }

        //--------------------------------------
        private void customizeDesign()
        {
            pnlElevesCI.Visible = false;
            pnlElevesCL.Visible = false;
            pnlEleves.Visible = false;
            pnlConnexion.Visible = false;
          
        }

        private void CacherSousMenu()  //
        {
            if (pnlConnexion.Visible == true)
                pnlConnexion.Visible = false;
            if (pnlElevesCI.Visible == true)
                pnlElevesCI.Visible = false;
            if (pnlEleves.Visible == true)
                pnlEleves.Visible = false;
            if (pnlElevesCL.Visible == true)
                pnlElevesCL.Visible = false;
           
        }

        private void AfficherSousMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                CacherSousMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }



        private void btnConnexion_Click(object sender, EventArgs e)  //affiche le sous menu seulement
        {
            AfficherSousMenu(pnlConnexion);
            pnlBoule.Top = imgConnexion.Top;
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            pnlConexionCentre.Show();
        }

        private void rtnCopie_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
        }

        private void btnRestaurer_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
        }

        private void btnSeDeconecter_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private Form activeForm = null;
        public void OuvrirChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;

            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlAfficherListe.Controls.Add(childForm);
            pnlAfficherListe.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }




        private void btnAcceuil_Click(object sender, EventArgs e)
        {
     
        }

        private void btnEleves_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnProfesseurs_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEncadrants_Click(object sender, EventArgs e)
        {
          
        }

       

        #region BOUTTONS DU MENU QUI AFFICHE LES USERCONTROL
        private void btnRE_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UC_RE_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_RE_List.Instance);
                UC_RE_List.Instance.Dock = DockStyle.Fill;
                UC_RE_List.Instance.BringToFront();
            }
            else
            {
                UC_RE_List.Instance.BringToFront();
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_RS_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_RS_List.Instance);
                UC_RS_List.Instance.Dock = DockStyle.Fill;
                UC_RS_List.Instance.BringToFront();
            }
            else
            {
                UC_RS_List.Instance.BringToFront();
            }
        }

        private void btnRF_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_RF_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_RF_List.Instance);
                UC_RF_List.Instance.Dock = DockStyle.Fill;
                UC_RF_List.Instance.BringToFront();
            }
            else
            {
                UC_RF_List.Instance.BringToFront();
            }
        }

        private void btnEtudes_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_Etudes_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_Etudes_List.Instance);
                UC_Etudes_List.Instance.Dock = DockStyle.Fill;
                UC_Etudes_List.Instance.BringToFront();
            }
            else
            {
                UC_Etudes_List.Instance.BringToFront();
            }
        }

        private void btnCartes_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_Cartes_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_Cartes_List.Instance);
                UC_Cartes_List.Instance.Dock = DockStyle.Fill;
                UC_Cartes_List.Instance.BringToFront();
            }
            else
            {
                UC_Cartes_List.Instance.BringToFront();
            }
        }

        private void btnArrets_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_Arret_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_Arret_List.Instance);
                UC_Arret_List.Instance.Dock = DockStyle.Fill;
                UC_Arret_List.Instance.BringToFront();
            }
            else
            {
                UC_Arret_List.Instance.BringToFront();
            }
        }

        private void btnPTC_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_PTC_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_PTC_List.Instance);
                UC_PTC_List.Instance.Dock = DockStyle.Fill;
                UC_PTC_List.Instance.BringToFront();
            }
            else
            {
                UC_PTC_List.Instance.BringToFront();
            }
        }

        private void btnActivites_Click(object sender, EventArgs e)
        {
            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(Uc_Activite_List.Instance))
            {
                pnlAfficherListe.Controls.Add(Uc_Activite_List.Instance);
                Uc_Activite_List.Instance.Dock = DockStyle.Fill;
                Uc_Activite_List.Instance.BringToFront();
            }
            else
            {
                Uc_Activite_List.Instance.BringToFront();
            }
        }
        #endregion


     
    

        //****************************PANEL CONNEXION****************************************************************
        CL.CLS_Connexion c = new CL.CLS_Connexion();   //classe connexion

        private void btnConexion_Click(object sender, EventArgs e)
        {
            if (ChampsObligatoireConnexion() == null)
            {
                if (c.ConnexionValide(db, txtNom.Text, txtMotdePasse.Text) == true)//function dans la classe CLS_Connexion
                {

                    MessageBox.Show("   Connexion   réussie !! ", "CONNEXION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //EnableFormulaire();

                    pnlConexionCentre.Hide();

                    btnSeDeconecter.Enabled = true;
                   
                    pnlCycle.Visible = true;
                }
                else
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !!", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(ChampsObligatoireConnexion(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        String ChampsObligatoireConnexion()  //verifier si le champs mot de passe et login sont remplis
        {
            if ((txtNom.Text == "" || txtNom.Text == "Nom d'utilisateur") && (txtMotdePasse.Text == "" || txtMotdePasse.Text == "Mot de passe"))
            {
                return "Ces champs-là sont obligatoire";
            }
            else if (txtNom.Text == "" || txtNom.Text == "Nom d'utilisateur")
            {
                return " Entrer votre Nom !!";
            }
            else if (txtMotdePasse.Text == "" || txtMotdePasse.Text == "Mot de passe")
            {
                return "Entrer votre mot de passe !!";
            }

            return null;  //ou cas ou les 2 champs sonnt remplis 

        }


        private void txtNom_Enter_1(object sender, EventArgs e)
        {
            if (txtNom.Text == "Nom d'utilisateur")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }
        }

        private void txtNom_Leave_1(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "Nom d'utilisateur";
                txtNom.ForeColor = Color.Gray;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voulez-Vous Annulez la Connexion", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            txtNom.Text = "Nom d'utilisateur";
            txtNom.ForeColor = Color.Silver;

            txtMotdePasse.Text = "Mot de passe";
            txtMotdePasse.ForeColor = Color.Silver;
            txtMotdePasse.UseSystemPasswordChar = false;
        }

        private void txtMotdePasse_Enter_1(object sender, EventArgs e)
        {
            if (txtMotdePasse.Text == "Mot de passe")
            {
                txtMotdePasse.Text = "";

                txtMotdePasse.ForeColor = Color.White;
            }
            txtMotdePasse.UseSystemPasswordChar = true;
        }

        private void txtMotdePasse_Leave_1(object sender, EventArgs e)
        {
            if (txtMotdePasse.Text == "")
            {
                txtMotdePasse.Text = "Mot de passe";
                txtMotdePasse.UseSystemPasswordChar = false; //texte du contrôle TextBox doit apparaître comme caractère de mot de passe par défaut.

                txtMotdePasse.ForeColor = Color.Gray;
            }
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (showHidePasword == false)
            {
                txtMotdePasse.UseSystemPasswordChar = false;
                btnShowHidePassword.Image = Eleve_Book.Properties.Resources.hidePasword;
                showHidePasword = true;
            }
            else
            {
                txtMotdePasse.UseSystemPasswordChar = true;
                btnShowHidePassword.Image = Properties.Resources.showPassword;
                showHidePasword = false;
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

   
        private void imgSlideReduceSize_Click(object sender, EventArgs e)
        {
            if (pnlGauche.Width == 269)   //269, 662
            {
                pnlGauche.Size = new Size(0, 662);
                imgSlideReduceSize.Image = Properties.Resources.gonext_103393;

            }
            else
            {
                pnlGauche.Size = new Size(269, 662);
                imgSlideReduceSize.Image = Properties.Resources.goPrevious;
            }
        }

        private void btnMaxMin2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnReduce2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void imgCI_Click(object sender, EventArgs e)
        {
            cycleIngenieurSelected = true;
            imgCyclIng.Image = Properties.Resources.ci;
            imgcyclLic.Image = Properties.Resources.ciOp;

            btnAcceuil_Click(sender, e);
            EnableFormulaire();

            pnlConnexion.Visible = false; //cacher panel des sous entité connexion
            imgAcceuil_Click(sender, e);
            imgSlideReduceSize.Image = Properties.Resources.goPrevious;


        }

        private void imgCL_Click(object sender, EventArgs e)
        {
            cycleIngenieurSelected = false;
            imgCyclIng.Image = Properties.Resources.ciOp;
            imgcyclLic.Image = Properties.Resources.cl3;

            btnAcceuil_Click(sender, e);
            EnableFormulaire();

            pnlConnexion.Visible = false;
            imgAcceuil_Click(sender, e);
            imgSlideReduceSize.Image = Properties.Resources.goPrevious;

        }

       

        #region BUTTON ELEVES CYCLE LICENCE DISPLAY USERCONTROLE
        private void btnRElic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_RE_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_RE_List.Instance);
                UCL_RE_List.Instance.Dock = DockStyle.Fill;
                UCL_RE_List.Instance.BringToFront();
            }
            else
            {
                UCL_RE_List.Instance.BringToFront();
            }
        }
          

        private void btnRSlic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_RS_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_RS_List.Instance);
                UCL_RS_List.Instance.Dock = DockStyle.Fill;
                UCL_RS_List.Instance.BringToFront();
            }
            else
            {
                UCL_RS_List.Instance.BringToFront();
            }
        }

        private void btnRFlic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_RF_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_RF_List.Instance);
                UCL_RF_List.Instance.Dock = DockStyle.Fill;
                UCL_RF_List.Instance.BringToFront();
            }
            else
            {
                UCL_RF_List.Instance.BringToFront();
            }
        }

        private void btnREtLic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_Etudes_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_Etudes_List.Instance);
                UCL_Etudes_List.Instance.Dock = DockStyle.Fill;
                UCL_Etudes_List.Instance.BringToFront();
            }
            else
            {
                UCL_Etudes_List.Instance.BringToFront();
            }
        }

        private void btnRCLic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_Cartes_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_Cartes_List.Instance);
                UCL_Cartes_List.Instance.Dock = DockStyle.Fill;
                UCL_Cartes_List.Instance.BringToFront();
            }
            else
            {
                UCL_Cartes_List.Instance.BringToFront();
            }
        }

        private void btnRArLic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_Arret_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_Arret_List.Instance);
                UCL_Arret_List.Instance.Dock = DockStyle.Fill;
                UCL_Arret_List.Instance.BringToFront();
            }
            else
            {
                UCL_Arret_List.Instance.BringToFront();
            }
        }

        private void btnRPtcLic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_PTC_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_PTC_List.Instance);
                UCL_PTC_List.Instance.Dock = DockStyle.Fill;
                UCL_PTC_List.Instance.BringToFront();
            }
            else
            {
                UCL_PTC_List.Instance.BringToFront();
            }
        }

        private void btnRAcLic_Click(object sender, EventArgs e)
        {
            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UCL_Activite_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UCL_Activite_List.Instance);
                UCL_Activite_List.Instance.Dock = DockStyle.Fill;
                UCL_Activite_List.Instance.BringToFront();
            }
            else
            {
                UCL_Activite_List.Instance.BringToFront();
            }
        }

        #endregion
       
         

        private void imgCyclIng_Click(object sender, EventArgs e)
        {
            cycleIngenieurSelected = true;
            imgCyclIng.Image = Properties.Resources.ci;
            imgcyclLic.Image = Properties.Resources.clOp;
        }

        private void imgcyclLic_Click(object sender, EventArgs e)
        {
            cycleIngenieurSelected = false;            
            imgcyclLic.Image = Properties.Resources.cl3;
            imgCyclIng.Image = Properties.Resources.ciOp;
        }

        private void imgConnexion_Click(object sender, EventArgs e)
        {
            AfficherSousMenu(pnlConnexion);
            pnlBoule.Top = imgConnexion.Top;
        }

        private void imgAcceuil_Click(object sender, EventArgs e)
        {
            pnlBoule.Top = imgAcceuil.Top;
            //OuvrirChildForm(new FRM_Acceuil());

            CacherSousMenu();

            if (!pnlAfficherListe.Controls.Contains(UC_Acceuil.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_Acceuil.Instance);
                UC_Acceuil.Instance.Dock = DockStyle.Fill;
                UC_Acceuil.Instance.BringToFront();
            }
            else
            {
                UC_Acceuil.Instance.BringToFront();
            }

        }

        private void imgEleves_Click(object sender, EventArgs e)
        {
            pnlBoule.Top = imgEleves.Top;
            AfficherSousMenu(pnlEleves); //montrer les sous titres

            if (cycleIngenieurSelected == true)
                pnlElevesCI.Visible = true;
            else if (cycleIngenieurSelected == false)
                pnlElevesCL.Visible = true;
        }

        private void imgProf_Click(object sender, EventArgs e)
        {
            pnlBoule.Top = imgProf.Top;

            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_Professeur_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_Professeur_List.Instance);
                UC_Professeur_List.Instance.Dock = DockStyle.Fill;
                UC_Professeur_List.Instance.BringToFront();
            }
            else
            {
                UC_Professeur_List.Instance.BringToFront();

            }
        }

        private void imgEncadrant_Click(object sender, EventArgs e)
        {
            pnlBoule.Top = imgEncadrant.Top;

            CacherSousMenu();
            if (!pnlAfficherListe.Controls.Contains(UC_Encadrant_List.Instance))
            {
                pnlAfficherListe.Controls.Add(UC_Encadrant_List.Instance);
                UC_Encadrant_List.Instance.Dock = DockStyle.Fill;
                UC_Encadrant_List.Instance.BringToFront();
            }
            else
            {
                UC_Encadrant_List.Instance.BringToFront();
            }
        }
    }
}
