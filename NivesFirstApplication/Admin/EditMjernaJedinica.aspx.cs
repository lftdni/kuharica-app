using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication.Administration
{
    public partial class EditMjernaJedinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int IdMjernaJedinica = UcitajIdMjerneJedinice();

                MjernaJedinica mjjed = DataManager.UcitajMjernuJedinicu(IdMjernaJedinica);

                if (mjjed == null)
                {
                    return;
                }

                txtNaziv.Text = mjjed.Naziv;
             
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Validate();

            if (!IsValid)
            {
                return;
            }
                        
            MjernaJedinica mjjed = new MjernaJedinica();

            mjjed.Id = UcitajIdMjerneJedinice();
            mjjed.Naziv = txtNaziv.Text;
           
            mjjed.IdAdmin = UcitajIdAdmina();

            if (mjjed.Id > 0)
            {
                DataManager.IzmjeniMjernuJeidnicu(mjjed);
                PrikaziPoruku("Mjerna jedinica uspješno izmijenjena!");
            }
            else 
            {
                DataManager.SpremiMjernuJedinicu(mjjed);
                PrikaziPoruku("Mjerna jedinica uspješno pohranjena!");
                OcistiPolja();
            }                        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MjerneJediniceList.aspx");
        }

        private void PrikaziPoruku(string poruka)
        {
            liPoruka.InnerText = poruka;
            divPoruka.Visible = true;
        }

        private void OcistiPolja()
        {
            txtNaziv.Text = null;
           
        }

        protected int UcitajIdMjerneJedinice()
        {
            int id = -1;
            // link.aspx?idNovosti=5&param2=sjdhf
            int.TryParse(Request.QueryString["idMjerneJedinice"], out id);

            return id;
        }



        protected int UcitajIdAdmina()
        {

            return 1;   //obriši nakon postavljanja logina

            Admin admin = (Admin)Session["Admin"]; // izvadi admin iz sesije
            return admin.Id;
        }

    }
}