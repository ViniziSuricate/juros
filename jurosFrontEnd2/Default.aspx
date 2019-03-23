<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Teste de cálculo de taxa de juros</title>
    <meta charset="UTF-8">
</head>
<body>
	<form id="form1" runat="server">
       <div style="background-color:lightblue border:1px solid thin" runat="server">
            <br/><asp:label id="lblTop" runat="server"> Testador unitario para API Juros </asp:label>
            <br/>
            <br/><asp:label id="lbl1" runat="server"> Valor para o cálculo: </asp:label>
            <br/><asp:TextBox id="txtValor" name="txtValor" runat="server"></asp:TextBox>
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="txtValor" ErrorMessage="Valor informado não numérico" />
            <br/><asp:label id="lbl2" runat="server"> Meses para o cálculo: </asp:label>
            <br/><asp:TextBox id="txtMeses" name="txtMeses" runat="server"></asp:TextBox>
                 <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Double" ControlToValidate="txtMeses" ErrorMessage="Meses informado não numérico" />
            <br/>
            <br/><asp:Button id="button1" runat="server" Text="Calcular Taxa" OnClick="button1Clicked" />
            <br/>
            <br/><asp:TextBox id="txtResultado" name="txtResultado" runat="server"></asp:TextBox> 
            <br/>
        
       </div> 
       
       <div style="background-color:lightgreen border:1px solid thin" runat="server">
            <br/>
            <br/><asp:Button id="button2" runat="server" Text="Mostrar link Código" OnClick="button2Cliked"/>
            <br/><asp:TextBox id="txtLink" name="txtLink" ReadOnly="true" runat="server"></asp:TextBox>
            <br/>
        </div>
	</form>
</body>
</html>



