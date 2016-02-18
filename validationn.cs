// Name validator
<asp:RegularExpressionValidator ID="nmVld" runat="server"
     ForeColor="red"
     display="Dynamic"
     ControlToValidate="txtName"
     ValidationExpression="^[a-zA-Z'.\s]{1,50}"
     Text="Enter a valid name" />

// Date validator
<asp:RegularExpressionValidator ID="bdayVld" runat="server"
     ForeColor="red"
     display="Dynamic"
     ControlToValidate="txtBday"
     ErrorMessage="Please Enter a valid date in the format (mm/dd/yyyy)"
     ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$" />

// Email validator
<asp:RegularExpressionValidator ID="emlVld" runat="server"
     ForeColor="red"
     Display="Dynamic"
     ControlToValidate="txtEmail"
     ErrorMessage="Please enter valid e-mail address"
     ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$" />

// 7 Digit phone validator
<asp:RegularExpressionValidator ID="PhnVld" runat="server"
    ForeColor="Red"
    Display="Dynamic"
    ControlToValidate="txtPhone"
    ValidationExpression="^[0-9]{7}$"
    ErrorMessage="Enter a valid Phone Number" />

// 11 Digit mobile validator
<asp:RegularExpressionValidator ID="MblVld" runat="server"
    ForeColor="Red"
    Display="Dynamic"
    ControlToValidate="txtMobile"
    ValidationExpression="^[0-9]{11}$"
    ErrorMessage="Enter a valid Mobile Number" />

// Municipality ValidationExpression
<asp:RegularExpressionValidator ID="MncpltyVld" runat="server"
    ForeColor="Red"
    Display="Dynamic"
    ControlToValidate="txtMunicipality"
    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
    Text="Enter a valid Municipality" />

// City ValidationExpression
<asp:RegularExpressionValidator ID="CtyVld" runat="server"
    ForeColor="Red"
    Display="Dynamic"
    ControlToValidate="txtCity"
    ValidationExpression="^[a-zA-Z'.\s]{1,50}"
    Text="Enter a valid City" />

// Validate with onClientClick step
OnClientClick="return validate()"
<script type="text/javascript" language="javascript">
    function validate() {
        if (Page_ClientValidate())
            return confirm('Are you sure?');
    }
</script>
