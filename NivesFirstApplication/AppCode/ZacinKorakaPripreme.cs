using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NivesFirstApplication.AppCode
{
    [Serializable]
    public class ZacinKorakaPripreme : DbObjekt
    {
        #region Private Fields

        private Zacin _Zacin;
        private MjernaJedinica _MjernaJedinica;
        private Guid? _TempId;

        #endregion

        #region Public

        public ZacinKorakaPripreme()
        { 
        
        }

        #endregion

        #region Propreties

        public int KorakPripremeId
        {
            get;
            set;

        }

        public int ZacinId
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

        public Zacin Zacin
        {
            get 
            {
                if (ZacinId > 0)
                {
                    _Zacin = DataManager.UcitajZacin(ZacinId);
                }
                return _Zacin; 
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
                return _TempId.Value;   // Guid? nullable
            }
        }

        #endregion


    }
}