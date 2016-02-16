// Name validator
<asp:RegularExpressionValidator ID="nmVld" runat="server"
     display="Dynamic"
     ControlToValidate="txtName"
     ValidationExpression="^[a-zA-Z'.\s]{1,50}"
     Text="Enter a valid name" />

// Date validator
<asp:RegularExpressionValidator ID="bdayVld" runat="server"
     display="Dynamic"
     ControlToValidate="txtBday"
     ErrorMessage="Please Enter a valid date in the format (mm/dd/yyyy)"
     ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$" />

// Email validator
<asp:RegularExpressionValidator ID="emlVld" runat="server"
     Display="Dynamic"
     ErrorMessage="Please enter valid e-mail address"
     ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"
     ControlToValidate="txtEmail" />
