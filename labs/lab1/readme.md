# Character Creator (ITSE 1430)
## Version 2.0

In this lab you will build a program to create a character for an adventure game.

## Skills Needed

- C#
  - Control flow statements
  - Functions and parameters
  - Types
  - Variables
- Console read/write

## General Guidelines

### General 

- It is strongly recommended that you complete the stories in order. Some stories rely on the work done in previous stories.
- Commit your changes to Github frequently to ensure you don't lose any work. You do not need to wait for a story to be completed.
- After you implement a story ensure it meets all the acceptance criteria. In some cases a later story may change the behavior of an earlier story.
- After you complete a story you should commit the changes you've made to Github. If something comes up and you are not able to complete the remaining stories you can at least get credit for the work you've done.
- Unless otherwise stated all inputs must be validated to ensure they are of the current type and range as given in the assignment.

### Naming Conventions

- USE descriptive nouns for variable and parameter identifiers (e.g. `payRate`, `name`, `index`).
- USE descriptive verbs for function identifiers (e.g. `GetName`, `ShowProgress`).
- DO NOT use single letters or abbreviations in identifiers (e.g. `x`, `descriptValue`).
- DO ensure spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

### Coding Style

- DO put a file header at the top of each file you create. The file header should contain the class, date and your name.
  ```csharp
  /*
   * Your Name
   * ITSE 1430 
   * Lab 1
   */
  ```
- DO use consistent indentation. In general each block indents one time (3 or 4 spaces). Curly braces should be aligned.
  ```csharp
  //NO
  while (someCondition) 
     { 
    Foo();
	     };
		 
  //YES
  while (someCondition)
  {
     Foo();
  };
  ```
- DO use a single blank line between blocks of code (e.g. functions, control flow statements, etc).
  ```csharp
  //NO
  void DoWork ()
  {
  }
  void DoMoreWork()
  {
  }
  
  //YES
  void DoWork ()
  {
  }
  
  void DoWork ()
  {
  }
  ```
- DO consider declaring variables just before or as part of their first usage instead of up front.
  ```csharp
  //NO
  int hours;
  double payRate, totalPay;
  ...
  totalPay = payRate * hours;
  
  //YES
  double totalPay = payRate * hours;
  ```
- DO put comments above code that is not clear.
- DO NOT put comments in code that repeats what the code does.
  ```csharp
  //NO
  //Loop through stuff
  for (...)
  //YES
  for (...)
  ```

### Lab 1 Adjustments

Because this is lab 1 some adjustments to how C# code is normally written will be observed.

- Any variable that needs to be accessible across function calls will need to be declared outside any function and marked as `static`.
  ```csharp
  void Foo ()
  { 
     id = 1;
  }

  void Bar ()
  {
     if (id > 0)
     { }
  }

  //Outside functions and marked as static
  static int id;
  ```
  NOTE: DO NOT declare all variables this way, only those that are needed across function calls AND using parameters/return type is inefficient.
- Functions need to be marked as `static`.
  ```csharp
  static void Foo () 
  {}

  static void Bar ()
  {}
  ```

## Story 1 - Set Up Project

Create a new Console project to hold your code.

### Description

1. Open Visual Studio.
1. Create a new project by using the `Create a new project` option in the `Start Window`.
   1. Under the languages filter select `C#`. Then search for the template `Console App`.
   1. Select `Console App`. Ensure that the language is shown as `C#` and it includes the tags `C#`, `Linux` and `Windows`. Click `Next`.
   1. Configure project
      1. For the project name use `CharacterCreator.ConsoleHost`.
      1. Set the solution nanme to `Lab1`.
      1. Ensure the project location is set to the `Labs` folder of your Github repo that you have previously cloned.
      1. Click `Next`.
   1. Set additional information.
      1. Ensure the target framework is set to `.NET 5.0`.
      1. Click `Create` to create the project.
1. Commit the solution to Github and ensure it shows up online in the browser under the `Labs` folder.

### Acceptance Criteria

- Solution opens properly in Visual Studio and loads all projects.
- Project is properly named in repository.
- Code compiles cleanly.

## Story 2 - Display Program Information

Display program information when the program runs.

### Description

Display the following information to the user when the program starts.

- Name
- Class (`ITSE 1430`)
- Date

NOTE: This only needs to be displayed when the program starts. If it makes it easier you can display it as part of the main menu added later but this is not required.

### Acceptance Criteria

- Program information is shown when application starts.

## Story 3 - Set Up Main Menu

Implement a menu for the program.

### Description

Display a simple menu system for the user to select options from. The menu can be shown below the program information.

The menu system can use either numbers or letters. If using letters then it should be case insensitive.

The menu should show the following options.

- Create Character
- View Character
- Edit Character
- Delete Character
- Quit

If the user selects an invalid option then display an error and show the menu again.

NOTE: Collecting user input is going to be needed in several places so use functions to make it easier to reuse functionality such as getting user input, validating menu ranges and converting string values to other values (e.g. numerics).

### Acceptance Criteria

- Menu is shown.
- If incorrect option is selected then display an error.

