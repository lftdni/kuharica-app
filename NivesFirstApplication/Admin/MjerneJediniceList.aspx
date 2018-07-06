<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MjerneJediniceList.aspx.cs" Inherits="NivesFirstApplication.Administration.MjerneJediniceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li> Mjerna jedinica je uspješno obrisana! </li>
        </ul>
    </div>  

     <div class="widget-top">
		<h4>Pregled mjernih jedinica </h4>
	</div>

    <div class="widget-content module">
	    <div class="dataTables_wrapper">
            <form runat="server">
               <asp:GridView ID="gridNovosti" runat="server" DataKeyNames="Id" OnRowCommand="gridNovosti_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False">
                        
                 <Columns>
                        <asp:BoundField HeaderText="Naziv mjerne jedinice" DataField="Naziv" />               
                 
                        <asp:ButtonField ButtonType="Button" Text="Izmjeni"  CommandName ="izmjeni" />
                        <asp:ButtonField ButtonType="Button" Text="Briši"  CommandName ="ukloni" />         

                 </Columns>
                    <HeaderStyle BackColor="#FFFFCC" />
               </asp:GridView>
          <br />
            <ul>
              <li>
                  <p>
                        Odaberite za unos nove mjerne jedinice. <br />
                         <asp:Button CssClass="submit-button" runat="server" OnClick="Button1_Click" Text="Dodaj novu mjernu jedinicu" />
                  </p>           
               </li> 
            </ul>                        
    </form>
         </div>
    </div>
</asp:Content>
