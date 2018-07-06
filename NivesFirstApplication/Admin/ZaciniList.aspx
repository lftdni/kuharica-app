<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ZaciniList.aspx.cs" Inherits="NivesFirstApplication.Administration.ZaciniList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".deleteObject").click(function (e) {

   
                return false;
            });
        });
        
    </script>

    <div class="notification-success" id="divPoruka" runat="server" visible="false">
        <ul>
            <li> Začin je uspješno obrisan! </li>
        </ul>
    </div>  

     <div class="widget-top">
		<h4>Pregled recepata </h4>
	</div>
   
    <div class="widget-content module">
			<div class="dataTables_wrapper">
                <form runat="server">
                    <asp:GridView ID="gridBaneri" runat="server" DataKeyNames="Id" OnRowCommand="gridBaneri_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False">

                        <Columns>
                          
                            <asp:BoundField HeaderText="Naziv začina" DataField="Naziv" />
                       
                             <asp:ButtonField ButtonType="Button" Text="Izmjeni"  CommandName ="izmjeni" />
                            <asp:ButtonField ButtonType="Button" Text="Briši"  CommandName ="ukloni" />

                        </Columns>

                    </asp:GridView>
                    <br />
                    <ul>
                        <li>
                            <p> Odaberite za unos novog začina za objavu: <br />
                             <asp:Button CssClass="submit-button" runat="server" Text="Dodaj začin" OnClick="Unnamed1_Click" ID="btnDodajBaner" CausesValidation="False" />
                            </p>
                        </li>
                    </ul> 
          </form> 
      </div>
        </div>

</asp:Content>
