using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication.Administration
{
    public partial class EditAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idAdmin = UcitajIdAdmina();

                Admin administrator = DataManager.UcitajAdmina(idAdmin);

                if (administrator == null)
                {
                    return;
                }

                txtIme.Text = administrator.Ime;
                txtPrezime.Text = administrator.Prezime;
                txtKorisnik.Text = administrator.KorisnickoIme;
                txtLozinka.Text = administrator.Lozinka;
            }
        }

        protected void btnPotvrdi_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Id = UcitajIdAdmina();
            admin.Ime = txtIme.Text;
            admin.Prezime = txtPrezime.Text;
            admin.KorisnickoIme = txtKorisnik.Text;
            admin.Lozinka = txtLozinka.Text;           
            
            if (admin.Id > 0)
            {
                DataManager.IzmjeniAdmina(admin);
                PrikaziPoruku("Admin uspješno izmijenjen ! ");
            }
            else
            {
                DataManager.SpremiAdmina(admin);
                PrikaziPoruku("Admin uspješno unesen ! ");
                OcistiPolja();
            }           
                     
        }

        protected void btnNatrag_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminList.aspx");
        }

        private void PrikaziPoruku(string poruka)
        {
            liPoruka.InnerText = poruka;
            divPoruka.Visible = true;          
        }

        private void OcistiPolja()
        {
            txtIme.Text = null;
            txtPrezime.Text = null;
            txtKorisnik.Text = null;
            txtLozinka.Text = null;
        }
        protected int UcitajIdAdmina()
        {
            int id = -1;
            int.TryParse(Request.QueryString["idAdmina"], out id);

            return id;
        }

    }
}