<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="~/Admin/EditKorakPripreme.aspx.cs" Inherits="NivesFirstApplication.Administration.EditKorakPripreme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    
    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li id="liPoruka" runat="server">  </li>
        </ul>

    </div>
     
    <div class="widget-top">
        <h4>Unos novosti za objavu </h4>
    </div>
        
    <div class="widget-content module">
        <div class="form-grid">
            
   <form id="form"  runat="server" class="leftLabel">
       <ul>
           
           <li>
               <asp:Label  CssClass="fldTitle"  ID="lblNaziv" runat="server" AssociatedControlID="txtNaziv" Text="Naziv koraka"></asp:Label>
                <div class="fieldwrap">
                    <asp:TextBox CssClass="large textips" ID="txtNaziv" runat="server" Wrap="False"></asp:TextBox>
                    <asp:RequiredFieldValidator   ID="rfvNaziv" runat="server" ControlToValidate="txtNaziv" Display="Dynamic" ErrorMessage="Naziv koraka je obavezan!" ForeColor="Red"  ValidationGroup="VGDefault"></asp:RequiredFieldValidator>
                </div>
          </li>   

                <li>
                <asp:Label  CssClass="fldTitle"  ID="lblTrajanje" runat="server" Text="Trajanje:" AssociatedControlID="txtTrajanje"></asp:Label>
                <div class="fieldwrap">
                    <asp:TextBox CssClass="large textips" ID="txtTrajanje" runat="server" Wrap= "false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTrajanje" runat="server" ControlToValidate="txtTrajanje" Display="Dynamic" ErrorMessage="Trajanje koraka je obavezno!" ForeColor="Red"  ValidationGroup="VGDefault"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ForeColor="Red" ID="revTrajanje" runat="server" ErrorMessage="Neispravan unos" ValidationGroup="VGDefault" ControlToValidate="txtTrajanje" Display="Dynamic" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>

                </div>

                </li>

           <li>
                <asp:Label  CssClass="fldTitle"  ID="lblRedoslijed" runat="server" Text="Redni broj koraka:" AssociatedControlID="txtRedoslijed"></asp:Label>
                <div class="fieldwrap">
                   <asp:TextBox CssClass="large textips" ID="txtRedoslijed" runat="server" wrap="false"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvRedoslijed" runat="server" ControlToValidate="txtRedoslijed" Display="Dynamic" ErrorMessage="Redoslijed koraka je obavezan!" ForeColor="Red"  ValidationGroup="VGDefault"></asp:RequiredFieldValidator>
 
                </div>
           </li>                    
          
           <li>
                <asp:Label  CssClass="fldTitle"  ID="lblDugiO" runat="server" Text="Detaljan opis" AssociatedControlID="txtDugiO"></asp:Label>
                <div class="fieldwrap">
                    <asp:TextBox CssClass="large tinymce-simple" ID="txtDugiO" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDetaljanO" runat="server" ControlToValidate="txtDugiO" Display="Dynamic" ErrorMessage="Opis je obavezan!" ForeColor="Red"  ValidationGroup="VGDefault"> </asp:RequiredFieldValidator>

                </div>
           </li>

           <li>
               <div class="widget-top">
		        <h4>FORMA ZA UNOS SASTOJAKA KORAKA PRIPREME  </h4>
	           </div>              
           </li>
                        <li>
                            <asp:DropDownList CssClass="list" ID="ddlSastojak" runat="server"></asp:DropDownList>
                            <asp:TextBox CssClass="large textips" ID="txtKolicinaMjSastojak" runat="server" Wrap="false" Width="145px"></asp:TextBox>
                             <asp:RequiredFieldValidator ForeColor="Red" ID="rfvKolSastojak" runat="server" ErrorMessage="Upiši količinu mj. jed." ValidationGroup="VGSastojakKoraka" ControlToValidate="txtKolicinaMjSastojak"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ForeColor="Red" ID="revMjSastojak" runat="server" ErrorMessage="Neispravan unos" ValidationGroup="VGSastojakKoraka" ControlToValidate="txtKolicinaMjSastojak" Display="Dynamic" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                            <asp:DropDownList CssClass="list" ID="ddlSastojakMjernaJedinica" runat="server"></asp:DropDownList>                                            
                           
                            <asp:Button CssClass="submit-button" runat="server" Text="Dodaj sastojak" OnClick="btnDodajSastojakKoraka_Click" ID="btnDodajSastojakKoraka" ValidationGroup="VGSastojakKoraka"  />
                       </li>
                 

          <li> <div class="widget-content module"> 

			<div class="dataTables_wrapper">
                    <asp:GridView ID="gridSastojciKP" runat="server" DataKeyNames="TempId" OnRowCommand="gridSastojciKP_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False"> 

                        <Columns>
                            <asp:BoundField HeaderText="Sastojak" DataField="Sastojak.Naziv" />   
                            <asp:BoundField HeaderText="Količina" DataField="Kolicina" /> 
                            <asp:BoundField HeaderText="Mjerna jedinica" DataField="MjernaJedinica.Naziv" />                       
                                        
                          
                            <asp:ButtonField ButtonType="Button" Text="Ukloni"  CommandName ="ukloni" />
                        </Columns>

                    </asp:GridView>
                    <br />
                  
            </div>
              </div> 
          </li>                             
                   
                <li>
                    <div class="widget-top">
		                <h4>FORMA ZA UNOS ZAČINA KORAKA PRIPREME  </h4>
	                </div>              
                </li>                         
                 
                        <li>
                            <asp:DropDownList CssClass="list" ID="ddlZacin" runat="server"> </asp:DropDownList>
                            <asp:TextBox CssClass="large textips" ID="txtKolicinaMjZacin" runat="server" Wrap="false" Width="145px" ValidationGroup="VGZacinKoraka"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="rfvKolicinaZacin" runat="server" ErrorMessage="Upiši količinu mj. jed." ValidationGroup="VGZacinKoraka" ControlToValidate="txtKolicinaMjZacin"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ForeColor="Red" ID="revMjZacin" runat="server" ErrorMessage="Neispravan unos" ValidationGroup="VGZacinKoraka" ControlToValidate="txtKolicinaMjZacin" Display="Dynamic" ValidationExpression="\d+(\.\d{1,2})?"></asp:RegularExpressionValidator>
                            <asp:DropDownList CssClass="list" ID="ddlZacinMjernaJedinica" runat="server"></asp:DropDownList>                                            
                            <asp:Button CssClass="submit-button" runat="server" Text="Dodaj zacin" OnClick="btnDodajZacinKoraka_Click" ID="btnDodajZacinKoraka" ValidationGroup="VGZacinKoraka" />
                        </li>                                      
                  
            <li> 
			    <div class="dataTables_wrapper"> 
                    <asp:GridView ID="gridZaciniKP" runat="server" DataKeyNames="TempId" OnRowCommand="gridZaciniKP_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False"> 

                        <Columns>
                            <asp:BoundField HeaderText="Zacin" DataField="Zacin.Naziv" />   
                            <asp:BoundField HeaderText="Količina" DataField="Kolicina" /> 
                            <asp:BoundField HeaderText="Mjerna jedinica" DataField="MjernaJedinica.Naziv" />                        
                            <asp:ButtonField ButtonType="Button" Text="Ukloni"  CommandName ="ukloni" />
                        </Columns>

                    </asp:GridView>
                    <br />
                   
                </div>
           </li>                          
       
                <li>
                  <asp:Button CssClass="submit-button" ID="btnPotvrdi" runat="server" OnClick="SpremiKorakePripreme" Text="Potvrdi"  ValidationGroup="VGDefault" />
                  <asp:Button CssClass="submit-button" ID="Button2" CausesValidation="false" runat="server" OnClick="NatragNaRecept" Text="Odustani i idi na listu" />
                </li>       

             
             
    </ul>       
     </form>
   </div>
        </div>
</asp:Content>
