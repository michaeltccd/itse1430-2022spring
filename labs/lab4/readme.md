# Character Creator (ITSE 1430)
## Version 3.0

In this lab you will update your Character Creator from the earlier lab to support multiple characters.

## Skills Needed

- Interfaces
- Collections
- LINQ

*Note: Remember that business types belong in the business project and should not have any UI.*

## Story 1 - Create a Character Roster

Define an interface to represents a character roster that the UI can use to work with characters irrelevant of how the data is stored.

### Description

Create a new interface called `ICharacterRoster` to manage a list of characters. It will start out empty.

Ensure the interface and its members are documented as you go along.

### Acceptance Criteria

- Interface is properly defined in the business project.
- Interface is properly documented.
- Code compiles

## Story 2 - Create an In-Memory Roster

Create an in-memory implementation of the interface.

### Description

Create a new class `MemoryCharacterRoster` that implements the earlier interface. The roster will use a `List<Character>` to store the roster entries.

To avoid confusion place the type in the namespace (and folder) `Memory`.

*Note: Be careful when implementing methods on this type. The implementation will be using reference types which means equality and reference semantics apply. This is not how a roster should work. Ensure that any methods that return data return a copy of the data instead to prevent code from accidentally changing the underlying data in the roster.*

### Acceptance Criteria

- Type is properly defined in the business project.
- Type is properly documented.
- Code compiles

## Story 3 - Add Support for Uniquely Identifying a Character

Add a unique identifier to a character so they can be managed in the roster.

### Description

For most of the functionality it will be necessary to uniquely identify a character using something that the user does not provide.
Add an `Id` property to the `Character` class to track this. 
It should be an integral type.
The `Id` property will be managed by the roster it is associated with, or 0 if it is not yet in the roster.

### Acceptance Criteria

- Property is properly added to class and documented.
- Code compiles cleanly.

## Story 4 - Update UI

Update the UI to use the new roster interface.

### Description

The UI will use the new interface to work with the character roster. 
When initializing the roster use the in-memory implementation but be sure the field is of the interface type.

The only reference to the in-memory roster type should be in the `new` expression. A good way to help ensure that is to NOT add a `using` for the `Memory` namespace but instead include it in the only reference to the memory class.

```csharp
ICharacterRoster _roster = new Memory.MemoryCharacterRoster();
```

Leave the existing `_character` field in the form class until all references to it have been removed at the end of the lab.

### Acceptance Criteria

- Field is properly typed as interface.
- Field is properly initialized to in-memory roster.
- Code compiles cleanly.

## Story 5 - Migrate Support for Adding a Character

Migrate the existing UI for adding a character to use the roster.

### Description

This story requires changes in several areas.

#### Interface Changes

Add a new method called `Add` to the interface.
This method will add the given character, if valid, to the roster.
The method should accept a `Character` instance to add.
The method should return a `Character` instance with the identifier set.
It should return any errors that occur, use an `out` parameter for this.

#### Implementation Changes

Implement the `Add` method in the memory roster.

Validate the parameter, set the error message if invalid and return `null`.
The following validation should be done:

- Parameter is not `null`.
- Character is valid as defined by the business rules.
- Character name should be unique in the roster. Remember case does not matter.

