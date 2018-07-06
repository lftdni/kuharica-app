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
    public partial class SastojciList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                UcitajSastojke();
            }
        }
        protected void UcitajSastojke()
        {

            DataTable sastojci = DataManager.GetAllIngredients();
                 
            if (sastojci != null)
            {
                gridNovosti.DataSource = sastojci;
                gridNovosti.DataBind();
            }

        }
     
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditSastojak.aspx");
        }

        protected void gridNovosti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // dohvati index kliknutog reda - na koji red je korisnik kliknuo
            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje (admin)
            int sastojaktId = Convert.ToInt32(gridNovosti.DataKeys[rowindex].Value);

            switch (e.CommandName)
            { 
                case "ukloni":
                    // obriši admina iz baze na temelju učitanog id-a
                    DataManager.DeleteSastojak(sastojaktId);

                    // ponovo učitaj 
                    UcitajSastojke();

                    PrikaziPoruku();
                    break;

                case "izmjeni":
                    Response.Redirect(string.Format("~/Admin/EditSastojak.aspx?idSastojka={0}", sastojaktId));
                    break;

            }           
        }

        private void PrikaziPoruku()
        {
            divPoruka.Visible = true;
        }
    }
}