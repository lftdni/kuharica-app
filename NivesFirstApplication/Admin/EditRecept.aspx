<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditRecept.aspx.cs" Inherits="NivesFirstApplication.Administration.EditRecept" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
             <li id="liPoruka" runat="server">  </li>
        </ul>
    </div>

    <div class="widget-top">
        <h4>Unos recepta za objavu</h4>
    </div>

      <div class="widget-content module">
        <div class="form-grid">

            <form id="form"  runat="server" class="leftLabel">
      <ul>
          <li>
               <asp:Label CssClass="fldTitle"  ID="lblNaslov" runat="server" AssociatedControlID="txtNaslov" Text="Unesi naziv jela:"></asp:Label>
               <div class="filedwrap">
                <asp:TextBox runat="server" ID="txtNaslov" CssClass="large textips"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNaslov" runat="server" ControlToValidate="txtNaslov" Display="Dynamic" ErrorMessage="Nije unesen naziv jela!" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
          </li>
           <li>
               <asp:Label  CssClass="fldTitle"  ID="lblDatum" runat="server" Text="Datum" AssociatedControlID="txtDatum"></asp:Label>
                <div class="fieldwrap">
                    <asp:TextBox  ID="txtDatum" runat="server" CssClass="datepicker"></asp:TextBox>
                    <asp:RequiredFieldValidator  ID="rfvDatum" runat="server" ControlToValidate="txtDatum"  Display="Dynamic" ErrorMessage="Nije unesen datum!" ForeColor="Red">  </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvDatum" runat="server" ControlToValidate="txtDatum" Display="None" ErrorMessage="Datum nije ispravan" MaximumValue="01.01.2099" MinimumValue="01.01.1900" Type="Date"></asp:RangeValidator>
                </div>
           </li>


          <li> 
              <asp:Label CssClass="fldTitle" ID="lblKoraciPripreme" runat="server" Text="Dodaj novi korak pripreme"> </asp:Label>
              <div class="fieldwrap">  
                  <asp:Button CssClass="ui-button-text" ID="btnDodajKorak" OnClick="dodajKorak_Click" runat="server" text="Dodaj novi korak pripreme" CausesValidation="false"/>  
              </div>

          </li>

          <li> 
              <asp:Label CssClass="fldTitle" ID="lblKPripreme" runat="server" Text="Pregled koraka pripreme"> </asp:Label>
              <br />

              	<div class="dataTables_wrapper">
                
                    <asp:GridView ID="gridReceptKoraci" runat="server" DataKeyNames="Id" OnRowCommand="gridReceptKoraci_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False"> <%--//display data-table-theme--%>

                        <Columns>
                            
                            <asp:BoundField HeaderText="Naziv" DataField="Naziv" />  
                            <asp:BoundField HeaderText="Trajanje u min." DataField="Trajanje" />  
                            <asp:BoundField HeaderText="Redoslijed" DataField="Redoslijed" />  
                          
                            <asp:ButtonField ButtonType="Button" Text="Ukloni"  CommandName ="ukloni" />

                        </Columns>

                    </asp:GridView>
                    <br />                
                
                </div>

          </li>      
          
          <li>
               <asp:Label runat="server" ID="lblUkupnoTrajanje" Text="Ukupno trajanje"> </asp:Label>

              
          </li>

          <li>
                <asp:Label  CssClass="fldTitle" ID="lblPutanja" runat="server" Text="Odaberi sliku jela:"></asp:Label>
              <div class="filedwrap">                 
                  <asp:FileUpload runat="server" ID="fuImage" ValidateRequestMode="Disabled"/>
              </div>  
                
              <asp:Image ID="imgContentImage" runat="server"  Width="300"/>  
             
              <span class="img-pre">
                  <asp:LinkButton ID ="btnUploadImage" runat="server" OnClick="btnUploadImage_Click" CausesValidation="false" ToolTip=" Učitaj sliku"></asp:LinkButton>                  
                </span>

              <span class="img-del">
                  <asp:LinkButton ID ="btnRemoveImage" runat="server" OnClick="btnRemoveImage_Click" CausesValidation="false" ToolTip="Obriši učitanu sliku"></asp:LinkButton>
              </span>
              <br />

              <asp:Label runat="server" Text="Napomena"> Slika u aplikaciji nije prirodne veličine za objavu! </asp:Label>
             </li>            
            
         

        
          <li>
             <div class="filedwrap">
               <asp:Button  CssClass="submit-button" ID="btnSpremi" runat="server" OnClick="btnSpremi_Click" Text="Spremi" />
                <asp:Button  CssClass="submit-button" ID="btnPonisti" runat="server" Text="Odustani i idi na listu" OnClick="btnPonisti_Click" CausesValidation="False" />
             </div>

             </li>         

      </ul>                       
             </form>
        </div>
     </div>

</asp:Content>
