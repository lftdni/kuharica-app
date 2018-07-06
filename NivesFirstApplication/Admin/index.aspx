<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NivesFirstApplication.Administration.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">


    <div class="grid_9">
        <br /> 
        
							<h4>DOBRODOŠLI !</h4>

							<p>
                                Ovo je upravljački sustav namjenjen za upravljanje sadržajem aplikacije "BrzaKuharicaBETA".
                                S lijeve strane nalazi se panel koji nudi mogućnost upravljanja sadržajem za objavu na stranici.
							</p>
                            <p>   
                                
                                Odabirom opcije "Sastojci", administrator ima mogućnost unosa novog sastojka za objavu. <br />
                                 Uz to nudi se mogućnost pregleda unesenih sastojaka.
                            </p>

                             <p>   
                                Odabirom ocije "Začini", administrator ima mogućnost unosa začina za objavu.
                                 Također je moguće pregledati unesene začine.
                            </p>
                            
                            <p>   
                                Odabirom ocije "Mjerne jedinice", administrator ima mogućnost unosa mjernih jedinica za objavu.
                                 Također je moguće pregledati unesene mjerne jedinice.
                            </p>

                              <p>

                                Odabirom opcije panela "Administratori", postojećem administratoru nudi se mogućnost unos novog administratora.
							 
							</p>
        <br />
                           <h4>UPUTE I NAPOMENE !</h4>
                
                            <p>
                                Prilikom unosa željenog sadržaja za objavu, obavezno morate unositi valjne podatke.
                                Takvi podaci spremaju se u bazu podataka koja omogućuje prikaz istih na našim web stranicama.

                                </p>

						</div>

</asp:Content>
