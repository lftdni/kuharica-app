using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication.Administration
{
    public partial class EditSastojak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int idSastojka = UcitajIdSastojka();

                Sastojak sastojak = DataManager.UcitajSastojak(idSastojka);               

                if (sastojak == null)
                {
                    return;
                }

                txtNaziv.Text = sastojak.Naziv;
             
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Validate();

            if (!IsValid)
            {
                return;
            }
                        
            Sastojak sastojak = new Sastojak();

            sastojak.Id = UcitajIdSastojka();
            sastojak.Naziv = txtNaziv.Text;
            //novost.KratkiOpis = txtKratkiO.Text;
            //novost.DugiOpis = txtDugiO.Text;
            //novost.Datum = DateTime.Parse(txtDatum.Text);
            sastojak.IdAdmin = UcitajIdAdmina();

            if (sastojak.Id > 0)
            {
                DataManager.IzmjeniSastojak(sastojak);
                PrikaziPoruku("Sastojak uspješno izmijenjen");
            }
            else 
            {
                DataManager.SpremiSastojak(sastojak);
                PrikaziPoruku("Sastojak uspješno pohranjen");
                OcistiPolja();
            }                        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/SastojciList.aspx");
        }

        private void PrikaziPoruku(string poruka)
        {
            liPoruka.InnerText = poruka;
            divPoruka.Visible = true;
        }

        private void OcistiPolja()
        {
            txtNaziv.Text = null;
            //txtKratkiO.Text = null;
            //txtDugiO.Text = null;
            //txtDatum.Text = null;
        }

        protected int UcitajIdSastojka()
        {
            int id = -1;
            // link.aspx?idNovosti=5&param2=sjdhf
            int.TryParse(Request.QueryString["idSastojka"], out id);   //parametar url kod mijenjanja postojeceg

            return id;
        }

        protected int UcitajIdAdmina()
        {
            return 1;
            Admin admin = (Admin)Session["Admin"]; // izvadi admin iz sesije
            return admin.Id;
        }

    }
}