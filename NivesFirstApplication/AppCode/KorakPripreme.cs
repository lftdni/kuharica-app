using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivesFirstApplication.AppCode
{
    [Serializable]
    public class KorakPripreme : DbObjekt
    {
        #region Private Fields

        private List<ZacinKorakaPripreme> _Zacini;    //private field
        private List<SastojakKorakaPripreme> _Sastojci;

        #endregion
     

        #region Properties

      
        public int IdRecept
        {
            get;
            set;
        }

        public string Naziv
        {
            get;
            set;
        }

        public string DetaljanOpis
        {
            get;
            set;

        }

        public double Trajanje
        {
            get;
            set;

        }

        public int Redoslijed
        {
            get;
            set;
        }    
        
        #endregion


        #region List Properties

        public List<ZacinKorakaPripreme> Zacini
        {
            get
            {
                if (_Zacini == null)
                {
                    _Zacini = DataManager.UcitajZacineKorakaPripreme(Id);
                }

                return _Zacini;
            }

        }


        public List<SastojakKorakaPripreme> Sastojci
        {
            get { 
                if  (_Sastojci == null) 
                
                {
                    _Sastojci = DataManager.UcitajSastojkeKorakaPripreme(Id);

                }
                return _Sastojci; 
            
            }
            
        }

        #endregion
    }
    
}