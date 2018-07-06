using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivesFirstApplication.AppCode
{
    [Serializable]
    public class Recept : DbObjekt
    {

        #region Constructors

        public Recept()
        {
            
        }

        #endregion

        #region Properties

        public string NazivJela
        {
            get;
            set;
        }
           
    
        public string PutanjaSlike
        {
            get;
            set;
        }

        public DateTime DatumRecepta
        {
            get;
            set;
        
        }

        public int IdAdmin
        {
            get;
            set;
        }

        public double UkupnoTrajanje
        {
            get;
            set;

        }
       

        #endregion

        #region Collection Properties

        public List<KorakPripreme> KoraciPripreme
        {
            get;
            set;

        }        


        #endregion

    }

}