using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using NivesFirstApplication.AppCode;
using System.Text;


namespace NivesFirstApplication
{
    public partial class NasiVasiRecepti : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderRecepti(); 
            }
        }

        protected void RenderRecepti()
        {
            List<Recept> recept = DataManager.UcitajTopRecepte();
                       
            if (recept == null || recept.Count < 1)
            {
                return;
            }


            StringBuilder rezultat = new StringBuilder();

            rezultat.AppendLine(@"<div class=""list"">");
            rezultat.AppendLine(@"<h3>Prikazujem top recepte</h3>");

            for (int i = 0; i < recept.Count; i++)
            {
                Recept trenutniRecept = recept[i];

                rezultat.AppendLine(@"<div class=""item list2"">");
                rezultat.AppendLine(string.Format(@"<h4><a href=""ReceptDetalji.aspx?id={0}""> {1}</a></h4>", trenutniRecept.Id, trenutniRecept.NazivJela));

                rezultat.AppendLine(@"</div>");
            }

            rezultat.AppendLine("</div>"); 
          

            litRecept.Text = rezultat.ToString();
        }
        
        
    }
}

