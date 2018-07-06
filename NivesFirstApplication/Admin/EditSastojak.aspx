<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="~/Admin/EditSastojak.aspx.cs" Inherits="NivesFirstApplication.Administration.EditSastojak" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    
    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li id="liPoruka" runat="server">  </li>
        </ul>
    </div>
     
    <div class="widget-top">
        <h4>Unos sastojka za objavu </h4>
    </div>
        
    <div class="widget-content module">
        <div class="form-grid">
            
   <form id="form"  runat="server" class="leftLabel">
       <ul>
           <li>
               <asp:Label  CssClass="fldTitle"  ID="lblNaslov" runat="server" AssociatedControlID="txtNaziv" Text="Unesi naziv sastojka"></asp:Label>
                <div class="fieldwrap">
                    <asp:TextBox CssClass="large textips" ID="txtNaziv" runat="server" Wrap="False"></asp:TextBox>
                    <asp:RequiredFieldValidator   ID="rfvNaslov" runat="server" ControlToValidate="txtNaziv" Display="Dynamic" ErrorMessage="Naziv sastojka je obavezan!" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
          </li>
       
                
       
           <li>
                  <asp:Button CssClass="submit-button" ID="btnPotvrdi" runat="server" OnClick="Button1_Click" Text="Potvrdi" />
                  <asp:Button CssClass="submit-button" ID="Button2" CausesValidation="false" runat="server" OnClick="Button2_Click" Text="Odustani i idi na listu" />
           </li>          
                 
       </ul>
     </form>
   </div>
        </div>
</asp:Content>
