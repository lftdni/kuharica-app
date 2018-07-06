using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace NivesFirstApplication.AppCode
{
    public static class DataManager
    {
        #region Public Metode - Insert, Update


        public static bool SpremiKorakPripreme(KorakPripreme korak)
        {
            string commandText = @" insert into [KorakPripreme] 
                                    (	IdRecept,
	                                    Naziv,
                                        DetaljanOpis,
                                        Trajanje,
                                        Redoslijed                                         
                                    )
                                    values
                                    (   @IdRecept,
	                                    @Naziv,
                                        @DetaljanOpis,
                                        @Trajanje,
                                        @Redoslijed                                       
                                          
                                    );
                                    
                                    Select @@Identity  

                                    ";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@IdRecept", korak.IdRecept);
                komanda.Parameters.AddWithValue("@Naziv", korak.Naziv);
                komanda.Parameters.AddWithValue("@DetaljanOpis", korak.DetaljanOpis);
                komanda.Parameters.AddWithValue("@Trajanje", korak.Trajanje);
                komanda.Parameters.AddWithValue("@Redoslijed", korak.Redoslijed);
                               
                komanda.Connection.Open();

                korak.Id = Convert.ToInt32(komanda.ExecuteScalar());
                SpremiZacineKorakaPripreme(konekcija, korak);
                SpremiSastojkeKorakaPripreme(konekcija, korak);
                

                komanda.Connection.Close();
            }

      

            return true;
        }

        private static void SpremiZacineKorakaPripreme(SqlConnection konekcija, KorakPripreme korakPripreme)
        {
            if (korakPripreme.Zacini.Count <= 0)
            {
                return;
            }

            string commandText = @"INSERT INTO [ZacinKorakaPripreme]
                                        ([KorakPripremeId]
                                        ,[ZacinId]
                                        ,[Kolicina]
                                        ,[MjernaJedinicaId])
                                    VALUES
                                        (
                                         @KorakPripremeId
                                        ,@ZacinId
                                        ,@Kolicina
                                        ,@MjernaJedinicaId
                                        );
                                        Select @@Identity  
                                    ";

            foreach (ZacinKorakaPripreme zacinKoraka in korakPripreme.Zacini)
            {
                using (SqlCommand komanda = new SqlCommand())
                {
                    komanda.CommandText = commandText;
                    komanda.Connection = konekcija;

                    komanda.Parameters.AddWithValue("@KorakPripremeId", korakPripreme.Id);
                    komanda.Parameters.AddWithValue("@ZacinId", zacinKoraka.ZacinId);
                    komanda.Parameters.AddWithValue("@Kolicina", zacinKoraka.Kolicina);
                    komanda.Parameters.AddWithValue("@MjernaJedinicaId", zacinKoraka.MjernaJedinicaId);

                    zacinKoraka.Id =Convert.ToInt32(komanda.ExecuteScalar());
                }
            }
        }

        private static void SpremiSastojkeKorakaPripreme(SqlConnection konekcija, KorakPripreme korakPripreme)
        {
            if (korakPripreme.Sastojci.Count <= 0)
            {
                return;
            }

            string commandText = @"INSERT INTO [SastojakKorakaPripreme]
                                        ([KorakPripremeId]
                                        ,[SastojakId]
                                        ,[Kolicina]
                                        ,[MjernaJedinicaId])
                                    VALUES
                                        (
                                         @KorakPripremeId
                                        ,@SastojakId
                                        ,@Kolicina
                                        ,@MjernaJedinicaId
                                        );
                                        Select @@Identity  
                                        ";

            foreach (SastojakKorakaPripreme sastojakKoraka in korakPripreme.Sastojci)
            {
                using (SqlCommand komanda = new SqlCommand())
                {
                    komanda.CommandText = commandText;
                    komanda.Connection = konekcija;

                    komanda.Parameters.AddWithValue("@KorakPripremeId", korakPripreme.Id);
                    komanda.Parameters.AddWithValue("@SastojakId", sastojakKoraka.SastojakId);
                    komanda.Parameters.AddWithValue("@Kolicina", sastojakKoraka.Kolicina);
                    komanda.Parameters.AddWithValue("@MjernaJedinicaId", sastojakKoraka.MjernaJedinicaId);

                    sastojakKoraka.Id = Convert.ToInt32(komanda.ExecuteScalar());
                }
            }
        }

        public static bool SpremiSastojak(Sastojak sastojak)
        {
            string commandText = @"insert into [Sastojak] 
                                    (	
	                                    Naziv
                                    )
                                    values
                                    (
	                                    @Naziv
                                    )";

            using(SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Naziv", sastojak.Naziv);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                komanda.Connection.Close();
            }
           
            return true;
        }

        
        public static bool SpremiZacin(Zacin zacin)
        {
            string commandText = @"insert into [Zacin] 
                                    (	
	                                    Naziv
                                    )
                                    values
                                    (
	                                    @Naziv
                                    )";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Naziv", zacin.Naziv);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                komanda.Connection.Close();
            }

            return true;
        }


        public static bool SpremiMjernuJedinicu(MjernaJedinica mjernajedinica)
        {
            string commandText = @"insert into [MjernaJedinica] 
                                    (	
	                                    Naziv
                                    )
                                    values
                                    (
	                                    @Naziv
                                    )";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Naziv", mjernajedinica.Naziv);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                komanda.Connection.Close();
            }

            return true;
        }

        public static bool IzmjeniSastojak(Sastojak sastojak)
        {
            string commandText = @"UPDATE [Sastojak] 

                                    SET 
	                                    Naziv = @Naziv
	                               

                                    WHERE
	                                    Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", sastojak.Id);
                komanda.Parameters.AddWithValue("@Naziv", sastojak.Naziv);
            
                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                komanda.Connection.Close();
            }

            return true;
        }


        public static bool IzmjeniZacin(Zacin zacin)
        {
            string commandText = @"UPDATE [Zacin] 

                                    SET 
	                                    Naziv = @Naziv
	                                 
                                    WHERE
	                                    Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", zacin.Id);
                komanda.Parameters.AddWithValue("@Naziv", zacin.Naziv);
             
                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                komanda.Connection.Close();
            }

            return true;
        }

        public static bool IzmjeniKorakPripreme(KorakPripreme korak)  //dodaj parametre za izmjenu
        {
            string commandText = @"UPDATE [KorakPripreme] 

                                    SET 
	                                    Naziv = @Naziv,
                                        DetaljanOpis = @DetaljanOpis
                                       
                                        Redoslijed = @Redoslijed,
                                        Trajanje = @Trajanje    
	                                 
                                    WHERE
	                                    Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;
                
                komanda.Parameters.AddWithValue("@Id", korak.Id);
                komanda.Parameters.AddWithValue("@Naziv", korak.Naziv);
                komanda.Parameters.AddWithValue("@DetaljanOpis", korak.DetaljanOpis);
             
                komanda.Parameters.AddWithValue("@Redoslijed", korak.Redoslijed);
                komanda.Parameters.AddWithValue("@Trajanje", korak.Trajanje);
                
                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                // prvo brisi sve
                ObrisiSastojkeIKorakePripreme(konekcija, korak);

                // snimi
                SpremiZacineKorakaPripreme(konekcija, korak);
                SpremiSastojkeKorakaPripreme(konekcija, korak);

                komanda.Connection.Close();
            }

            return true;
        }

        public static void ObrisiSastojkeIKorakePripreme(SqlConnection konekcija, KorakPripreme korakPripreme)
        {
            string commandText = @"DELETE FROM [dbo].[SastojakKorakaPripreme]
                                    WHERE KorakPripremeId = @KorakPripremeId;

                                   DELETE FROM [dbo].[ZacinKorakaPripreme]
                                    WHERE KorakPripremeId = @KorakPripremeId";

            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.ExecuteNonQuery();
            }


        }

        public static bool IzmjeniMjernuJeidnicu(MjernaJedinica mjernajedninca)
        {
            string commandText = @"UPDATE [MjernaJedinica] 

                                    SET 
	                                    Naziv = @Naziv

                                    WHERE
	                                    Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", mjernajedninca.Id);
                komanda.Parameters.AddWithValue("@Naziv", mjernajedninca.Naziv);
             
                komanda.Connection.Open();
                komanda.ExecuteNonQuery();

                komanda.Connection.Close();
            }

            return true;
        }



        public static bool SpremiRecept(Recept recept)
        {
            string commandText = @"insert into [Recept] 
                                    (	
	                                    NazivJela,
	                                    IdAdmin,
	                                    DatumRecepta,
	                                    PutanjaSlike	                                   
                                    )
                                    values
                                    (
	                                    @NazivJela, 
	                                    @IdAdmin,
	                                    @DatumRecepta,	                                   
	                                    @PutanjaSlike
                                    );
                                       Select @@Identity
                                    ";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@NazivJela", recept.NazivJela);
                komanda.Parameters.AddWithValue("@IdAdmin", recept.IdAdmin);
                komanda.Parameters.AddWithValue("@DatumRecepta", recept.DatumRecepta);
                komanda.Parameters.AddWithValue("@PutanjaSlike", recept.PutanjaSlike);

                komanda.Connection.Open();
                recept.Id = Convert.ToInt32(komanda.ExecuteScalar());               // vraća id nakon inserta

                komanda.Connection.Close();
            }

            return true;
        }

        public static bool IzmjeniRecept(Recept recept)
        {
            string commandText = @"UPDATE [Recept] 
                                    SET 
	                                    NazivJela = @NazivJela,
                                        IdAdmin = @IdAdmin,
                                        DatumRecepta = @DatumRecepta,
	                                    PutanjaSlike = @PutanjaSlike                             
	                                  
                                  WHERE  Id = @Id";                            
	                                                                    

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", recept.Id);
                komanda.Parameters.AddWithValue("@NazivJela", recept.NazivJela);
                komanda.Parameters.AddWithValue("@PutanjaSlike", recept.PutanjaSlike);
                komanda.Parameters.AddWithValue("@DatumRecepta", recept.DatumRecepta);
                komanda.Parameters.AddWithValue("@IdAdmin", recept.IdAdmin);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }
        
        public static bool SpremiAdmina(Admin admin)
        {
            string commandText = @"insert into [Admin] 
                                            (	
        	                                    Ime,
        	                                    Prezime,
        	                                    KorisnickoIme,
        	                                    Lozinka
        	                                    
                                            )
                                            values
                                            (
        	                                    @Ime,
        	                                    @Prezime,
        	                                    @KorisnickoIme,
        	                                    @Lozinka
    	                                    
                                            )";

                using (SqlConnection konekcija = KreirajKonekciju())
                using (SqlCommand komanda = new SqlCommand())
                {
                    komanda.CommandText = commandText;
                    komanda.Connection = konekcija;

                    komanda.Parameters.AddWithValue("@Ime", admin.Ime);
                    komanda.Parameters.AddWithValue("@Prezime", admin.Prezime);
                    komanda.Parameters.AddWithValue("@KorisnickoIme", admin.KorisnickoIme);
                    komanda.Parameters.AddWithValue("@Lozinka", admin.Lozinka);

                    komanda.Connection.Open();
                    komanda.ExecuteNonQuery();
                    komanda.Connection.Close();

                }

                return true;
        }

        public static bool IzmjeniAdmina(Admin admin)
        {
            string commandText = @"UPDATE [Admin] 
                                       SET    	
        	                                    Ime = @Ime,
        	                                    Prezime = @Prezime,
        	                                    KorisnickoIme = @KorisnickoIme,
        	                                    Lozinka = @Lozinka
        	                                    
                                       WHERE
                                               Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", admin.Id);
                komanda.Parameters.AddWithValue("@Ime", admin.Ime);
                komanda.Parameters.AddWithValue("@Prezime", admin.Prezime);
                komanda.Parameters.AddWithValue("@KorisnickoIme", admin.KorisnickoIme);
                komanda.Parameters.AddWithValue("@Lozinka", admin.Lozinka);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();

            }

            return true;
        }


        #endregion

        #region Public Metode - Select


        public static DataTable GetAllRecepies()
        {
            DataTable recepti = null;

            string sqlQuery = @"SELECT * FROM [Recept]";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "recepti");  // Recepti kao dataTable unutar dataASet-a

                recepti = dataSet.Tables["recepti"];

                konekcija.Close(); 
            }

            return recepti;
        }

        public static DataTable GetAllSastojciKP()
        {
            DataTable SastojakKorakaPripreme = null;

            string sqlQuery = @"SELECT * FROM [SastojakKorakaPripreme]";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "SastojciKP");  // Recepti kao dataTable unutar dataASet-a

                SastojakKorakaPripreme = dataSet.Tables["SastojciKP"];

                konekcija.Close();
            }

            return SastojakKorakaPripreme;
        }


        public static DataTable GetAllKoraciPripreme()
        {
            DataTable KorakPripreme = null;

            string sqlQuery = @"SELECT * FROM [KorakPripreme]";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "KoraciPripreme");  // KoraciPripreme kao dataTable unutar dataASet-a

                KorakPripreme = dataSet.Tables["KoraciPripreme"];

                konekcija.Close();
            }

            return KorakPripreme;
        }


        public static DataTable GetAllZaciniKP()
        {
            DataTable ZacinKorakaPripreme = null;

            string sqlQuery = @"SELECT * FROM [ZacinKorakaPripreme]";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "ZaciniKP");  // Recepti kao dataTable unutar dataASet-a

                ZacinKorakaPripreme = dataSet.Tables["ZaciniKP"];

                konekcija.Close();
            }

            return ZacinKorakaPripreme;
        }

        public static DataTable GetAllSteps()
        {
            DataTable koraci = null;

            string sqlQuery = @"SELECT * FROM [KorakPripreme]";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "koraci");  // Recepti kao dataTable unutar dataASet-a

                koraci = dataSet.Tables["koraci"];

                konekcija.Close();
            }

            return koraci;
        }


        public static DataTable GetAllIngredients() 
        {
            DataTable sastojci = null;

            string sqlQuery = @"SELECT *  FROM [Sastojak]
                                order by Id desc ";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);
                DataSet dataSet = new DataSet();  
                dataAdapter.Fill(dataSet, "sastojci");

                sastojci = dataSet.Tables["sastojci"];

                konekcija.Close();
            }

            return sastojci;
        }

        public static DataTable GetAllFlavors()
        {
            DataTable zacini = null;

            string sqlQuery = @"SELECT *  FROM [Zacin]
                                order by Id desc ";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "zacini");

                zacini = dataSet.Tables["zacini"];

                konekcija.Close();
            }

            return zacini;
        }

        public static DataTable GetAllMeasurements()
        {
            DataTable mjjed = null;

            string sqlQuery = @"SELECT *  FROM [MjernaJedinica]
                                order by Id desc ";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "mjjed");

                mjjed = dataSet.Tables["mjjed"];

                konekcija.Close();
            }

            return mjjed;
        }

        public static DataTable GetAllAdmins()
        {
            DataTable admini = null;

            string sqlQuery = @"SELECT * FROM [Admin]";

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, konekcija);
                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Admini");
                admini = dataSet.Tables["Admini"];

                konekcija.Close();

            }

            return admini;
        }

        

        #endregion

        #region Public Metode - Delete

        public static bool DeleteAdmin(int id)
        {
            bool success = false;

            try
            {
                string commandText = @" delete from [Admin] 
                                   where Id = @Id";

                using (SqlConnection konekcija = KreirajKonekciju())
                using (SqlCommand komanda = new SqlCommand())
                {
                    komanda.CommandText = commandText;
                    komanda.Connection = konekcija;

                    komanda.Parameters.AddWithValue("@Id", id);

                    komanda.Connection.Open();
                    komanda.ExecuteNonQuery();
                    komanda.Connection.Close();
                }

                success = true;

            }
            catch
            {
                success = false;            
            }
                     

            return success;
        }

        public static bool DeleteSastojakKP(int id)
        {
            string commandText = @" delete from [SastojakKorakaPripreme] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }

        public static bool DeleteKorakPripreme(int id)
        {
            string commandText = @" delete from [KorakPripreme] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }

        
        public static bool DeleteZacinKP(int id)
        {
            string commandText = @" DELETE FROM [ZacinKorakaPripreme] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }

        public static bool DeleteRecept(int id)
        {
            string commandText = @" delete from [Recept] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }



        public static bool DeleteSastojak(int id)
        {
            string commandText = @" delete from [Sastojak] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }


        public static bool DeleteZacin(int id)
        {
            string commandText = @" delete from [Zacin] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }

        public static bool DeleteMjernaJedinica(int id)
        {
            string commandText = @" delete from [MjernaJedinica] 
                                   where Id = @Id";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand())
            {
                komanda.CommandText = commandText;
                komanda.Connection = konekcija;

                komanda.Parameters.AddWithValue("@Id", id);

                komanda.Connection.Open();
                komanda.ExecuteNonQuery();
                komanda.Connection.Close();
            }

            return true;
        }


        #endregion

        #region Public Metode - Frontend

        public static List<Recept> UcitajSveRecepte() 
        {
            List<Recept> recepti = new List<Recept>();

            string sqlQuery = @"SELECT 
                                *, 
	                            UkupnoTrajanje = (select ISNULL(sum(Trajanje), 0) from KorakPripreme where IdRecept = recept.Id) 
                                FROM [Recept]";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Recept recept = new Recept();

                            recept.Id = Convert.ToInt32(dataReader["Id"]);
                            recept.IdAdmin = Convert.ToInt32(dataReader["IdAdmin"]);

                            recept.NazivJela = Convert.ToString(dataReader["NazivJela"]);
                            recept.PutanjaSlike = Convert.ToString(dataReader["PutanjaSlike"]);
                            recept.UkupnoTrajanje = Convert.ToDouble(dataReader["UkupnoTrajanje"]);

                            recepti.Add(recept);
                        }
                    }
                }

                conection.Close();

            }

            return recepti;
        }

        public static List<Recept> UcitajSveReceptePremaBrziniPripreme()
        {
            List<Recept> recepti = new List<Recept>();

            string sqlQuery = @"select * from
                                (
	                                select 
		                                *, 
		                                UkupnoTrajanje = (select ISNULL(sum(Trajanje), 0) from KorakPripreme where IdRecept = recept.Id)

	                                from Recept recept
                                ) 
                                Temp

                                where UkupnoTrajanje > 0

                                order by UkupnoTrajanje asc";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Recept recept = new Recept();

                            recept.Id = Convert.ToInt32(dataReader["Id"]);
                            recept.IdAdmin = Convert.ToInt32(dataReader["IdAdmin"]);

                            recept.NazivJela = Convert.ToString(dataReader["NazivJela"]);
                            recept.PutanjaSlike = Convert.ToString(dataReader["PutanjaSlike"]);
                            recept.UkupnoTrajanje = Convert.ToDouble(dataReader["UkupnoTrajanje"]);

                            recepti.Add(recept);
                        }
                    }
                }

                conection.Close();

            }

            return recepti;
        }


        public static List<Recept> UcitajTopRecepte()
        {
            List<Recept> recepti = new List<Recept>();

            string sqlQuery = @"SELECT top(5) * FROM Recept 
                                ORDER BY NazivJela asc";


            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Recept recept = new Recept();

                            recept.Id = Convert.ToInt32(dataReader["Id"]);
                            recept.IdAdmin = Convert.ToInt32(dataReader["IdAdmin"]);

                            recept.NazivJela = Convert.ToString(dataReader["NazivJela"]);
                            recept.PutanjaSlike = Convert.ToString(dataReader["PutanjaSlike"]);

                            recepti.Add(recept);
                        }
                    }
                }
                conection.Close();

            }

            return recepti;
        }

        public static Recept UcitajRecept(int Id)
        {
            Recept recept = null;

            string sqlQuery = @" SELECT *, 
	                                UkupnoTrajanje = (select ISNULL(sum(Trajanje), 0) from KorakPripreme where IdRecept = recept.Id) 
                                    FROM [Recept]
                                    where Id = @Id";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {               
                command.Parameters.AddWithValue("@Id", Id);
              
                command.Connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {                   
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                             recept= new Recept();

                             recept.Id = Convert.ToInt32(dataReader["Id"]);
                             recept.IdAdmin = Convert.ToInt32(dataReader["IdAdmin"]);
                         
                             recept.NazivJela = Convert.ToString(dataReader["NazivJela"]);
                             recept.PutanjaSlike = Convert.ToString(dataReader["PutanjaSlike"]);
                             recept.DatumRecepta = Convert.ToDateTime(dataReader["DatumRecepta"]);
                             recept.UkupnoTrajanje = Convert.ToDouble(dataReader["UkupnoTrajanje"]);
                            
                        }
                    }
                }

                recept.KoraciPripreme = UcitajSveKorakePripreme(Id, conection);


                conection.Close();
            }

            return recept;
        }
         


        public static List<Sastojak> UcitajSveSastojke()
        {
            List<Sastojak> sastojci = new List<Sastojak>();

            string sqlQuery = @"select * from Sastojak
                                order by Naziv desc";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Sastojak sastojak = new Sastojak();

                            sastojak.Id = Convert.ToInt32(dataReader["Id"]);
                          sastojak.Naziv= Convert.ToString(dataReader["Naziv"]);
                            
                            sastojci.Add(sastojak);
                        }
                    }
                }

                conection.Close();
            }

            return sastojci;
        }


        public static List<KorakPripreme> UcitajSveKorakePripreme(int receptId)
        {
            using (SqlConnection conection = KreirajKonekciju())
            {
                conection.Open();
                return UcitajSveKorakePripreme(receptId, conection);
            }
        }

        public static List<KorakPripreme> UcitajSveKorakePripreme(int receptId, SqlConnection conection)
        {
            List<KorakPripreme> koraciPripreme = new List<KorakPripreme>();

            string sqlQuery = @"select * from KorakPripreme
                                where idRecept = @IdRecept
                                order by Redoslijed desc";

            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {

                command.Parameters.AddWithValue("@IdRecept", receptId);
                // 1. konekcija je već otvorena

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            KorakPripreme korakPripreme = new KorakPripreme();

                            korakPripreme.Id = Convert.ToInt32(dataReader["Id"]);
                            korakPripreme.Naziv = Convert.ToString(dataReader["Naziv"]);
                            korakPripreme.Trajanje = Convert.ToDouble(dataReader["Trajanje"]);
                            korakPripreme.Redoslijed = Convert.ToInt32(dataReader["Redoslijed"]);
                            korakPripreme.DetaljanOpis = Convert.ToString(dataReader ["DetaljanOpis"]);
                                

                            koraciPripreme.Add(korakPripreme);

                        }
                    }
                }

                conection.Close();
            }

            return koraciPripreme;
        }


        public static List<Zacin> UcitajSveZacine()
        {
            List<Zacin> zacini = new List<Zacin>();

            string sqlQuery = @"select * from Zacin
                                order by Naziv desc";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Zacin zacin = new Zacin();

                            zacin.Id = Convert.ToInt32(dataReader["Id"]);
                            zacin.Naziv = Convert.ToString(dataReader["Naziv"]);

                            zacini.Add(zacin);
                        }
                    }
                }

                conection.Close();
            }

            return zacini;
        }

        public static List<MjernaJedinica> UcitajSveMjerneJedinice()
        {
            List<MjernaJedinica> mjedinice = new List<MjernaJedinica>();

            string sqlQuery = @"select * from MjernaJedinica
                                order by Naziv desc";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            MjernaJedinica mjednica = new MjernaJedinica();

                            mjednica.Id = Convert.ToInt32(dataReader["Id"]);
                            mjednica.Naziv = Convert.ToString(dataReader["Naziv"]);

                            mjedinice.Add(mjednica);
                        }
                    }
                }

                conection.Close();
            }

            return mjedinice;
        }


        public static List<Recept> PretraziRecepte(string searchPhrase)
        {
            List<Recept> recepti = new List<Recept>();

            string sqlQuery = @"SELECT * FROM Recept
                                WHERE NazivJela LIKE '%'+@SearchPhrase+'%' 
                                ORDER BY DatumRecepta DESC";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@SearchPhrase", searchPhrase);

                // 1. otvoriti konekciju
                command.Connection.Open();
                
                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {

                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Recept recept = new Recept();

                            recept.Id = Convert.ToInt32(dataReader["Id"]);

                            recept.NazivJela = Convert.ToString(dataReader["NazivJela"]);

                            recepti.Add(recept);
                        }
                    }
                }

                conection.Close();
            }

            return recepti;
        }

        public static Sastojak UcitajSastojak(int Id)
        {
            Sastojak rezultat = null;

            string sqlQuery = @" select * from Sastojak
                                    where Id = @Id";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@Id", Id);
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            rezultat = new Sastojak();

                            rezultat.Id = Convert.ToInt32(dataReader["Id"]);
                          
                            rezultat.Naziv = Convert.ToString(dataReader["Naziv"]);
                                                    
                        }
                    }
                }

                conection.Close();
            }
            return rezultat;
        }


        public static Zacin UcitajZacin(int Id)
        {
            Zacin rezultat = null;

            string sqlQuery = @" select * from Zacin
                                    where Id = @Id";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@Id", Id);
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            rezultat = new Zacin();

                            rezultat.Id = Convert.ToInt32(dataReader["Id"]);
                            
                            rezultat.Naziv = Convert.ToString(dataReader["Naziv"]);
                          

                        }
                    }
                }

                conection.Close();
            }
            return rezultat;
        }
        

        public static KorakPripreme UcitajKorakPripreme(int Id)
        {
            KorakPripreme rezultat = null;

            string sqlQuery = @" select * from KorakPripreme
                                    where Id = @Id";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@Id", Id);
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            rezultat = new KorakPripreme();

                            rezultat.Id = Convert.ToInt32(dataReader["Id"]);
                            rezultat.Naziv = Convert.ToString(dataReader["Naziv"]);
                            rezultat.DetaljanOpis = Convert.ToString(dataReader["DetaljanOpis"]);
                            rezultat.Trajanje = Convert.ToInt16(dataReader["Trajanje"]);
                            rezultat.Redoslijed = Convert.ToInt16(dataReader["Redoslijed"]);                          

                        }
                    }
                }

                conection.Close();
            }
            return rezultat;
        }

        public static List<ZacinKorakaPripreme> UcitajZacineKorakaPripreme(int idKorakaPripreme)
        {
            List<ZacinKorakaPripreme> zaciniKorakaPripreme = new List<ZacinKorakaPripreme>();

            string sqlQuery = @" SELECT * FROM [ZacinKorakaPripreme]
                                WHERE KorakPripremeId = @idKorakapripreme ";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {

                command.Parameters.AddWithValue("@idKorakaPripreme", idKorakaPripreme);
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ZacinKorakaPripreme zacinKoraka = new ZacinKorakaPripreme();
                            zaciniKorakaPripreme.Add(zacinKoraka);

                            zacinKoraka.Id = Convert.ToInt32(dataReader["Id"]);
                            zacinKoraka.Kolicina = Convert.ToDouble(dataReader["Kolicina"]);
                            zacinKoraka.KorakPripremeId = Convert.ToInt32(dataReader["KorakPripremeId"]);
                            zacinKoraka.MjernaJedinicaId = Convert.ToInt32(dataReader["MjernaJedinicaId"]);
                            zacinKoraka.ZacinId = Convert.ToInt32(dataReader["ZacinId"]);

                        }
                    }
                }
            }

            return zaciniKorakaPripreme;
        }


        public static List<SastojakKorakaPripreme> UcitajSastojkeKorakaPripreme(int idKorakaPripreme)
        {
            List<SastojakKorakaPripreme> sastojciKorakaPripreme = new List<SastojakKorakaPripreme>();

            string sqlQuery = @" SELECT * FROM [SastojakKorakaPripreme]
                                WHERE KorakPripremeId = @idKorakapripreme ";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {

                command.Parameters.AddWithValue("@idKorakaPripreme", idKorakaPripreme);
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            SastojakKorakaPripreme sastojakKoraka = new SastojakKorakaPripreme();
                            sastojciKorakaPripreme.Add(sastojakKoraka);

                            sastojakKoraka.Id = Convert.ToInt32(dataReader["Id"]);
                            sastojakKoraka.Kolicina = Convert.ToDouble(dataReader["Kolicina"]);
                            sastojakKoraka.KorakPripremeId = Convert.ToInt32(dataReader["KorakPripremeId"]);
                            sastojakKoraka.MjernaJedinicaId = Convert.ToInt32(dataReader["MjernaJedinicaId"]);
                            sastojakKoraka.SastojakId = Convert.ToInt32(dataReader["SastojakId"]);

                        }
                    }
                }
            }

            return sastojciKorakaPripreme;
        }



        public static MjernaJedinica UcitajMjernuJedinicu(int Id)
        {
            MjernaJedinica rezultat = null;

            string sqlQuery = @" select * from MjernaJedinica
                                    where Id = @Id";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@Id", Id);
                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            rezultat = new MjernaJedinica();

                            rezultat.Id = Convert.ToInt32(dataReader["Id"]);
                            rezultat.Naziv = Convert.ToString(dataReader["Naziv"]);
                        
                        }
                    }
                }

                conection.Close();
            }
            return rezultat;
        }



        public static Admin UcitajAdmina(string korisnickoIme)
        {
            Admin result = null;

            string sqlQuery = @"select * from [Admin]
                            where KorisnickoIme = @KorisnickoIme";

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@KorisnickoIme", korisnickoIme);

                // 1. otvoriti konekciju
                command.Connection.Open();

                // 2. instancirati data reader koji cita podatke iz baze
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    // 3. provjera da li je baza vratila ikakve podatke
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            result = new Admin();

                            result.Id = Convert.ToInt32(dataReader["Id"]);
                            result.Ime = Convert.ToString(dataReader["Ime"]);
                            result.Prezime = Convert.ToString(dataReader["Prezime"]);
                            result.KorisnickoIme = Convert.ToString(dataReader["KorisnickoIme"]);
                            result.Lozinka = Convert.ToString(dataReader["Lozinka"]);

                        }
                    }
                }

                conection.Close();
            }
                        
            return result;
        }

        public static Admin UcitajAdmina(int Id)
        {
            Admin result = null;

            string sqlQuery = @"SELECT * FROM [Admin]
                                    where Id = @Id";

            using (SqlConnection conection = KreirajKonekciju())
            using (SqlCommand command = new SqlCommand(sqlQuery, conection))
            {
                command.Parameters.AddWithValue("@Id", Id);

                command.Connection.Open();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        if (dataReader.Read())
                        {
                            result = new Admin();

                            result.Id = Convert.ToInt32(dataReader["Id"]);
                            result.Ime = Convert.ToString(dataReader["Ime"]);
                            result.Prezime = Convert.ToString(dataReader["Prezime"]);
                            result.KorisnickoIme = Convert.ToString(dataReader["KorisnickoIme"]);
                            result.Lozinka = Convert.ToString(dataReader["Lozinka"]);

                        }
                    }
                }
                conection.Close();
            }

            return result;
        }
        
        #endregion


        #region Private Metode

        private static string UcitajConnectionString()
        {
             // WebConfigurationManager klasa služi za čitanje konfiguracijskih postavki koje se definiraju u web.config-u

            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return connectionString;
        }

        private static SqlConnection KreirajKonekciju()
        {
            string connectionString = UcitajConnectionString();

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        #endregion
    }
}