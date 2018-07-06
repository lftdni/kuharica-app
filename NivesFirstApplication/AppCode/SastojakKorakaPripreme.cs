using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivesFirstApplication.AppCode
{
    [Serializable]

    public class SastojakKorakaPripreme : DbObjekt
    {

        #region Private Fields

        private Sastojak _Sastojak;
        private MjernaJedinica _MjernaJedinica;
        private Guid? _TempId;
   
        #endregion


        #region public

        public SastojakKorakaPripreme()
        { 
        
        
        }
        
        #endregion

        #region Properties

        public int KorakPripremeId
        {
            get;
            set;

        }

        public int SastojakId
        {
            get;
            set;

        }


        public double Kolicina
        {
            get;
            set;
            
        }


        public int MjernaJedinicaId
        {
            get;
            set;

        }

        public MjernaJedinica MjernaJedinica
        {
            get
            {
                if (MjernaJedinicaId > 0)
                {
                    _MjernaJedinica = DataManager.UcitajMjernuJedinicu(MjernaJedinicaId);
                }
                return _MjernaJedinica;
            }
        }

        public Sastojak Sastojak
        {
            get
            {
                if (SastojakId > 0)
                {
                    _Sastojak = DataManager.UcitajSastojak(SastojakId);
                }
                return _Sastojak;
            }
        }


        public Guid TempId
        {
            get 
            {
                if (_TempId == null)
                {
                    _TempId = Guid.NewGuid();

                }

                return _TempId.Value;   // Guid? 
            }

        }
        
        #endregion

    }
}