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
    public partial class FRM_CartesAjouterModifier : Form
    {
        private UserControl usEleve;  //pr le remplacer par USER_List_Client
        CL.CLS_R_CartesTable classCarte = new CL.CLS_R_CartesTable();
        UC_Cartes_List userRC = new UC_Cartes_List();
        private Db_EleveBookEntities4 db;

        //Déclaration des variables images
        private byte[] byteImageCIN1;
        private byte[] byteImageCIN2;
        private byte[] byteImageCMIL1;
        private byte[] byteImageCMIL2;
        private byte[] byteImageCMUT1;
        private byte[] byteImageCMUT2;
        private byte[] byteImagePasseport;

        public FRM_CartesAjouterModifier(UserControl userC)
        {
            InitializeComponent();
            this.usEleve = userC;
        }

        private void FRM_CartesAjouterModifier_Load(object sender, EventArgs e)
        {
            
            if (lblTitreCartes.Text == "AJOUTER DES CARTES")
            {               
                db = new Db_EleveBookEntities4();
                this.cmbNom.DataSource = null;  //pour eviter l exception (Items collection cannot be modified when the DataSource property is set.')
                this.cmbNom.DataSource = null;
                cmbNom.DataSource = db.R_ElementairesTable.ToList();  //display all data
                cmbNom.DisplayMember = "Nom_Eleve"; //display only name
                cmbNom.ValueMember = "Id"; //display who has this id

                cmbPrenom.DataSource = db.R_ElementairesTable.ToList();  //display all data
                cmbPrenom.DisplayMember = "Prenom_Eleve"; //display only name
                cmbPrenom.ValueMember = "Nom_Eleve"; //display who has this id

                cmbNom.Text = "-- choisir Elève --";
                cmbPrenom.Text = "-- choisir Prénom --";
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

      
      

        private void btnCIN1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgCIN1.Image = Image.FromFile(Op.FileName);
            }
        }

        private void btnCIN2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgCIN2.Image = Image.FromFile(Op.FileName);
            }
        }

        private void brnCMIL1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgCMIL1.Image = Image.FromFile(Op.FileName);
            }
        }

        private void brnCMIL2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgCMIL2.Image = Image.FromFile(Op.FileName);
            }
        }

        private void btnCMUT1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgCMUT1.Image = Image.FromFile(Op.FileName);
            }
        }

        private void btnCMUT2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgCMUT2.Image = Image.FromFile(Op.FileName);
            }
        }

        private void btnPasseport_Click(object sender, EventArgs e)
        {
            OpenFileDialog Op = new OpenFileDialog();
            Op.Filter = " | * .JPG ; *.PNG; *.GIF ; *.BMP ";
            if (Op.ShowDialog() == DialogResult.OK)
            {
                imgPasseport.Image = Image.FromFile(Op.FileName);
            }
        }

       
        private void btnDeleteCIN1_Click(object sender, EventArgs e)
        {
            imgCIN1.Image = null;
        }
        private void btnDeleteCIN2_Click(object sender, EventArgs e)
        {
            imgCIN2.Image = null;
        }
        private void btnDeleteCMIL1_Click(object sender, EventArgs e)
        {
            imgCMIL1.Image = null;
        }
        private void btnDeleteCMIL2_Click(object sender, EventArgs e)
        {
            imgCMIL2.Image = null;
        }
        private void btnDeleteCMUT1_Click(object sender, EventArgs e)
        {
            imgCMUT1.Image = null;
        }
        private void btnDeleteCMUT2_Click(object sender, EventArgs e)
        {
            imgCMUT2.Image = null;
        }
        private void btnDeletePasseport_Click(object sender, EventArgs e)
        {
            imgPasseport.Image = null;
        }

     

        public void btnActualiser_Click(object sender, EventArgs e)
        {
            if (lblTitreCartes.Text == "AJOUTER DES CARTES")
            {
                cmbNom.Text = "-- Choisir Nom --";
                cmbNom.ForeColor = Color.DimGray;
                cmbPrenom.Text = "-- Choisir Prénom --";
                cmbPrenom.ForeColor = Color.DimGray;
            }

            imgCIN1.Image = null;
            imgCIN2.Image = null;
            imgCMIL1.Image = null;
            imgCMIL2.Image = null;
            imgCMUT1.Image = null;
            imgCMUT2.Image = null;
            imgPasseport.Image = null;
        }

        private void btnEnregistry_Click(object sender, EventArgs e)
        {
            if (testObligatoire() != null)  //un champ vide ou données incompatible
            {
                MessageBox.Show(testObligatoire(), "Champs Obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            else if (lblTitreCartes.Text == "AJOUTER DES CARTES") // winform ajouter
            {
                #region convertir image en format byte
                if (imgCIN1.Image != null)
                {
                    MemoryStream mr = new MemoryStream();
                    imgCIN1.Image.Save(mr, imgCIN1.Image.RawFormat);
                    byteImageCIN1 = mr.ToArray();  //convertir en byte
                }
                if (imgCIN2.Image != null)
                {
                    MemoryStream mr2 = new MemoryStream();
                    imgCIN2.Image.Save(mr2, imgCIN2.Image.RawFormat);
                    byteImageCIN2 = mr2.ToArray();
                }
                if (imgCMIL1.Image != null)
                {
                    MemoryStream mr3 = new MemoryStream();
                    imgCMIL1.Image.Save(mr3, imgCMIL1.Image.RawFormat);
                    byteImageCMIL1 = mr3.ToArray();
                }
                if (imgCMIL2.Image != null)
                {
                    MemoryStream mr4 = new MemoryStream();
                    imgCMIL2.Image.Save(mr4, imgCMIL2.Image.RawFormat);
                    byteImageCMIL2 = mr4.ToArray();
                }
                if (imgCMUT1.Image != null)
                {
                    MemoryStream mr5 = new MemoryStream();
                    imgCMUT1.Image.Save(mr5, imgCMUT1.Image.RawFormat);
                    byteImageCMUT1 = mr5.ToArray();
                }
                if (imgCMUT2.Image != null)
                {
                    MemoryStream mr6 = new MemoryStream();
                    imgCMUT2.Image.Save(mr6, imgCMUT2.Image.RawFormat);
                    byteImageCMUT2 = mr6.ToArray();
                }
                if (imgPasseport.Image != null)
                {
                    MemoryStream mr7 = new MemoryStream();
                    imgPasseport.Image.Save(mr7, imgPasseport.Image.RawFormat);
                    byteImagePasseport = mr7.ToArray();
                }
                #endregion

                if (classCarte.Ajouter_RC(cmbNom.Text, cmbPrenom.Text, byteImageCIN1, byteImageCIN2, byteImageCMIL1, byteImageCMIL2, byteImageCMUT1, byteImageCMUT2, byteImagePasseport, txtAutres.Text) == true)
                {
                    DialogResult d = MessageBox.Show("Cartes ajoutées avec succés !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                        btnActualiser_Click(sender, e);  //vider tous les champs
                    (usEleve as FM.UC_Cartes_List).ActualiserDataGridViewCartes();

                }
                else
                {
                    MessageBox.Show("Ces données existent déja; \n Veuillez Ajouter un neauveau Elève !!", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // ATTENTION : c'est ce qui devrait faire le bouton modifier 
            else  //si lblTitre  == modifier eleve
            {

                DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier ces Cartes", "MODIFICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {

                    //convertir image en format byte
                    #region convertir image en format byte
                    if (imgCIN1.Image != null)
                    {
                        MemoryStream mr = new MemoryStream();
                        imgCIN1.Image.Save(mr, imgCIN1.Image.RawFormat);
                        byteImageCIN1 = mr.ToArray();  //convertir en byte
                    }
                    if (imgCIN2.Image != null)
                    {
                        MemoryStream mr2 = new MemoryStream();
                        imgCIN2.Image.Save(mr2, imgCIN2.Image.RawFormat);
                        byteImageCIN2 = mr2.ToArray();
                    }
                    if (imgCMIL1.Image != null)
                    {
                        MemoryStream mr3 = new MemoryStream();
                        imgCMIL1.Image.Save(mr3, imgCMIL1.Image.RawFormat);
                        byteImageCMIL1 = mr3.ToArray();
                    }
                    if (imgCMIL2.Image != null)
                    {
                        MemoryStream mr4 = new MemoryStream();
                        imgCMIL2.Image.Save(mr4, imgCMIL2.Image.RawFormat);
                        byteImageCMIL2 = mr4.ToArray();
                    }
                    if (imgCMUT1.Image != null)
                    {
                        MemoryStream mr5 = new MemoryStream();
                        imgCMUT1.Image.Save(mr5, imgCMUT1.Image.RawFormat);
                        byteImageCMUT1 = mr5.ToArray();
                    }
                    if (imgCMUT2.Image != null)
                    {
                        MemoryStream mr6 = new MemoryStream();
                        imgCMUT2.Image.Save(mr6, imgCMUT2.Image.RawFormat);
                        byteImageCMUT2 = mr6.ToArray();
                    }
                    if (imgPasseport.Image != null)
                    {
                        MemoryStream mr7 = new MemoryStream();
                        imgPasseport.Image.Save(mr7, imgPasseport.Image.RawFormat);
                        byteImagePasseport = mr7.ToArray();
                    }
                    #endregion




                    classCarte.Modifier_RC(UC_Cartes_List.IDselectCarte, cmbNom.Text, cmbPrenom.Text, byteImageCIN1, byteImageCIN2, byteImageCMIL1, byteImageCMIL2, byteImageCMUT1, byteImageCMUT2, byteImagePasseport, txtAutres.Text);
                    MessageBox.Show("Données modifiés avec succès", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    (usEleve as UC_Cartes_List).ActualiserDataGridViewCartes();  //actualiser dataGridView
                    this.Close();
                  
                }
                else
                {
                    MessageBox.Show("Modification annulée", "MODIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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

        private void txtAutres_Enter(object sender, EventArgs e)
        {
            if (txtAutres.Text == "Autres.....")
            {
                txtAutres.Text = "";
                txtAutres.ForeColor = Color.Black;
            }
        }

        private void cmbPrenom_Leave(object sender, EventArgs e)
        {
            if (txtAutres.Text == "")
            {
                txtAutres.Text = "Autres.....";
                txtAutres.ForeColor = Color.Silver;
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
    }
}

