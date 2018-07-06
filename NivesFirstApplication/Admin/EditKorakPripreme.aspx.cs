using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;



namespace NivesFirstApplication.Administration
{
    public partial class EditKorakPripreme : System.Web.UI.Page
    {
        protected KorakPripreme KorakKojiEditiramo
        {
            get
            {
                return (KorakPripreme)Session["KorakPripreme"]; 
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PripremiFormu();

                int IdKorak = UcitajIdKoraka();

                KorakPripreme korak = DataManager.UcitajKorakPripreme(IdKorak);

                if (korak == null)
                {
                    korak = new KorakPripreme();
                    korak.IdRecept = UcitajIdRecepta();
                }

                SpremiUviewState(korak);


                if (Snimljeno())
                {
                    PrikaziPoruku("Korak je uspješno pohranjen !");
                }
            }
        }


        protected void SpremiUviewState(KorakPripreme korakPripreme)
        {
            Session["KorakPripreme"] = korakPripreme;
        }

        protected void PripremiFormu()
        {
            // Prepopulacija
            ddlSastojak.DataSource = DataManager.UcitajSveSastojke();
            ddlSastojak.DataValueField = "Id";
            ddlSastojak.DataTextField = "Naziv";
            ddlSastojak.DataBind();
            
            ddlZacin.DataSource = DataManager.UcitajSveZacine();
            ddlZacin.DataValueField = "Id";
            ddlZacin.DataTextField = "Naziv";
            ddlZacin.DataBind();

            var mjerneJedinice = DataManager.UcitajSveMjerneJedinice();
             //Zacin
            ddlZacinMjernaJedinica.DataSource = mjerneJedinice;
            ddlZacinMjernaJedinica.DataValueField = "Id";
            ddlZacinMjernaJedinica.DataTextField = "Naziv";
            ddlZacinMjernaJedinica.DataBind();

            //Mjerne jedinice
            ddlSastojakMjernaJedinica.DataSource = mjerneJedinice;
            ddlSastojakMjernaJedinica.DataValueField = "Id";
            ddlSastojakMjernaJedinica.DataTextField = "Naziv";
            ddlSastojakMjernaJedinica.DataBind();

        }
                      

        protected void SpremiKorakePripreme(object sender, EventArgs e)
        {
            Validate("VGDefault");
            if (!IsValid)
            {
                return;
            }

            KorakPripreme korak = KorakKojiEditiramo;

            korak.Id = UcitajIdKoraka();            
            korak.Naziv = txtNaziv.Text;            
            korak.DetaljanOpis = txtDugiO.Text;
            korak.Redoslijed = int.Parse(txtRedoslijed.Text);
            korak.Trajanje = double.Parse(txtTrajanje.Text);
            
            if (korak.Id > 0)
            {
                DataManager.IzmjeniKorakPripreme(korak);
                PrikaziPoruku("Korak pripreme je uspješno izmijenjen! ");
            }

            else
            {
                if (DataManager.SpremiKorakPripreme(korak))
                {
                    Response.Redirect(string.Format("~/Admin/EditRecept.aspx?idRecepta={0}&Snimljeno=true", korak.IdRecept));

                }

                
            }
        }

       
        protected void gridSastojciKP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int rowindex = Convert.ToInt32(e.CommandArgument);

            Guid SastojakKPId = (gridSastojciKP.DataKeys[rowindex].Value as Guid?).Value;
            
            switch (e.CommandName)
            { 
                    case "ukloni":
                    SastojakKorakaPripreme sastojakZaUkloniti = null;

                    foreach (SastojakKorakaPripreme sastojak in KorakKojiEditiramo.Sastojci)
                    {
                        if (sastojak.TempId == SastojakKPId)
                        {
                            sastojakZaUkloniti = sastojak;                        
                        }                   
                    }

                    if (sastojakZaUkloniti != null)
                    {
                        KorakKojiEditiramo.Sastojci.Remove(sastojakZaUkloniti);

                        gridSastojciKP.DataSource = KorakKojiEditiramo.Sastojci;
                        gridSastojciKP.DataBind();
                    }
                    break;
            }
        }

