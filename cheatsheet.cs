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

//jQuery autocomplete (City for instance)
//Step 1: JS
    <script type='text/javascript' src='<%= Page.ResolveUrl("~/js/newjs/jquery.min.js") %>'></script>
    <script type='text/javascript' src='<%= Page.ResolveUrl("~/js/newjs/jquery-ui.min.js") %>'></script>
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });

        function SearchText() {
            $(".autosuggest").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Profile.aspx/SearchCity",
                        data: "{'prefixText':'" + document.getElementById('<%=txtCity.ClientID%>').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("Error" + result.result);
                            }
                        });
                    }
                });
            }
    </script>

//Step 2: Asign class to textbox (.autosuggest)
//Step 3: CS
    [WebMethod]
    public static List<string> SearchCity(string prefixText)
    {
        List<string> cities = new List<string>();
        using (SqlConnection con = new SqlConnection(Helper.GetCon()))
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT Name FROM Cities WHERE " +
                    "Name LIKE @SearchText + '%'";
            cmd.Parameters.AddWithValue("@SearchText", prefixText);
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    cities.Add(dr["Name"].ToString());
                }
            }
            con.Close();
        }
        return cities;
    }

//AJAX Password strength
<ajaxToolkit:PasswordStrength ID="ajaxPwd" runat="server" 
    TargetControlID="txtPassword"
    DisplayPosition="BelowRight"
    StrengthIndicatorType="Text"
    PreferredPasswordLength="10"
    PrefixText="Strength: "
    HelpStatusLabelID="TextBox1_HelpLabel"
    TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
    StrengthStyles="TextIndicator_TextBox1_Strength1;TextIndicator_TextBox1_Strength2;TextIndicator_TextBox1_Strength3;TextIndicator_TextBox1_Strength4;TextIndicator_TextBox1_Strength5"
    MinimumNumericCharacters="0"
    MinimumSymbolCharacters="0"
    RequiresUpperAndLowerCaseCharacters="false" />

//Eval ternary operator example
//Evaluate class on active or inactive status
<td>
<button runat="server" type="button"
class='<%# Eval("AmbulanceStatus").ToString() == "Active" ? "btn btn-success btn-xs" : "btn btn-danger btn-xs" %>'>
<%# Eval("AmbulanceStatus") %>
</button>
</td>

//Update panel & update loading screen
<asp:ScriptManager runat="server"></asp:ScriptManager>
<asp:UpdateProgress ID="updateProgress" runat="server">
    <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/ajax-loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
    //Form actions here
    </ContentTemplate>
</asp:UpdatePanel>

//Exception logger
Helper.LogException(Session["userid"].ToString(), "Membership Renewal, Automatic Renewal Mail ",
                            "Exception Type: " + ex.GetType().ToString() + " " +
                            "Exception Message: " + ex.Message.ToString());

//Reports
//ddl
<div class="row">
    <div class="col-lg-8">
        <div class="col-lg-5">
            <div class="form-group">
                <label class="control-label col-lg-4">Initial Date</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtDate1" class="form-control" runat="server" TextMode="Date" required></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-lg-5">
            <div class="form-group">
                <label class="control-label col-lg-4">End Date</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtDate2" class="form-control" runat="server" TextMode="Date" required></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="form-group">
                <div class="col-lg-10">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
//CS
//declare in class
private string name;
private string type;

//Page load
Helper.ValidateAdmin();
if (!IsPostBack)
{
    MinMaxDate();
}
GetReports();

//MinMax
void MinMaxDate()
{
    using (SqlConnection con = new SqlConnection(Helper.GetCon()))
    using (SqlCommand cmd = new SqlCommand())
    {
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "SELECT MIN(DateAdded) AS Min, MAX(DateAdded) As Max  " +
        "FROM Users";
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            dr.Read();
            if (dr.HasRows)
            {
                DateTime DateOne = Convert.ToDateTime(dr["Min"].ToString());
                txtDate1.Text = DateOne.ToString("yyyy-MM-dd");
                DateTime DateTwo = Convert.ToDateTime(dr["Max"].ToString());
                txtDate2.Text = DateTwo.ToString("yyyy-MM-dd");
            }
        }
    }
}

//Get method
void GetReports()
{
    using (SqlConnection con = new SqlConnection(Helper.GetCon()))
    using (SqlCommand cmd = new SqlCommand())
    {
        con.Open();
        cmd.Connection = con;

        cmd.CommandText = "SELECT LastName + ', ' + FirstName AS Name, UserType FROM Users " +
        "INNER JOIN Types ON Users.TypeID=Types.TypeID WHERE UserID=@UserID";
        cmd.Parameters.AddWithValue("@UserID", Session["userid"].ToString());
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
            while (dr.Read())
            {
                name = dr["Name"].ToString();
                type = dr["UserType"].ToString();
            }
        }

        ReportDocument report = new ReportDocument(); 
        report.Load(Server.MapPath("~/Admin/Users/Reports/rptReports.rpt"));

        if (Helper.Secured() != "true")
        report.DataSourceConnections[0].SetConnection(Helper.GetCrServer(), Helper.GetCrDb(), true);
        else
        report.DataSourceConnections[0].SetConnection(Helper.GetCrServer(), Helper.GetCrDb(), Helper.GetCrvUser(), Helper.GetCrvPass());

        report.SetParameterValue("Name", name);
        report.SetParameterValue("UserType", type);
        report.SetParameterValue("Date1", txtDate1.Text);
        report.SetParameterValue("Date2", txtDate2.Text);

        crvReports.ReportSource = report;
        crvReports.DataBind();
    }
}

protected void btnSubmit_Click(object sender, EventArgs e)
{
    GetReports();
}

