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
    public partial class RezultatiPretrage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RenderRecepti();
            }
            
        }

        protected List<Recept> RezultatPretrage()
        {
            string keyword = Request.QueryString["search"];   //pretraga po kljucnoj rijeci

            List<Recept> rezultat = new List<Recept>();

            if (!string.IsNullOrEmpty(keyword))
            {
                rezultat = DataManager.PretraziRecepte(keyword);
            }

            return rezultat;

        }


        protected void RenderRecepti()
        {

            StringBuilder rezultat = new StringBuilder();

            rezultat.AppendLine(@"<div class=""list"">");
            rezultat.AppendLine(string.Format(@"<h3>Rezultati pretrage za pojam ""{0}""</h3>", Request.QueryString["search"]));

            List<Recept> recepti = RezultatPretrage();

            if (recepti.Count < 1)
            {
                // prikazi poruku
                rezultat.AppendLine(@"<div class=""notification-attention"">
						<ul>
							<li>Za traženi pojam nije pronađen niti jedan rezultat </li>
						</ul>
					</div>");
            }

            else
            {
                foreach (Recept recept in recepti)
                {
                    rezultat.AppendLine(@"<div class=""item list2"">");
                    rezultat.AppendLine(string.Format(@"<h4><a href=""ReceptDetalji.aspx?id={1}""> {0}</a></h4>", recept.NazivJela, recept.Id));

                    rezultat.AppendLine(@"</div>");
                }
            }

            rezultat.AppendLine("</div>");

            litRecepti.Text = rezultat.ToString();


        }

      



    }
}