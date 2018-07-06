using NivesFirstApplication.AppCode;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace NivesFirstApplication
{
    public partial class Registracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       

        }
            
        
        protected void ShowSuccessMessage(string message)
        {
            litMessages.Text = string.Format(@"<div class=""notification-success"">
						<ul>
							<li><strong>{0}</strong></li>
						</ul>
					</div>", message);
        }

        protected void ShowAttentionMessage(string message)
        {
            litMessages.Text = string.Format(@"<div class=""notification-attention"">
						<ul>
							<li><strong>{0}</strong></li>
						</ul>
					</div>", message);
        }

                    

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
       
            admin.Ime = txtIme.Text;
            admin.Prezime = txtPrezime.Text;
            admin.KorisnickoIme = txtKorisnickoIme.Text;
            admin.Lozinka = txtLozinka.Text;

            if (DataManager.SpremiAdmina(admin))
            {
                ShowSuccessMessage("Uspješno ste registrirani kao korisnik aplikacije ! ");
            }
            else
            {
                ShowAttentionMessage("Snimanje nije izvršeno! ");
            }
            

                     
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("/registracija.aspx");
        }

        
    }
}