using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivesFirstApplication.AppCode
{
    [Serializable]
    public class Zacin : DbObjekt 
    {

        #region Constructors

        public Zacin()
        {
            
        }

        #endregion

        #region Properties 

        public string Naziv
        {
            get;
            set;
        }
         

        public int IdAdmin
        {
            get;
            set;
        }

        #endregion


    }


    
}