# Nile (ITSE 1430)
## Version 1.0

In this lab you will modify an existing product inventory application to support a SQL Server database and make some other enhancements.

*Note: As with most maintenance work you must follow the existing styling and naming conventions. DO NOT change the existing styling/naming rules. ENSURE your code matches the rules being used.*

## Skills Needed

- C#
   - Abstract Classes
   - Exceptions and try-catch
   - Interfaces
- ADO.NET
  - SQL types including SqlConnection and SqlCommand   
  - Reading and Writing Data using ADO.NET

## Story 1

Add an About box.

The existing program does not have an About box. Add one that contains the class, semester and your name.

- Update the menu to contain a `Help\About` menu.
- Set the menu item shortcut key to `F1`.
- Add the About form.
- Hook up the menu to show the form.

### Acceptance Criteria

- Menu item is available.
- Clicking menu item shows About form.

## Story 2

Add support for validating a `Product` instance.

Currently the UI does the validation at the control level. Update the `Product` class to support validation using `IValidatableObject`.

- `Id` must be greater than or equal to 0.
- `Name` is required and cannot be empty.
- `Price` must be greater than or equal to 0.

Update the various locations in the code that expects validation. You can use the `TODO` comments to find these locations (`Validate product`).

- In the UI when trying to save a product.
- In the product database when trying to add a product.
- In the product database when trying to update a product.

### Acceptance Criteria

- The product is validated before saving in the UI.
- The product is validated before adding to the database.
- The product is validated before updating in the database.

## Story 3

Report errors for invalid arguments.

Update the code to throw the appropriate exception when invalid arguments are provided. You can use the 'TODO' comments to find these locations (`Check arguments`).

- Reference types should not be `null`.
- Integral types should be within the expected range.
- `IValidatableObject` implementations should validate.
- For product updates the product being updated must exist.

### Acceptance Criteria

- Cannot add a product to database that is `null` or invalid.
- Cannot update a product in database to `null` or invalid.
- Cannot update a product in database for non-existent product.
- Cannot retrieve a product using an invalid ID.

## Story 4

Handle errors from database.

The UI should not crash if errors occur while interacting with the database. You can use the `TODO` comments to find these locations (`Handle errors`).

- Report an error if the products cannot be retrieved from the database.
- Report an error if a product cannot be added, updated or deleted.

## Story 5

Do not allow duplicate products.

Update the database class to prevent adding a product with the same name as one that already exists. If the product already exists then throw an exception.

Update the database class to prevent updating a product to a new name that already exists. If an existing product already exists then throw an exception. Note that it is valid to update a product to the same name it already has.

### Acceptance Criteria

- Attempting to add a product with the same name as one that already exists fails.
- Attempting to update a product to a new name that already exists fails.
- Attempting to update a product using its same name works.

## Story 6

Add support for storing products in a SQL database.

The solution is currently using an in-memory data store for products. Modify the application to use a SQL database instead.

- Create a new class library called `Nile.Stores.Sql` to store the SQL Server implementation.
- Create a new class to implement the `IProductDatabase` interface using SQL Server. *Note: You can use the existing `ProductDatabase` abstract class to speed this up.* 
- The class will need the connection string to the database. Create a constructor that accepts this.
- Update the main form to use an instance of this class instead of the existing memory database.

### Notes

- The solution already contains the SQL database. When you build and run the application the first time it should deploy the database. You can confirm this by using `SQL Server Object Explorer`.  The database should show up under `(localdb)\ProjectsV13` (or whatever version of LocalDB you have installed). If it does not appear then set the database project as the startup project and run the debugger (`F5`). This will trigger the deployment.
- To connect to the database you will need a connection string. The connection string is stored in the `appsettings.json` file. It should already be properly set up for LocalDB. If your installation of Visual Studio is using a different database name then you will need to adjust the connection string in the settings file.
- The SQL database class will not have access to the settings file so ensure it accepts the connection string in the constructor.
- The helper method `GetConnectionString` has been provided in `MainForm` to return the connection string for a database. The appsettings file is using the name `ProductDatabase`. Call this method to get the connection string to use.

### Stored Procedures

The following stored procedures are provided and should be used to work with the database.

#### Adding a Product

Procedure: `AddProduct`
Returns: The ID of the new product as an `int`.
Parameters:

| Parameter | Type | Description |
| - | - | - |
| `@name` | `string` | Name of the product. |
| `@price` | `decimal` | Price of the product. |
| `@description` | `string` | Optional description of the product. |
| `@isDiscontinued` | `bool` | Indicates if the product is discontinued. |

#### Delete a Product

Procedure: `RemoveProduct`
Returns: None.
Parameters:

| Parameter | Type | Description |
| - | - | - |
| `@id` | `int` | ID of the product. |

#### Get All Products

Procedure: `GetAllProducts`
Returns: List of products.

| Column | Type | Description |
| - | - | - |
| `id` | `int` | ID of the product. |
| `name` | `string` | Name of the product. |
| `price` | `decimal` | Price of the product. |
| `description` | `string` | Optional description of the product. |
| `isDiscontinued` | `bool` | Indicates if the product is discontinued. |

#### Get A Products

Procedure: `GetProduct`
Returns: The matching product, if any.

| Column | Type | Description |
| - | - | - |
| `id` | `int` | ID of the product. |
| `name` | `string` | Name of the product. |
| `price` | `decimal` | Price of the product. |
| `description` | `string` | Optional description of the product. |
| `isDiscontinued` | `bool` | Indicates if the product is discontinued. |
 
Parameters: 

| Parameter | Type | Description |
| - | - | - |
| `@id` | `int` | ID of the product. |

#### Update a Product

Procedure: `UpdateProduct`
Returns: None.
Parameters:

| Parameter | Type | Description |
| - | - | - |
| `@id` | `int` | ID of the product. |
| `@name` | `string` | Name of the product. |
| `@price` | `decimal` | Price of the product. |
| `@description` | `string` | Optional description of the product. |
| `@isDiscontinued` | `bool` | Indicates if the product is discontinued. |

### Acceptance Criteria

- When the application runs products are retrieved from the SQL database.
- User can add, edit and remove products and the database is updated correctly.
- The connection string IS NOT hard coded in the application code anywhere.

## Story 7

Sort products by name.

The UI displays the products in the order they are returned by the database. Sort the returned products so they appear alphabetical.

### Acceptance Criteria

- Products appear in the UI alphabetically, irrelevant of the order they are returned by the database.

## DataGridView

This project uses [DataGridView](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview?view=netframework-4.8) to show products. This is data control that allows you to show rows of data like a spreadsheet with optional editing ability. For this lab you do not need to adjust the grid but you may be interested in seeing how it works.

### Columns and Rows

A `DataGridView` starts out empty except for a list of `Columns` defined by [DataGridColumn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewcolumn?view=netframework-4.8). A column defines the header, type of data being shown and various editing and styling properties. By default `DataGridView` will automatically generate columns based upon the data being set on the grid but you can, and often do, disable this. Columns are typed so that the proper edit control can be shown if needed. For example there is `DataGridViewCheckBoxColumn` for checkboxes, `DataGridViewButtonColumn` for buttons and `DataGridViewTextBoxColumn` for general text.

A `DataGridView` has zero or more `Rows` defined by [DataGridViewRow](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewrow?view=netframework-4.8) rows (including a header, footer and data rows) where each row has one or more [DataGridColumn](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewcolumn?view=netframework-4.8). A row may be a header, footer or data row. A data row is created for each item that is bound to the `DataGridView`.

A `DataGridViewRow` has zero or more `Cells` defined by [DataGridViewCell](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridviewcell?view=netframework-4.8). Like columns these are generally derived types based upon the corresponding column. Each column has a cell in the row. It is in the cell where the data is stored for that row.

### Binding Data

Like other data controls rows can be added to the grid programmatically but normally you will bind the data using [BindingSource](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.bindingsource?view=netframework-4.8). `BindingSource` is what opens up the ability to add/edit/delete items without writing a lot of code. The `BindingSource` component is a wrapper around an existing list of items and it determines what can be done based upon the configuration. In most cases the `BindingSource` instance is created in the designer and associated with a business object. The `BindingSource` then evaluates the type and determines what is available.

To change the data being bound code need only set the `DataSource` property on the `BindingSource` and any connected UI elements will refresh automatically. In order for a change to be detected the ssigned value must be a different value than what is currently bound otherwise it is ignored. That means that if you're reusing an object (e.g. `List<T>`) then you must first change `DataSource` to something else (e.g. `null`) and then back for the changes to be recognized.

```csharp
myBindingSource.DataSource = null; //Only needed if myNewData is not changing
myBindingSource.DataSource = myNewData;
```

Unlike other data controls `DataGridView` is really just a UI wrapper around the underlying data. All interactions with the grid ultimately impact the underlying stored data.

### Selection

`DataGridView` supports selecting single or multiple columns and/or rows. `SelectedRows` contains the selected rows while `SelectedColumns` contains the selected columns. In the case of rows the `DataBoundItem` contains the underlying item (from `BindingSource`) that is associated with that row, if any.

```csharp
//Get selected item - only 1
var data = myGrid.SelectedRows[0].DataBoundItem as MyData;
```

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in Canvas by providing the link to the Github repository.