// Sample Insert, Update, View, Delete 


    void InsertCustomer() //Insert customer record into the database
    {
        //Initialize SQL Connection using static GetCon Class
        //Get SQL Server database path, database name, user, password
        using (SqlConnection con = new SqlConnection(Helper.GetCon()))
        //Initilize cmd variable as a SqlCommand()
        using (SqlCommand cmd = new SqlCommand())
        {
            //Open connection
            con.Open();
            //Use the initialize SQL Connection from the first line as the 
            //SQL connection for the current SqlCommand and for the rest of the
            //code block
            cmd.Connection = con;
            //SQL Query
            //INSERT INTO [Table Name] ([TableColumn1, TableColumn2,])
            //VALUES ([Parameter1], [Parameter2], [Parameter3])
            cmd.CommandText = "INSERT INTO Users (FirstName, LastName, TelNo, Address)" +
                "VALUES (@FirstName, @LastName, @TelNo, @Address)";
            //Assign SQL paramter to the ASPX front end data input field
            //Which for this example is the "txtFirstName.Text"
            //txtFirstName.Text means read the text value entered in the
            //Textbox with the ID of "txtFirstName"
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@TelNo", txtTelNo.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            //Execute a non query commdn, non query commands are those
            //that doesnt output records. For example
            //Viewing a record, reading a record or listing records on a table
            cmd.ExecuteNonQuery();
            //Redirect to an ASPX page after a successfull INSERT
            Response.Redirect("InsertCustomer.aspx");
        }
    }

    void ViewCustomer() //Get one specific customer record from the database
    {
        using (SqlConnection con = new SqlConnection(Helper.GetCon()))
        using (SqlCommand cmd = new SqlCommand())
        {
            con.Open();
            cmd.Connection = con;
            //SELECT [TableColumn1], [TableColumn2]
            //WHERE means filter the particular records on a table, for this example
            //We are filtering the table where a customer has the particular ID
            //WHERE ID=@ID
            cmd.CommandText = "SELECT FirstName, LastName, TelNo, Address " +
                "FROM Users WHERE ID=@ID";
            //Assign the parameter @ID to a textbox so we can
            //enter what ID to filter
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            //Initialize a SqlDataReader by assigning it to the variable data
            using (SqlDataReader data = cmd.ExecuteReader()) 
            {
                //If the particular ExecuteReader has Rows/Records in it
                if (data.hasRows) 
                {
                    //While reading the data inside the filtered records
                    //We assign the records to the textboxes
                    //on the left side, and to the right is we are 
                    //Converting the data["FirstName"] records to a string
                    //ToString(); so that it can be displayed
                    //in the txtFirstName textboxes
                    while (data.Read()) 
                    {
                        txtFirstName.Text = data["FirstName"].ToString();
                        txtLastName.Text = data["LastName"].ToString();
                        txtTelNo.Text = data["TelNo"].ToString();
                        txtAddress.Text = data["Address"].ToString();
                    }
                }
                //If there are no records from the resulting query
                else 
                {
                    Response.Redirect("ViewCustomer.aspx");
                }
            }
            
        }
    }

    void ViewCustomers() //List customer records from the database in a table
    {
        using (SqlCommand con = new SqlConnection(Helper.GetCon()))
        using (SqlCommand cmd = new SqlCommand())
        {
            con.Open();
            cmd.Connection = con;
            //Select all records from the table Customers
            cmd.CommandText = "SELECT * FROM Customers";
            //Initialize a SqlDataAdapter to a variable named da
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Initialize a new dataset to a variable named ds
            Dataset ds = new Dataset();
            //We fill the resulting records from SqlDataAdapter
            //To the Dataset (ds) we just initialized
            da.Fill(ds, "Customers");
            //We then assigned the ListView in our ASPX with an id of
            //lvCustomers the dataset ds
            //Which we previousl just filled with the resulting records
            lvCustomers.DataSource = ds;
            //We bind the data in the listview
            lvCustomers.DataBind();
        }
    }

    void UpdateCustomer() //Update a customers record
    {
        using (SqlConnection con = new SqlConnection(Helper.GetCon()))
        using (SqlCommand cmd = new SqlCommand()) 
        {
            con.Open();
            cmd.Connection = con;
            //Update [TableName] SET [TableColumn1]=[Parameter1],
            //[TableColumn2]=[Parameter2] WHERE
            //[TableColumn]=[Parameter]
            //We first set the list of column from the table and assign
            //it to its individual parameters as seen below denoted by
            //the @ before the name
            cmd.CommandText = "UPDATE Customers SET FirstName=@FirstName, " +
                "LastName=@LastName, TelNo=@TelNo, Address=@Address " + 
                "WHERE ID=@ID";
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@TelNo", txtTelNo.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.ExecuteNonQuery;
            Response.Redirect("ViewCustomer.aspx");
        }
    }


    void DeleteCustomer() //Delete a customer record
    {
        using (SqlConnection con = new SqlConnection(Helper.GetCon()))
        using (SqlCommand cmd = new SqlCommand()) 
        {
            con.Open();
            cmd.Connection = con;
            //Delete all records resulting from the WHERE
            //filter criteria denoted by the 
            //WHERE [TableColumn]=[Parameter]
            cmd.CommandText = "DELETE * FROM Customers WHERE ID=@ID";
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            cmd.ExecuteNonQuery;
            Response.Redirect("ViewCustomer.aspx");
        }
    }