## Story 4 - Support Exiting the Program

Implement the command to exit the program.

### Description

When the user selects the appopriate menu item then display a confirmation message to the user.
If the user chooses to quit then exit the program otherwise return to the main menu.

NOTE: Use a simple confirmation system such as allowing the user to select `Y` or `N`. If the user must enter a letter then the case is insensitive. 

### Acceptance Criteria

- When selected the user is prompted to close the program.
- If the user confirms then exit the program.
- If the user does not confirm then return to the main menu.

## Story 5 - Support Creating a Character

Implement the command to create a character.

### Description

Implement a simple step-by-step wizard to collect information about a character in the game. 

The following information should be collected.

- Name: (Required) The name of the character.
- Profession: (Required) The profession of the character. Let the user choose from 5 different options. (See below)
- Race: (Required) The race of the character. Let the user choose from 5 different races. (See below)
- Attributes: (Required) A set of numeric attributes that define a character. There are 5 attributes and the user must provide values for each one. The values can be between 1 and 100. (See below)
- Description: The optional, biographic details of the character.

For each piece of information prompt the user for the information, validate the input and, if valid, store in a `static` variable as discussed earlier.
All this information is needed in later functions and it is inefficient to pass them around using parameters.

Required information must be provided by the user. Empty values are not allowed. Information that is limited to a list may display a menu to get the user input to make it easier. In either case ensure the user selects only a valid option. Remember that if using letters for menus then case does not matter.

If the user enters invalid data then do not continue on until they provide correct data. Ensure error messages are descriptive enough so they understand what to do.

Once the user has entered all information then return to the main menu.

#### Profession and Race

Consider the setting of your game and select appropriate options for profession and race. Some examples are provided.

- Fantasy
  - Profession might include `Fighter`, `Hunter`, `Priest`, `Rogue` and `Wizard`. 
  - Race might include `Dwarf`, `Elf`, `Gnome`, `Half Elf` and `Human`.
- Space
  - Profession might include `Pilot`, `Soldier`, `Scientist`, `Smuggler` and `Bounty Hunter`.
  - Race might include `Human`, `Sprokan`, `Xeter`, `Kugar` and `Drakon`.

##### Attributes

The attributes are: `Strength`, `Intelligence`, `Agility`, `Constitution` and `Charisma`.
For each attribute the user must provide a value between 1 (low) and 100 (high).

Attributes provide numeric definitions for the core characteristics of a character. For example a strong character (`Strength = 70`) may be clumsy (`Agility = 20`).
An intelligent character (`Intelligence = 80`) may be in poor health (`Constitution = 10`).

### Acceptance Criteria

- User can edit a character from the main menu.
- User is prompted for each piece of information.
- Information is validated according to the rules given earlier.
- Invalid inputs display an error and require the user to keep entering information until valid.

## Story 6 - Support Viewing a Character

Implement the command to view a character.

### Description

When selected the character information previously entered is shown to the user.
Ensure the information is pretty printed.

If no character has been defined yet then instead display an informational message letting the user know such as `No character to display`.

Once complete return to the main menu.

### Acceptance Criteria

- Displays all the information about the character
- If no character has been defined yet then display `No character to display` or equivalent message

## Story 7 - Support Editing a Character

Implement the command to edit the existing character.

### Description

When selected display each of the character's current values and let the user optionally change the value.
If the user does not want to change the value then allow a way to skip past. DO NOT require that the user reenter the data.

There are several different approaches that could be used to implement this story.

Option 1 might be to display a menu where the user can select each of the pieces of information to change (e.g. `Change Name`, `Change Description`, etc) with the current value displayed.
When selected the user sees the current value and can edit it.

Option 2 might be to walk the user back through the add character UI but have the current value displayed with an option to press ENTER to skip changing it.

In all cases:

- When editing a value enforce the same validation rules as when originally defining the character
- Always show the current value so the user can determine if they want to change it
- Do not force the user to re-enter each value

If no character has been defined yet then display an informational message letting the user know there is no character to edit.

Once complete return to the main menu.

### Acceptance Criteria

- User can see and edit the existing character values.
- User can optionally change some character values.
- If no character is defined then the user sees an information message instead.

## Story 8 - Support Deleting a Character

Implement the command to delete an existing character.

### Description

When selected have the user confirm that they want to delete the character.
If the user confirms then "delete" the character otherwise do nothing.

If there is no user to delete then display an information message letting the user know.

Once complete return to the main menu.

### Acceptance Criteria

- User is shown a confirmation message.
- If confirmed then character is deleted otherwise nothing happens.
- If there is no character then an information message is shown.

## Hints

### Naming Conventions

- DO NOT worry about the field names for controls you do not programmatically use (e.g. menu items). The defaults are fine.
- USE descriptive field names for controls you will work with in code (e.g. text boxes).
- USE descriptive method names for event handlers (e.g. `OnFileExit` instead of `menuItem1_Clicked`).
- USE nouns for variable and parameter names.
- USE verbs for method names.
- DO ensure your spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in Canvas by providing the link to the Github repository.
