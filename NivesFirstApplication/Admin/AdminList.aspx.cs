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
    public partial class AdminList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UcitajAdmine();                
            }
        }

        protected void UcitajAdmine()
        {
            DataTable admini = DataManager.GetAllAdmins();

            if (admini != null)
            { 
                gridAdmini.DataSource = admini;
                gridAdmini.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditAdmin.aspx");
        }

        protected void gridAdmini_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // dohvati index kliknutog reda - na koji red je korisnik kliknuo
            int rowindex = Convert.ToInt32(e.CommandArgument);

            // pomoću indexa se čita id objekta koji se prikazuje (admin)
            int adminId = Convert.ToInt32(gridAdmini.DataKeys[rowindex].Value);

            switch (e.CommandName)
            {
                case "ukloni": 
                    bool obrisano = DataManager.DeleteAdmin(adminId);
                    if (obrisano)
                    {
                        // ponovo učitaj sve admine - osvježi prikaz
                        UcitajAdmine();

                        PrikaziPoruku("Admin uspjesno obrisan !", "success");
                    }
                    else
                    {
                        PrikaziPoruku(" Admina nije moguće obrisati jer postoji sadržaj koji je kreirao !", "error");
                    }                                   

                    break;

                case "izmjeni":
                    Response.Redirect(string.Format("~/Admin/EditAdmin.aspx?idAdmina={0}", adminId));
                    break;

            }
        }

        private void PrikaziPoruku(string poruka, string css)
        {
            divPoruka.Visible = true;
            liPoruka.InnerText = poruka;
            divPoruka.Attributes["class"] = string.Format(@"notification-{0}", css) ;
        }
               
    }
}