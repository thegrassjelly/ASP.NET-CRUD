// Name validator
<asp:RegularExpressionValidator ID="nmVld" runat="server"
     ForeColor="red"
     display="Dynamic"
     ControlToValidate="txtName"
     ValidationExpression="^[a-zA-Z'.\s]{1,50}"
     Text="Enter a valid name" />

// Date validator
<asp:TextBox ID="txtBday" class="form-control" runat="server" TextMode="date" />
<asp:RangeValidator ID="bdayVld" runat="server"
    Display="Dynamic"
    ForeColor="Red"
    ControlToValidate="txtBday"
    ErrorMessage="Choose a valid date"
    MaximumValue="2017-01-01"
    MinimumValue="1900-01-01" />
// Data reading
DateTime someDate = Convert.ToDateTime(data["Date"].ToString());
txtBday.Text = someDate.ToString("yyyy-MM-dd");

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

// Enter key submit
this.Form.DefaultButton = this.btnAdd.UniqueID;

//Global variables
//Step 1: Declare in webconfig
<appSetting>
     <add key="username" value="someusername123"
</appSetting>

//Step 2: AppCode/Helper.pcs
public static string username = ConfigurationManager.AppSettings["username"].ToString();

//Step 3: Call in .cs
Helper.username
