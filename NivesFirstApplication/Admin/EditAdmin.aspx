<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="NivesFirstApplication.Administration.EditAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">


    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li id="liPoruka" runat="server">  </li>
        </ul>
    </div>     

    <div class="widget-top">
        <h4>Unos admina</h4>
    </div>

    <div class="widget-content module">
        <div class="form-grid">

            <form id="form"  runat="server" class="leftLabel">
                
                <ul>
                    <li aria-expanded="true">
                         <asp:Label CssClass="fldTitle" ID="lblIme" runat="server" AssociatedControlID="txtIme" Text="Ime:"></asp:Label> 
                         <div class="fieldwrap">
                             <asp:TextBox ID="txtIme" runat="server" CssClass="large textips"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rvfIme" runat="server" Display="Dynamic" ErrorMessage="Nije uneseno ime!" ControlToValidate="txtIme" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                    </li>
                    <li>
                        <asp:Label CssClass="fldTitle" ID="lblPrezime" runat="server" AssociatedControlID="txtPrezime" Text="Prezime:"></asp:Label>
                        <div class="fieldwrap">
                            <asp:TextBox ID="txtPrezime" runat="server" CssClass="large textips"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfPrezime" runat="server" Display="Dynamic" ErrorMessage="Nije uneseno prezime!" ControlToValidate="txtPrezime" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </li>
                    
                    <li>
                        <asp:Label CssClass="fldTitle" ID="lblKorisnik" runat="server" AssociatedControlID="txtKorisnik" Text="Korisnicko ime:"></asp:Label>
                        <div class="fieldwrap">
                            <asp:TextBox ID="txtKorisnik" runat="server" CssClass="large textips"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvfKorisnik" runat="server" Display="Dynamic" ErrorMessage="Nije uneseno korisnicko ime!" ControlToValidate="txtKorisnik"  ForeColor="Red"></asp:RequiredFieldValidator>
                          </div>
                    </li>

                    <li>
                        <asp:Label CssClass="fldTitle" ID="Lozinka" runat="server" AssociatedControlID="txtLozinka" Text="Lozinka:"></asp:Label>
                        <div class="fieldwrap">                          
                            <asp:TextBox ID="txtLozinka" runat="server" TextMode="Password" CssClass="large textips"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLozinka" runat="server" Display="Dynamic" ErrorMessage="Nije unesena lozinka!" ControlToValidate="txtLozinka" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </li>

                    <li>
                        <asp:Label CssClass="fldTitle" ID="Label1" runat="server" Text="Potvrda lozinke:" AssociatedControlID="rfvPotvrdaL"></asp:Label>
                        <div class="fieldwrap">
                            <asp:TextBox  ID="txtPotvrda" runat="server" TextMode="Password" CssClass="large textips"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPotvrdaL" runat="server" ControlToValidate="txtPotvrda" Display="Dynamic" ErrorMessage="Lozinka nije potvrđena !"  ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPassword" runat="server" ControlToCompare="txtLozinka" ControlToValidate="txtPotvrda" Display="Dynamic" ErrorMessage="Lozinke se ne podudaraju!"  ForeColor="Red"></asp:CompareValidator>
                        </div>
                    </li>

                    <li>                       
                    <div class="fieldwrap">
                     <asp:Button CssClass="submit-button" ID="btnPotvrdi" runat="server" OnClick="btnPotvrdi_Click" Text="Potvrdi" />
                        <asp:Button CssClass="submit-button" ID="btnNatrag" runat="server" OnClick="btnNatrag_Click" Text="Natrag na listu" CausesValidation="false"/>

                        </div>
                </li>
                </ul>
 
            </form>
        </div>
    </div> 

</asp:Content>