If valid then assign the character a unique identifier that can be used to later retrieve the character if needed. Refer to the section [Simple Identifier](#simple-identifier) for an example.

Add the character to the underlying list.
Return the newly added character (or just return the original character with the identifier set).

*Note: Similar functionality will be needed later for `Update` so consider creating some helper methods for the common work.*

#### UI Changes

Update the UI's logic for adding a character to use the new interface member.

1. Replace the references to the original character field with a call to the roster.
1. Be sure to handle any validation errors from the method.
1. If validation fails then display the form again with the original data so the user can correct it.

*Note: At this time the UI will not properly update the main window with the new character.*

### Acceptance Criteria

- Interface is properly documented.
- Character is properly validated including null, validation and unique name.
- Method returns uniquely identified character.
- UI properly adds character to roster.
- Validation errors cause a message to be shown and the user is returned to the edit form.

## Story 6 - Migrate Support for Viewing the Roster

Update the UI to show the roster.

### Description

This story requires changes in several areas.

#### Interface Changes

Add a new method `GetAll` that returns an `IEnumerable<Character>`.
This method returns the characters in the roster. 
Ensure it is properly documented.

*Note: Ensure that the return type is only the interface given, not an array or list. You do not need to define this interface yourself.*

#### Implementation Changes

Implement the `GetAll` method in the memory roster.
The method should return the current roster members.

#### UI Changes

Update the UI to use the new method to retrieve the characters.

To work around a limitation of the `ListBox` use the following code to associate the roster with the control.

```csharp
var binding = new BindingSource();
binding.DataSource = //Your roster's GetAll results

listBox1.DataSource = binding;
listBox1.DisplayMember = nameof(Character.Name);
```

*Note: At this time edit and delete will not work properly.*

### Acceptance Criteria

- When initially loading the main window the roster is empty.
- When adding a character the main window is properly updated.

## Story 7 - Migrate Support for Editing a Character

Update the UI to support editing a character.

### Description

This story requires changes in several areas.

#### Interface Changes

Add a new method called `Update` to the interface.
This method will update an existing character, if valid, in the roster.
The method should accept the unique ID of the character and the `Character` data to update.
It should return any errors that occur.

#### Implementation Changes

Implement the `Update` method in the memory roster.

Validate the parameters and set the error message if invalid.
The following validation should be done:

- Parameter containing the character ID must be greater than zero.
- Parameter containing the character data is not `null`.
- Character ID must already exist in the roster.
- Character is valid as defined by the business rules.
- Character name should be unique in the roster. Remember case does not matter.

*Note: DO NOT use the ID in any provided character data. Only the explicit parameter is used for this.*

If valid then update the existing character in the roster. DO NOT add the character as a new entry.

*Note: When checking for a unique name keep in mind that the character name may not have changed and therefore updating a character with the same name is valid.*

#### UI Changes

Update the UI's logic for editing a character to use the new interface member.

1. Replace the references to the original character field with a call to the roster.
1. Be sure to handle any validation errors from the method.
1. If validation fails then display the form again with the edited data so the user can correct it.
1. Ensure the UI roster updates correctly.

To determine the character to edit retrieve the currently selected character from the UI.
Refer to the section [Getting Selected Item](#getting-selected-item) for more information on how to get the selected character.
If no character is selected then do nothing.

### Acceptance Criteria

- Interface is properly documented.
- Parameters are properly validated including null, validation and unique name.
- Can select and edit all characters in roster.
- ID of the updated character is not changed (e.g. updating character with ID 5 does not change its ID).
- UI properly updates to show changed character.
- Validation errors cause a message to be shown and the user is returned to the edit form.

## Story 8 - Migrate Support for Deleting a Character

Update the UI to support deleting a character.

### Description

This story requires changes in several areas.

#### Interface Changes

Add a new method called `Delete` to the interface.
This method will delete an existing character from the roster.
The method should accept the unique ID of the character to delete.
It should return any errors that occur.

#### Implementation Changes

Implement the `Delete` method in the memory roster.

Validate the parameters and set the error message if invalid.
The following validation should be done:

- Parameter containing the character ID must be greater than zero.

*Note: It is not an error to delete a character that does not exist.*

#### UI Changes

Update the UI's logic for deleting a character to use the new interface member.

1. Replace the references to the original character field with a call to the roster.
1. Get the [selected item](#getting-selected-item) to delete, if any.
1. Continue to display the confirmation as before.
1. Be sure to handle any validation errors from the method.
1. Ensure the UI roster updates correctly.

*Note: There should be no more references to the original character field. It should be removed.*

### Acceptance Criteria

- Interface is properly documented.
- Parameter is properly validated.
- Can select and delete a character from the roster.
- UI properly updates to remove deleted character.
- Validation errors cause a message to be shown.

## Help

### Simple Identifier

To create a simple identifier system do the following.

1. Add an integral field to the type with an initial value of 0.
1. Each time an identifier is needed increment the field by 1 and return the new value.

```csharp
private int _nextId = 0;

// Get the next identifier
data.Id = ++_nextId;
```

### Get Selected Item

To get the selected item from a `ComboBox` or `ListBox` then use the `SelectedItem` property.
It will be an `object` and will need to be converted to the appropriate type.
It can be `null`.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
