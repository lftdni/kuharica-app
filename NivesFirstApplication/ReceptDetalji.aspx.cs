using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NivesFirstApplication
{
    public partial class ReceptDetalji : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int? idRecepta = UcitajIdRecepta();

                if (!idRecepta.HasValue)
                {
                    return;
                }

                Recept recept = DataManager.UcitajRecept(idRecepta.Value);

                if(recept == null)
                {
                    return;     
                }

                RenderirajRecept(recept);
            }
        }

        private void RenderirajRecept(Recept recept)
        {
            litReceptNaziv.Text = recept.NazivJela;            

            litKoraciPripreme.Text = RenderKorakePripreme(recept.KoraciPripreme);
        }

        private string RenderKorakePripreme(List<KorakPripreme> koraciPripreme)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"<div class=""dataTables_wrapper"">");

            foreach (KorakPripreme korakPripreme in koraciPripreme)
            {
                sb.AppendLine("<br />");

                sb.AppendLine(string.Format("<h3><u>Korak pripreme: {0} </u></h3>", korakPripreme.Naziv));

                sb.AppendLine(string.Format("<strong>  Detaljan opis: </strong>  {0} ", korakPripreme.DetaljanOpis));                             
                
                sb.AppendLine("<br />");

                sb.AppendLine(RenderirajSastojke(korakPripreme.Sastojci));

                sb.AppendLine("<br />");

                sb.AppendLine(RenderirajZacine(korakPripreme.Zacini));
            }

            sb.AppendLine("</div>");

            return sb.ToString();
        }

        private string RenderirajZacine(List<ZacinKorakaPripreme> zacini)
        {
            if (zacini == null || zacini.Count <= 0)
            {
                return null;
            }

            StringBuilder rezultat = new StringBuilder();

            rezultat.AppendLine("<h4>Zacini</h4>");

            rezultat.AppendLine(@"<table class=""display data-table-theme"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" >");

            rezultat.AppendLine(@"<tr> <th>Zacin</th> <th>Mj</th> <th>Kolicina</th> </tr>");

            foreach (ZacinKorakaPripreme zacin in zacini)
            {
                rezultat.AppendLine(string.Format( @"<tr> <th>{0}</th> <th>{1}</th> <th>{2}</th> </tr>", zacin.Zacin.Naziv, zacin.MjernaJedinica.Naziv, zacin.Kolicina));
            }

            rezultat.AppendLine(@"</table>");

            return rezultat.ToString();
        }

        private string RenderirajSastojke(List<SastojakKorakaPripreme> sastojci)
        {
            if (sastojci == null || sastojci.Count <= 0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h4>Sastojci</h4>");

            sb.AppendLine(@"<table class=""display data-table-theme"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" >");

            sb.AppendLine(@"<tr> <th>Sastojak</th> <th>Mj</th> <th>Kolicina</th> </tr>");

            foreach (SastojakKorakaPripreme sastojak in sastojci)
            {
                sb.AppendLine(string.Format(@"<tr> <th>{0}</th> <th>{1}</th> <th>{2}</th> </tr>", sastojak.Sastojak.Naziv, sastojak.MjernaJedinica.Naziv, sastojak.Kolicina));
            }

            sb.AppendLine("</table>");

            return sb.ToString();
        }

        private int? UcitajIdRecepta()
        {
            int rezultat;
            if (int.TryParse(Request.QueryString["id"], out rezultat))
            {
                return rezultat;
            }

            return null;

        }
    }
}