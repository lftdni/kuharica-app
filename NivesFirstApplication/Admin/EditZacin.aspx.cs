using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication.Administration
{
    public partial class EditZacin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idZacina = UcitajIdZacina();

                Zacin zacin = DataManager.UcitajZacin(idZacina);

                if (zacin == null)
                {
                    return;
                }

                txtNaziv.Text = zacin.Naziv;
             
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Validate();

            if (!IsValid)
            {
                return;
            }
                        
            Zacin zacin = new Zacin();

            zacin.Id = UcitajIdZacina();
            zacin.Naziv = txtNaziv.Text;
            
            //zacin.IdAdmin = UcitajIdAdmina();

            if (zacin.Id > 0)
            {
                DataManager.IzmjeniZacin(zacin);
                PrikaziPoruku("Začin uspješno izmijenjen");
            }
            else 
            {
                DataManager.SpremiZacin(zacin);
                PrikaziPoruku("Začin uspješno pohranjen");
                OcistiPolja();
            }                        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ZaciniList.aspx");
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

        protected int UcitajIdZacina()
        {
            int id = -1;
            // link.aspx?idNovosti=5&param2=sjdhf
            int.TryParse(Request.QueryString["idZacina"], out id);

            return id;
        }

        protected int? UcitajIdAdmina()
        {
            Admin admin = (Admin)Session["Admin"]; // izvadi admin iz sesije

            if (admin == null)
            {
                return -1;
            }

            return admin.Id;
        }

    }
}