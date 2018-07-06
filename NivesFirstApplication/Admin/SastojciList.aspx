<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SastojciList.aspx.cs" Inherits="NivesFirstApplication.Administration.SastojciList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li> Sastojak je uspješno obrisan! </li>
        </ul>
    </div>  

     <div class="widget-top">
		<h4>Pregled sastojka </h4>
	</div>

    <div class="widget-content module">
	    <div class="dataTables_wrapper">
            <form runat="server">
               <asp:GridView ID="gridNovosti" runat="server" DataKeyNames="Id" OnRowCommand="gridNovosti_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False">
                        
                 <Columns>
                        <asp:BoundField HeaderText="Naziv sastojka" DataField="Naziv" />               
                     <%--   <asp:BoundField HeaderText="Kratki opis" DataField="KratkiOpis" />--%>
               
                        <asp:ButtonField ButtonType="Button" Text="Izmjeni"  CommandName ="izmjeni" />
                        <asp:ButtonField ButtonType="Button" Text="Briši"  CommandName ="ukloni" />         

                 </Columns>
                    <HeaderStyle BackColor="#FFFFCC" />
               </asp:GridView>
          <br />
            <ul>
              <li>
                  <p>
                        Odaberite za unos novog sastojka.  <br />
                         <asp:Button CssClass="submit-button" runat="server" OnClick="Button1_Click" Text="Dodaj sastojak" />
                  </p>           
               </li> 
            </ul>                        
    </form>
         </div>
    </div>
</asp:Content>