           protected void gridZaciniKP_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje 
            Guid ZacinKPId = (gridZaciniKP.DataKeys[rowindex].Value as Guid?).Value;;

            switch (e.CommandName)
            {
                case "ukloni":
                    ZacinKorakaPripreme zacinZaUkloniti = null;

                    foreach (ZacinKorakaPripreme zacin in KorakKojiEditiramo.Zacini)
                    {
                        if (zacin.TempId == ZacinKPId)
                        {
                            zacinZaUkloniti = zacin;
                        }                    
                    }

                    if (zacinZaUkloniti != null)
                    {
                        KorakKojiEditiramo.Zacini.Remove(zacinZaUkloniti);

                        gridZaciniKP.DataSource = KorakKojiEditiramo.Zacini;
                        gridZaciniKP.DataBind();
                    
                    }
                    break;
            }
        }
        
        
        protected void NatragNaRecept(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/Admin/EditRecept.aspx?idRecepta={0}", UcitajIdRecepta()));
        }

        private void PrikaziPoruku(string poruka)
        {
            liPoruka.InnerText = poruka;
            divPoruka.Visible = true;
        }

        private void OcistiPolja()
        {
            
            txtNaziv.Text = null;
            txtDugiO.Text = null;
            txtRedoslijed.Text = null;
            txtTrajanje.Text = null;

            gridSastojciKP.DataSource = null;
            gridSastojciKP.DataBind();

            gridZaciniKP.DataSource = null;
            gridZaciniKP.DataBind();
            
        }

        protected int UcitajIdKoraka()
        {
            int id = -1;
            // link.aspx?idNovosti=5&param2=sjdhf
            int.TryParse(Request.QueryString["idKoraka"], out id);  

            return id;
        }

        protected int UcitajIdRecepta()
        {
            int id = -1;
            // link.aspx?idNovosti=5&param2=sjdhf
            int.TryParse(Request.QueryString["idRecepta"], out id);

            return id;
        }

      
        protected int UcitajIdAdmina()
        {
            int id = 1;   //  makni ca
            Admin admin = (Admin)Session["Admin"]; // izvadi admin iz sesije
            return admin.Id;
        }

        protected void btnDodajZacinKoraka_Click(object sender, EventArgs e)
        {
            ZacinKorakaPripreme zacinKoraka = new ZacinKorakaPripreme();

            zacinKoraka.Kolicina = Convert.ToDouble(txtKolicinaMjZacin.Text);
            zacinKoraka.MjernaJedinicaId = Convert.ToInt32(ddlZacinMjernaJedinica.SelectedValue);
            zacinKoraka.ZacinId = Convert.ToInt32(ddlZacin.SelectedValue);

            KorakKojiEditiramo.Zacini.Add(zacinKoraka);

            gridZaciniKP.DataSource = KorakKojiEditiramo.Zacini;
            gridZaciniKP.DataBind();
        }
                

        protected void btnDodajSastojakKoraka_Click(object sender, EventArgs e)
        {
            SastojakKorakaPripreme sastojakKoraka = new SastojakKorakaPripreme();

            sastojakKoraka.Kolicina = Convert.ToDouble(txtKolicinaMjSastojak.Text);
            sastojakKoraka.MjernaJedinicaId = Convert.ToInt32(ddlSastojakMjernaJedinica.SelectedValue);
            sastojakKoraka.SastojakId = Convert.ToInt32(ddlSastojak.SelectedValue);

            KorakKojiEditiramo.Sastojci.Add(sastojakKoraka);

            gridSastojciKP.DataSource = KorakKojiEditiramo.Sastojci;
            gridSastojciKP.DataBind();

        }

        private bool Snimljeno()
        {
            bool snimljeno = false;
            bool.TryParse(Request.QueryString["Snimljeno"], out snimljeno);
            return snimljeno;
        }


    }
}