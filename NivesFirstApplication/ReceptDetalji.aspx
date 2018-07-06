<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReceptDetalji.aspx.cs" Inherits="NivesFirstApplication.ReceptDetalji" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
     <div class="grid_9">

         <h3>
             <asp:Literal ID="litReceptNaziv" runat="server"></asp:Literal>
         </h3>
         <p>
             <asp:Literal ID="litReceptTrajanje" runat="server"></asp:Literal>
         </p>
         
         <asp:Literal ID="litKoraciPripreme" runat="server"></asp:Literal>

     </div>

    


</asp:Content>
