<%@ Page Title="Registracija" Language="C#" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="NivesFirstApplication.Registracija"  MasterPageFile="~/Site1.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <form runat="server" id="fromMain">
    <div class="list">
        <div class="item list2">

            <h3>Registrirajte se</h3>

            <div class="formKontakt">

                <asp:Literal ID="litMessages" runat="server"></asp:Literal> 
                <asp:ValidationSummary runat="server" ID="vsKontakt" CssClass="notification-error" ForeColor="Pink" />
            </div>

            <div class="sdescription">
				<p> Ovdje se možete registrirati kako biste pristupili web-aplikaciji  ! </p>
			</div>

			<div class="clear"></div>
        </div>

        <div class="item list2">

            <div class="form" id="queryForm" runat="server">
                <h3> Obrazac za registraciju:</h3>
                <p>Polja označena zvjezdicom <span class="obavezno">(*)</span> molimo obvezno ispuniti.</p>
                <fieldset class="fieldset">
                    
                    <p class="name">
                        <asp:Label ID="lblIme" runat="server" Text="Ime:" AssociatedControlID="txtIme"></asp:Label>  
                        <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvIme" ControlToValidate="txtIme" ErrorMessage="Molimo Vas upišite Vaše ime" 
                            Display="None"></asp:RequiredFieldValidator>
					</p>
                    <p class="prezime">
                        <asp:Label ID="lblPrezime" runat="server" Text="Prezime:" AssociatedControlID="txtPrezime"></asp:Label>  
                        <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfvPrezime" ControlToValidate="txtPrezime" ErrorMessage="Molimo Vas upišite Vaše prezime" 
                            Display="None"></asp:RequiredFieldValidator>
					</p>

                     <p class="korisnickoime">
                        <asp:Label ID="lblKorisnickoIme" runat="server" Text="KorisnickoIme:" AssociatedControlID="txtKorisnickoIme"></asp:Label>  
                        <asp:TextBox ID="txtKorisnickoIme" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rvfKorisnickoIme" ControlToValidate="txtKorisnickoIme" ErrorMessage=" Molimo Vas upišite Vašu željenu lozinku za prijevu u sustav" 
                            Display="None"></asp:RequiredFieldValidator>
					</p>

                     <p class="lozinka">
                        <asp:Label ID="lblLozinka" runat="server" Text="Lozinka:" AssociatedControlID="txtLozinka"></asp:Label>  
                        <asp:TextBox ID="txtLozinka" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rvfLozinka" ControlToValidate="txtLozinka" ErrorMessage=" Molimo Vas upišite Vašu željenu lozinku za prijevu u sustav" 
                            Display="None"></asp:RequiredFieldValidator>
					</p>
                                                            
                    
                    <div class="buttonPosition"> 
						<label>
                            <asp:Button ID="btnReset" runat="server" Text="Obriši" CssClass="delete" OnClick="btnReset_Click" />
						</label> 
                            
						<label>
                            <asp:Button ID="btnSend" runat="server" Text="Pošalji" CssClass="submit" OnClick="btnSend_Click"/>
						</label>

					</div>

                </fieldset>
            </div>
            <div id="mapa">
				<div class="item">
					<h4>Naša lokacija: </h4>
				</div>
				<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d44864.952966495344!2d14.426816299999999!3d45.34760995!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4764a12517aabe2d%3A0x373c6f383dcbb670!2sRijeka!5e0!3m2!1sen!2s!4v1402892794850"></iframe>
			</div>

            <div class="clear"></div>
        </div>

    </div>
    </form>
</asp:Content>
