using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NivesFirstApplication.Administration
{
    public partial class EditRecept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idRecepta = UcitajIdRecepta();

                Recept recept = null;

                if (idRecepta > 0)
                {
                    recept = DataManager.UcitajRecept(idRecepta);
                }
                
                if (recept == null)
                {
                    btnDodajKorak.Visible = false;
                    return;
                }

                PopuniFormu(recept);
                if (Snimljeno())
                {
                    PrikaziPoruku("Recept je pohranjen !");
                }
                                  
            }   
        }

        private void PopuniFormu(Recept recept)
        {
            txtNaslov.Text = recept.NazivJela;
            txtDatum.Text = recept.DatumRecepta.ToString("dd.MM.yyyy");
            imgContentImage.ImageUrl = recept.PutanjaSlike;

            gridReceptKoraci.DataSource = recept.KoraciPripreme;
            gridReceptKoraci.DataBind();


            lblUkupnoTrajanje.Text = string.Format("Ukupno trajanje pripreme recepta: {0} min", recept.UkupnoTrajanje);
        }

        protected void btnSpremi_Click(object sender, EventArgs e)
        {
            Recept recept = new Recept();

            recept.Id = UcitajIdRecepta();
            recept.NazivJela = txtNaslov.Text;
            recept.PutanjaSlike = imgContentImage.ImageUrl;
            recept.DatumRecepta = ParsirajDatumRecepta();

            recept.IdAdmin = UcitajIdAdmina();

            if (recept.Id > 0)
            {
                DataManager.IzmjeniRecept(recept);
                PrikaziPoruku("Recept uspješno izmijenjen ");
            }
            else
            {
                if ( DataManager.SpremiRecept(recept) ) 
                {
                     PrikaziPoruku("Recept uspješno pohanjen ");
                     Response.Redirect(string.Format("~/Admin/EditRecept.aspx?idRecepta={0}&Snimljeno=true", recept.Id));

                }            
               
            }            
        }

        private bool Snimljeno() 
        {
            bool snimljeno = false;
            bool.TryParse(Request.QueryString["Snimljeno"],out snimljeno);
            return snimljeno;
        }

        protected void UcitajKorakePripreme()
        {
            var koracipripreme = DataManager.UcitajSveKorakePripreme(UcitajIdRecepta());                  

            if (koracipripreme != null)
            {
                gridReceptKoraci.DataSource = koracipripreme;
                gridReceptKoraci.DataBind();
            }
        }

        protected void gridReceptKoraci_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje 
            int KorakPripremeId = Convert.ToInt32(gridReceptKoraci.DataKeys[rowindex].Value);

            switch (e.CommandName)
            {
                case "ukloni":
                    // obriši na temelju učitanog id-a
                    DataManager.DeleteKorakPripreme(KorakPripremeId);                        //nova DELETE sastojakP

                    // ponovo učitaj sve 
                    UcitajKorakePripreme();                 //Ucitaj KORAKE PRIPREME

                    PrikaziPoruku(poruka: "Neka poruka !!!");
                    break;

            }

        }

        protected void btnPonisti_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ReceptList.aspx");          
        }
        
        protected void btnRemoveImage_Click(object sender, EventArgs e)  //brisanje slike
        {
            imgContentImage.ImageUrl = "";
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)   //spremanje
        {
            if (!fuImage.HasFile)
            {
                return;
            }

            string relativeFilePath = string.Format("~/Upload/{0}", fuImage.FileName);
            string serverFilePath = Server.MapPath(relativeFilePath);

            fuImage.SaveAs(serverFilePath);

            imgContentImage.ImageUrl = relativeFilePath;
        }

        private void PrikaziPoruku(string poruka)   
        {
            liPoruka.InnerText = poruka;
            divPoruka.Visible = true;
        }

        private void OcistiPolja()  // metoda ciscenja polja kada je unesen; 
        {
            txtNaslov.Text = null;
          
            imgContentImage.ImageUrl = null;

            txtDatum.Text = null;
           
        }

        protected int UcitajIdRecepta()
        {
            int id = -1;

            int.TryParse(Request.QueryString["idRecepta"], out id);   //id Recepta url parametar liste helper za parametre po kojim se stranica ucitava
             
            return id;
        }

        protected int UcitajIdAdmina()
        {
            Admin admin = (Admin)Session["Admin"]; // izvadi admin iz sesije

            if (admin == null)
            {
                return 1;   
            }

            return admin.Id;
        }

        protected DateTime ParsirajDatumRecepta()
        {
            DateTime datumRecepta;
            
            if (DateTime.TryParse(txtDatum.Text, out datumRecepta))
            {
                return datumRecepta;
            }

            return  DateTime.Now;
        }

        protected void dodajKorak_Click(object sender, EventArgs e)
        {
            int receptId= UcitajIdRecepta();            
            
            Response.Redirect(string.Format("~/Admin/EditKorakPripreme.aspx?idRecepta={0}", receptId));

        }
    }

}