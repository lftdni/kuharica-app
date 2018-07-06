<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ReceptList.aspx.cs" Inherits="NivesFirstApplication.Administration.ReceptList" %>
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
            <li> Recept je uspješno obrisan! </li>
        </ul>
    </div>  

     <div class="widget-top">
		<h4>Pregled recepata </h4>
	</div>
   
    <div class="widget-content module">
			<div class="dataTables_wrapper">
                <form runat="server">
                    <asp:GridView ID="gridRecepti" runat="server" DataKeyNames="Id" OnRowCommand="gridRecepti_RowCommand" CssClass="display data-table-theme" AutoGenerateColumns="False"> <%--widget-panel grid_12--%>

                        <Columns>
                            <asp:ImageField HeaderText="Slika" DataImageUrlField="PutanjaSlike" ControlStyle-Width="150"></asp:ImageField>
                            <asp:BoundField HeaderText="Naslov recepta ..." DataField="NazivJela" />
                       
                             <asp:ButtonField ButtonType="Button" Text="Izmjeni"  CommandName ="izmjeni" />
                            <asp:ButtonField ButtonType="Button" Text="Briši"  CommandName ="ukloni" />

                        </Columns>

                    </asp:GridView>
                    <br />
                    <ul>
                        <li>
                            <p> Odaberite za unos novog recepta za objavu: <br />
                             <asp:Button CssClass="submit-button" runat="server" Text="Dodaj recept" OnClick="Unnamed1_Click" ID="btnDodajRecept" CausesValidation="False" />
                            </p>
                        </li>
                    </ul> 
          </form> 
      </div>
        </div>

</asp:Content>
