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
    public partial class ZaciniList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UcitajZacine();                  
            }
        }

        protected void UcitajZacine()
        {
            DataTable zacin = DataManager.GetAllFlavors();

            if (zacin != null)
            {
                gridBaneri.DataSource = zacin;
                gridBaneri.DataBind();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditZacin.aspx");
        }

        protected void gridBaneri_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // dohvati index kliknutog reda - na koji red je korisnik kliknuo
            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje 
            int zacinId = Convert.ToInt32(gridBaneri.DataKeys[rowindex].Value);

            switch (e.CommandName)
            {
                case "ukloni":
                    // obriši zacin iz baze na temelju učitanog id-a
                    DataManager.DeleteZacin(zacinId);

                    // ponovo učitaj sve zacine - osvježi prikaz
                    UcitajZacine();

                    PrikaziPoruku();
                    break;

                case "izmjeni":
                    Response.Redirect(string.Format("~/Admin/EditZacin.aspx?idZacina={0}", zacinId));
                    break;

            }
                  
        }

        private void PrikaziPoruku()
        {
            divPoruka.Visible = true;
        }
    }
}