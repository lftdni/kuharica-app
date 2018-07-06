using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivesFirstApplication.AppCode
{
    [Serializable]
    public class Admin : DbObjekt
    {

        public Admin()
        {
            
        }

        public string Ime
        {
            get;
            set;
        }

        public string Prezime
        {
            get;
            set;

        }

        public string KorisnickoIme
        {
            get;
            set;
        }

        public string Lozinka
        {
            get;
            set;
        }

    }
}