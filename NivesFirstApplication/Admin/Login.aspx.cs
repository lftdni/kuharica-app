using NivesFirstApplication.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace NivesFirstApplication.Administration
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool AutenticirajAdmina()
        {
            // prvo trazim admina po korisnickom imenu
            Admin admin = DataManager.UcitajAdmina(txtKorisnickoIme.Text);

            // provjeravam da li postoji
            if (admin == null)
            {
                return false;
            }

            // ako postoji usporedi lozinke
            if (admin.Lozinka.Trim() != txtLozinka.Text)  // usporedba lozinke
            {
                // ako se lozinke ne podudaraju prikazi poruke
                PrikaziPoruku();
                return false;
            }

            // ako admin postoji spremamo cijeli objekt u session kako bi bio dostupan i zabiljezen prilikom uređivanja sadrzaja - id admina
            Session["Admin"] = admin;

            return true;
        }

        private void PrikaziPoruku()
        {
            divPoruka.Visible = true;
        }

        protected void eventPrijava(object sender, EventArgs e)
        {
            if (AutenticirajAdmina())
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtKorisnickoIme.Text, DateTime.Now,
                        DateTime.Now.AddMinutes(30), cbRememberMe.Checked, "Zapamti me");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (cbRememberMe.Checked)
                    ck.Expires = tkt.Expiration;

                ck.Path = FormsAuthentication.FormsCookiePath;

                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "~/Admin/index.aspx";

                Response.Redirect(strRedirect, true);
            }
        }

        protected void eventOdustani(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Login.aspx");
        }

    }
}