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
    public partial class ReceptList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UcitajRecepte();                  
            }
        }

        protected void UcitajRecepte()
        {
            DataTable recept = DataManager.GetAllRecepies();

            if (recept != null)
            {
                gridRecepti.DataSource = recept;
                gridRecepti.DataBind();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditRecept.aspx");
        }

        protected void gridRecepti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // dohvati index kliknutog reda - na koji red je korisnik kliknuo
            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje 
            int receptId = Convert.ToInt32(gridRecepti.DataKeys[rowindex].Value);

            switch (e.CommandName)
            {
                case "ukloni":
                    // obriši admina iz baze na temelju učitanog id-a
                    DataManager.DeleteRecept(receptId);

                    // ponovo učitaj sve admine - osvježi prikaz
                    UcitajRecepte();

                    PrikaziPoruku();
                    break;

                case "izmjeni":
                    Response.Redirect(string.Format("~/Admin/EditRecept.aspx?idRecepta={0}", receptId));
                    break;

            }
                  
        }

        private void PrikaziPoruku()
        {
            divPoruka.Visible = true;
        }
    }
}