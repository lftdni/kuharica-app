using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication.Administration
{
    public partial class MjerneJediniceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                UcitajMjernuJedinicu();
            }
        }
        protected void UcitajMjernuJedinicu()
        {

            DataTable mjernejedinice = DataManager.GetAllMeasurements();

            if (mjernejedinice != null)
            {
                gridNovosti.DataSource = mjernejedinice;
                gridNovosti.DataBind();
            }

        }
     
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditMjernaJedinica.aspx");
        }

        protected void gridNovosti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // dohvati index kliknutog reda - na koji red je korisnik kliknuo
            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje (admin)
            int mjernajedinicaId= Convert.ToInt32(gridNovosti.DataKeys[rowindex].Value);

            switch (e.CommandName)
            { 
                case "ukloni":
                    // obriši admina iz baze na temelju učitanog id-a
                    DataManager.DeleteMjernaJedinica(mjernajedinicaId);

                    // ponovo učitaj 
                    UcitajMjernuJedinicu();

                    PrikaziPoruku();
                    break;

                case "izmjeni":
                    Response.Redirect(string.Format("~/Admin/EditMjernaJedinica.aspx?idMjerneJedinice={0}", mjernajedinicaId));
                    break;

            }           
        }

        private void PrikaziPoruku()
        {
            divPoruka.Visible = true;
        }
    }
}