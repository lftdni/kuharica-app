﻿using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication
{
    public partial class NajbrzaJela : System.Web.UI.Page
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
            List<Recept> recepti = DataManager.UcitajSveReceptePremaBrziniPripreme();

            StringBuilder rezultat = new StringBuilder();

            rezultat.AppendLine(@"<div class=""list"">");
            rezultat.AppendLine(string.Format(@"<h3>Prikazujem {0} brzih jela</h3>", recepti != null ? recepti.Count : 0));

           
            if (recepti.Count < 1)
            {
                // prikazi poruku
                rezultat.AppendLine(@"<div class=""notification-attention"">
						<ul>
							<li>Trenutno nema jela u sustavu</li>
						</ul>
					</div>");
            }
            else
            {
                foreach (Recept recept in recepti)
                {
                    rezultat.AppendLine(@"<div class=""item list2"">");
                    rezultat.AppendLine(string.Format(@"<h4><a href=""ReceptDetalji.aspx?id={0}""> {1} (trajanje {2} min)</a></h4>", recept.Id, recept.NazivJela, recept.UkupnoTrajanje));

                    rezultat.AppendLine(@"</div>");
                }
            }

            rezultat.AppendLine("</div>");

            litRecepti.Text = rezultat.ToString();


        }
    }
}