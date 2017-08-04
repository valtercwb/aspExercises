Public Class Ado{
//new table
DataTable customer = new DataTable("Customer");
//new column
DataColumn keyField = new DataColumn("ID", typeof(long));
customer.Columns.Add(keyField);
//eg
customer.Columns.Add("ID", typeof(long));
customer.Columns.Add("FullName", typeof(string));
customer.Columns.Add("LastOrderDate", typeof(DateTime));

// ----- Use ID for the primary key.
customer.PrimaryKey = new DataColumn[] {customer.Columns["ID"]};

//create Row
DataRow oneRow = someTable.NewRow();

//setting values to rows
oneRow.Item["ID"] = 123; // by column name
oneRow.Item[0] = 123; // by column position
DataColumn whichColumn = someTable.Columns[0];
oneRow.Item[whichColumn] = 123; // by column instance
//omit item call eg: oneRow.Item[]
oneRow["ID"] = 123;

//Ordering data
orderData["Subtotal"] = orderRecord.PreTaxTotal;
orderData["SalesTax"] = orderRecord.PreTaxTotal * orderRecord.TaxRate;
orderData["Total"] = orderData["Subtotal"] + orderData["SalesTax"];

// --- Assumes column 0 is numeric, 1 is string.
someTable.Rows.Add(new Object[] {123, "Fred"});

//test field values in C# using the DBNull.Value.Equals method
if (oneRow.IsNull("Comments"))...

//Storing Rows in a Table
someTable.Rows.Add(oneRow);

someTable.Rows.Remove(oneRow); // Removes row immediately
oneRow.Delete(); // Marks row for removal during approval

//Removing Data
someTable.Rows.Remove(oneRow);

//removes a row, but you pass it the index
someTable.Rows.RemoveAt(0);

//get row index 
int rowPosition = someTable.Rows.IndexOf(oneRow);

//inset a row in index eg:(row,index) 
someTable.Rows.InsertAt(oneRow, 0);

//To remove all rows from a table at once
someTable.Rows.Clear();


//Accept changes will commit your changes 
someTable.AcceptChanges();

//Row States

DataRowState = Detached The default state for any row that has not yet been added
to a DataTable.

DataRowState.Added This is the state for rows added to a table when changes to
the table have not yet been confirmed. If you use the RejectChanges method on the
table, any added rows will be removed immediately.

DataRowState.Unchanged The default state for any row that already appears in a
table, but has not been changed since the last call to AcceptChanges. New rows created
with the NewRow method use this state.

DataRowState.Deleted Deleted rows aren’t actually removed from the table until
you call AcceptChanges. Instead, they are marked for deletion with this state setting.
See the following discussion for the difference between “deleted” and “removed” rows.

DataRowState.Modified Any row that has had its fields changed in any way is
marked as modified.

//Charpter 4
//Finding a Row by Primary Key:if found return the value else return null
//if there's row key return exception
// ----- Single-part key.

//By default, the DataTable.Select method returns DataRow objects

DataRow matchingRow = someTable.Rows.Find(searchValue);

//Select method a string that contains the selection criteria. When successful, the
//method returns an array of matching DataRow instances from the table.
//Select method uses a SQL-like syntax to build a Boolean statement
//You can string together multiple criteria using the Boolean operators AND, OR, and NOT, and
//use parentheses to force evaluation in a specific order.
//Age >= 18 AND (InSchool = True OR LivingAtHome = True)
//Filters
/* 
Column names  
<, >, <=, >=, <>, = 
IN             -   Match from a collection of comma-delimited elements.BillDenomination IN (5, 10, 20)
LIKE           -   ProductClass = 'AA*' or: ProductClass = 'AA%'
AND, OR, NOT
Parentheses    -   force order of the expression
Literals       -   integers, decimals, numbers in scientific notation,strings in single quotes, and dates or times in # marks
CONVERT        -   converts one data type to another
LEN            -   Returns the length of a string column or expression.
ISNULL
IIF            -   Equivalent to :?  -  If the first argument evaluates to true, the function
returns the second argument, the “true” part. Otherwise, it
returns the third argument, the “false” part.Eg:   IIF(Age >= 18, 'Adult', 'Minor')

TRIM Trims whitespace from the ends of a string column or expression.
SUBSTRING Returns a portion of a string column or expression, starting from a
SUBSTRING(PhoneNumber, 1, 3)
*/
DataRow[] matchingRows = someTable.Select(filterCriteria);

//Sorting Search Results
DataRow[] sortedRows = someTable.Select(filterCriteria, sortRules);
//Select method ignores character casing by default
//To enforce case-sensitive matches on all searches instead, set the table’s CaseSensitive property.
someTable.CaseSensitive = true;

//Charpter 5- DATASET

DataSet someSet = new DataSet("SetName");
someSet.Tables.Add(someTable);
//You can also pass a string to the Add method, which creates a new named table object without columns or rows.

// The following code joins a Customer table with an Order table, linking the Customer.ID column as the parent
//with the related Order.CustomerID column as the child:
DataSet orderTracking = new DataSet("OrderTracking");
orderTracking.Tables.Add(customerTable);
orderTracking.Tables.Add(orderTable);
DataRelation customerOrder = new DataRelation("CustomerOrder",
customerTable.Columns["ID"], orderTable.Columns["CustomerID"]);
orderTracking.Relations.Add(customerOrder);

//Locating Parent and Child Records
//getparent
DataRow customer = whichOrder.GetParentRow("CustomerOrder");
//getchild
DataRow[] orders = whichCustomer.GetChildRows("CustomerOrder");

//Charpter 6 Aggregating Data

//functions  x(column-name)
/*
Sum 
Calculates the total of a set of column values. The column being summed must
be numeric, either integral or decimal.
Avg 
Returns the average for a set of numbers in a column. This function also requires
a numeric column.
Min 
Indicates the minimum value found within a set of column values. Numbers,
strings, dates, and other types of data that can be placed in order are all valid for the
target column.
 Max 
 Like Min, but returns the largest value from the available column values. As with
the Min function, most column types will work.
 Count 
 Simply counts the number of rows included in the aggregation. You can pass
any type of column to this function. As long as a row includes a non-NULL value in that
column, it will be counted as 1.
 StDev 
 Determines the statistical standard deviation for a set of values, a common
measure of variability within such a set. The indicated column must be numeric.
Var Calculates the statistical variance for a set of numbers, another measurement
*/
//functions in use:
        DataTable sports = new DataTable("Sports");

            sports.Columns.Add("SportName", typeof(string));
            sports.Columns.Add("TeamPlayers", typeof(decimal));
            sports.Columns.Add("AveragePlayers", typeof(decimal), "Avg(TeamPlayers)");
            sports.Columns.Add("SumPlayers", typeof(decimal), "Sum(TeamPlayers)");
            sports.Columns.Add("MinPlayers", typeof(decimal), "Min(TeamPlayers)");
            sports.Columns.Add("MaxPlayers", typeof(decimal), "Max(TeamPlayers)");
            sports.Columns.Add("CountPlayers", typeof(decimal), "Count(TeamPlayers)");
            sports.Columns.Add("StDevPlayers", typeof(decimal), "StDev(TeamPlayers)");
            sports.Rows.Add(new Object[] { "Baseball", 9 });
            sports.Rows.Add(new Object[] { "Basketball", 5 });
            sports.Rows.Add(new Object[] { "Cricket", 11 });
            sports.Rows.Add(new Object[] { "Football", 45 });
            sports.Rows.Add(new Object[] { "Soccer", 51 });
            sports.Rows.Add(new Object[] { "Volleyball", 151 });
            sports.Rows.Add(new Object[] { "Bowling", 93 });
            sports.Rows.Add(new Object[] { "Skate", 75 });
            sports.Rows.Add(new Object[] { "Snowboard", 61 });

//Related tables column function

 // ----- Build the parent table and add some data.
            DataTable customers = new DataTable("Customer");
            customers.Columns.Add("ID", typeof(int));
            customers.Columns.Add("Name", typeof(string));
            customers.Rows.Add(new Object[] { 1, "Coho Winery" });
            customers.Rows.Add(new Object[] { 2, "Fourth Coffee" });
            // ----- Build the child table and add some data. The "Total"
            // expression column adds sales tax to the subtotal.
            DataTable orders = new DataTable("Order");
            orders.Columns.Add("ID", typeof(int));
            orders.Columns.Add("Customer", typeof(int));
            orders.Columns.Add("Subtotal", typeof(decimal));
            orders.Columns.Add("TaxRate", typeof(decimal));
            orders.Columns.Add("Total", typeof(decimal), "Subtotal * (1 + TaxRate)");
            // ----- Two sample orders for customer 1, 1 for customer 2.
            orders.Rows.Add(new Object[] { 1, 1, 35.24, 0.0875 }); // Total = $38.32
            orders.Rows.Add(new Object[] { 2, 1, 56.21, 0.0875 }); // Total = $61.13
            orders.Rows.Add(new Object[] { 3, 2, 14.94, 0.0925 }); // Total = $16.32
            // ----- Link the tables within a DataSet.
            DataSet business = new DataSet();
            business.Tables.Add(customers);
            business.Tables.Add(orders);
            
            business.Relations.Add(customers.Columns["ID"], orders.Columns["Customer"]);
            // ----- Here is the aggregate expression column.
            customers.Columns.Add("OrderTotals", typeof(decimal), "Sum(Child.Total)");
            // ----- Display each customer's order total.
            foreach (DataRow scanCustomer in customers.Rows)
            {
                Console.WriteLine((string)scanCustomer["Name"] + ": " +
                string.Format("{0:c}", (decimal)scanCustomer["OrderTotals"]));
            }



DataTable employees = new DataTable("Employee");
employees.Columns.Add("ID", typeof(int));
employees.Columns.Add("Gender", typeof(string));
employees.Columns.Add("FullName", typeof(string));
employees.Columns.Add("Salary", typeof(decimal));
// ----- Add employee data to table, then...
decimal averageSalary = (decimal)employees.Compute("Avg(Salary)", "");
 
 int femalesInCompany = (int)employees.Compute("Count(ID)",
"Gender = 'F'");


// dataview create a table based on a table previously created
DataView someView = new DataView(table, filter-string, sort-string, rowState);

DataView playerView = new DataView(teamPlayers);
playerView.RowFilter = "LastActiveYear = " + DateTime.Today.Year;
DataTable currentTeam = playerView.ToTable(true,
new string[] {"JerseyNumber", "PlayerName", "Position"});

//Saving and Restoring Data
/*generating XML content from a DataSet takes
very little effort. Reading XML content into a DataSet is even easier because ADO.NET will
guess at the correct structure of the data even if you don’t provide table design guidance */
// generate xml
DataSet infoSet = new DataSet();
// ----- Add tables, relations, and data, then call...
infoSet.WriteXml(@"c:\StorageFile.xml");
//To include the DataSet object’s schema definition along with the data, add a second argument
infoSet.WriteXml(targetFile, XmlWriteMode.WriteSchema);

// ----- Write the customer data AND the linked order data.
customers.WriteXml(targetFile, true);

//Read xml
DataSet infoSet = new DataSet();
// ----- To read the schema, use...
infoSet.ReadXmlSchema(@"c:\StorageSchemaFile.xml");
// ----- To read the data, use...
infoSet.ReadXml(@"c:\StorageFile.xml");
//set the namespace for a table to generate it when creating a xml  eg: new DataTable("tablename", "namespace");
DataTable customers = new DataTable("Customer", "corporate");


//Connecting to external Data Sources
//connection string builder
SqlClient.SqlConnectionStringBuilder builder =
new SqlClient.SqlConnectionStringBuilder();
builder.DataSource = @"(local)\SQLEXPRESS";
builder.InitialCatalog = "StepSample";
builder.IntegratedSecurity = true;
return builder.ConnectionString;

//To simplify the process, employ a using/Using block to automatically dispose of the connection object.

using (SqlConnection linkToDB =
new SqlConnection(builder.ConnectionString))
{
linkToDB.Open();
// ----- Additional code here.
}

//Querying data
/* The ExecuteNonQuery method is synchronous; your application will block until the database
operation completes successfully or aborts with an error or connection timeout.

The command object also supports asynchronous processing of nonqueries. It includes a pair
of methods—BeginExecuteNonQuery and EndExecuteNonQuery—that bracket the operation.
*/

SqlCommand dataAction = new SqlCommand(sqlText, linkToDB);
IAsyncResult pending = dataAction.BeginExecuteNonQuery();
while (pending.IsCompleted == false)
{
// ----- Do work as needed, or...
Threading.Thread.Sleep(100);
}
dataAction.EndExecuteNonQuery(pending);


/*A variation of the BeginExecuteNonQuery method lets you specify a callback method and an
optional object that will be passed to the callback method when the operation completes.
You must still call EndExecuteNonQuery, although you can call it from within the callback
code. Passing the SqlCommand object as the optional argument simplifies this process */

SqlCommand dataAction = new SqlCommand(sqlText, linkToDB);
AsyncCallback callback = new AsyncCallback(WhenFinished);
dataAction.BeginExecuteNonQuery(callback, dataAction);
// ----- Elsewhere...
private void WhenFinished(IAsyncResult e)
{
// ----- The IAsyncResult.AsyncState property contains the
// optional object sent in by BeginExecuteNonQuery.
SqlCommand dataAction = (SqlCommand)e.AsyncState;
// ----- Finish processing.
dataAction.EndExecuteNonQuery(e);
}

//Scalar - This method is useful with SELECT queries that return a simple result
string sqlText = "SELECT COUNT(*) FROM WorkTable";
SqlCommand dataAction = new SqlCommand(sqlText, linkToDB);
int totalItems = (int)dataAction.ExecuteScalar();


//OUTPUT keyword on INSERT statements that returns
//a specified field (typically the primary key) from the newly inserted data row

// ----- Pretend the ...'s represent actual fields, and that
// WorkTable.ID is the name of the primary key.
string sqlText = @"INSERT INTO WorkTable (...)
OUTPUT INSERTED.ID VALUES (...)";
SqlCommand dataAction = new SqlCommand(sqlText, linkToDB);
int newID = (int)dataAction.ExecuteScalar();

//ExecuteReader.This method returns an object
/*SqlDataReader exposes exactly one data row at a time as a collection of column values. The
reader returned by ExecuteReader doesn’t yet point to a data row. You must call the reader’s
Read method to access the first row, calling it again for subsequent rows. Read returns False
when there are no more rows available. The HasRows property indicates whether any rows
were returned from the query.
C#*/
SqlDataReader scanCustomer = dataAction.ExecuteReader();
if (scanCustomer.HasRows)
while (scanCustomer.Read())
{
// ----- Perform row processing here.
}
scanCustomer.Close();
//Always call the reader’s Close or Dispose method when finished.

//Accessing Field Values
rowID = scanCustomer.GetInt64(scanCustomer.GetOrdinal("ID"));

//getsqlX are just like .Net types but they accept null values as well.
GetSqlBinary, GetSqlBoolean, GetSqlByte, GetSqlBytes, GetSqlChars, GetSqlDateTime,
GetSqlDecimal, GetSqlDouble, GetSqlGuid, GetSqlInt16, GetSqlInt32, GetSqlInt64, GetSqlMoney,
GetSqlSingle, GetSqlString, and GetSqlXml

//Query with parameters
string sqlText = @"UPDATE Employee SET Salary = ? WHERE ID = ?";
SqlCommand salaryUpdate = new SqlCommand(sqlText, linkToDB);
salaryUpdate.Parameters.AddWithValue("@NewSalary", 50000m);
salaryUpdate.Parameters.AddWithValue("@EmployeeID", 25L);

CREATE PROCEDURE AddLocation (@locationName varchar(50), @newID bigint OUT)
AS
BEGIN
INSERT INTO BuildingLocation (Name) VALUES (@locationName);
SET @newID = SCOPE_IDENTITY();
RETURN @@ROWCOUNT;
END

/ ----- Use a stored procedure to add a new building location.
string sqlText = "dbo.AddLocation";
SqlCommand locationCommand = new SqlCommand(sqlText, linkToDB);
locationCommand.CommandType = CommandType.StoredProcedure;
// ----- Add the input parameter: locationName.
SqlParameter workParameter = locationCommand.Parameters.AddWithValue(
"@locationName", LocationNameField.Text.Trim());
workParameter.Size = 50;
// ----- Add the output parameter: newID.
workParameter = locationCommand.Parameters.Add("@newID", SqlDbType.BigInt);
workParameter.Direction = ParameterDirection.Output;
// ----- Add the return value parameter. The name is not important.
workParameter = locationCommand.Parameters.Add("@returnValue", SqlDbType.Int);
workParameter.Direction = ParameterDirection.ReturnValue;
// ----- Add the location.
locationCommand.ExecuteNonQuery();
// ----- Access returned values as:
// locationCommand.Parameters["@newID"].Value
// locationCommand.Parameters["@returnValue"].Value

//Understanding Data Adapters

//Moving Data into a DataTable

DataTable targetTable = new DataTable();
SqlDataAdapter workAdapter = new SqlDataAdapter(
"SELECT * FROM Customer ORDER BY LastName", connectionString);
workAdapter.Fill(targetTable);

//
DataTable targetTable = new DataTable();
using (SqlConnection linkToDB = new SqlConnection(connectionString))
{
SqlDataAdapter workAdapter = new SqlDataAdapter();
workAdapter.SelectCommand = new SqlCommand(
"SELECT * FROM Customer ORDER BY LastName", linkToDB);
workAdapter.Fill(targetTable);
}
Visual Basic

// ----- Call the GetCustomerOrders stored procedure with a
// single 'customer ID' argument.
string sqlText = "dbo.GetOrdersForCustomer";
SqlCommand commandWrapper = new SqlCommand(sqlText, linkToDB);
commandWrapper.CommandType = CommandType.StoredProcedure;
commandWrapper.Parameters.AddWithValue("@customerID", ActiveCustomerID);
// ----- Retrieve the data.
SqlDataAdapter workAdapter = new SqlDataAdapter(commandWrapper);
DataTable orders = new DataTable();
workAdapter.Fill(orders);

//Filling a dataset
DataSet targetSet = new DataSet();
SqlDataAdapter workAdapter = new SqlDataAdapter(
"SELECT * FROM Customer ORDER BY LastName", connectionString);
workAdapter.Fill(targetSet);

}
