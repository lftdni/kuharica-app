<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="NivesFirstApplication.Administration.AdminList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li id="liPoruka" runat="server"> </li>

        </ul>
    </div>  

    <div class="widget-top">
		<h4>Lista administratora</h4>
	</div>

    <div class="widget-content module">
			<div class="dataTables_wrapper">
               <form runat="server">
                   <asp:GridView ID="gridAdmini" runat="server" DataKeyNames="Id" OnRowCommand="gridAdmini_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False" >
        
                    <Columns>
                        <asp:BoundField HeaderText="Ime" DataField="Ime" />
                        <asp:BoundField HeaderText="Prezime" DataField="Prezime" />
                        <asp:BoundField HeaderText="Korisnicko ime" DataField="KorisnickoIme"  />
                        <asp:BoundField HeaderText="Lozinka" DataField="Lozinka"  />
                        <asp:ButtonField ButtonType="Button" Text="Izmjeni" CommandName ="izmjeni" />
                        <asp:ButtonField ButtonType="Button" Text="Briši" CommandName ="ukloni" />
                    </Columns>         
        
                       <HeaderStyle BackColor="#FFFFCC" />        
                </asp:GridView>
                   <br />
                  <ul>
                      <li>
                         <p>
                             Odaberite za unos novog administratora za upravljanje web stranica sjedišta.  <br />
                             <asp:Button CssClass="submit-button" ID="btnDodajAdmina" runat="server" OnClick="Button1_Click" Text="Dodaj admina" CausesValidation="False" />                      
                             
                         </p> 
                      </li>
                  </ul>
               </form>
              
            </div>
    </div>
 
</asp:Content>
