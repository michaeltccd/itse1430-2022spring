# Adventure Game (ITSE 1430)

## Version 2.1

In this lab you will create the basic structure for an "adventure game" like program similar to [Zork](https://en.wikipedia.org/wiki/Zork) or other text-based games.

*NOTE: Images are provided to help clarify instructions where needed. They are examples and should not be taken as requirements.*

## Skills Needed

- C#  
  - Classes and class members
  - Control flow statements
  - Functions

## Story 0 - Design the World

Design the world in which the game takes place.
Use a world that matches with your previous lab.

### Description

Create the world in which your game takes place.
There is no coding for this step, just design.
Is your world an alien planet? Undersea cave? Medieval castle? Or perhaps just your house?
It is up to you.

For this game world we will limit the map to a 3x3 grid of rooms but it is recommended you use constants in your code to make it easy to change later.

![Map](map.png)

For each room the player can move to adjoining rooms.
For example if the player is in room 1 then they can move to rooms 2 or 4.
If they are in room 5 then they can move to rooms 2, 4, 6 or 8.
If they are in room 8 then they can move to rooms 5, 7 or 9.

Choose one of the rooms to be the starting room.
Plan out each room.
Be more descriptive than "kitchen", "cave" or "door".

## Story 1 - Set Up Solution

Set up the solution in preparation for the lab.

### Description

Create a `Console Application` project called `{name}.AdventureGame.ConsoleHost` where `{name}` is your name.
This project is where your UI code will reside.

- Set the solution name to `lab2` and ensure it is placed under the `labs` folder of your repository.
- Ensure the project tags include `C#`, `Linux` and `Windows`.
- Ensure that the target framework is `.NET 5.0`.
- Ensure the main file has a file header.

Create a `Class Library` project called `{name}.AdventureGame` in the same solution.
This project is where your business logic will reside.

- Ensure the project tags include `C#`, `Linux` and `Windows`.
- Ensure that the target framework is `.NET 5.0`.
- Remove any class libraries that are created.

*Note: The business project will have no UI including calls to `Console`.*

Add a reference to the business project in the UI project.

1. Right click the `Dependencies` node of the UI project and select `Add Project Reference`.
1. Check the box for the UI project.

### Acceptance Criteria

- Solution opens properly in Visual Studio and loads all projects.
- Project is properly named in repository.
- Project references are properly set up.
- Code compiles cleanly.

## Story 2 - Display Game Introduction

Display an introduction when the game starts.

### Description

Display an introduction to your game when the program starts.
As part of the introduction include your name, the class name (`ITSE 1430`) and the date you created the program (e.g. `Fall 2021`).

*NOTE: Remember programming fundamentals so use functions to create separate, logical blocks of code.*

### Acceptance Criteria

- Program information is shown when application starts.

## Story 3 - Implement the Game Loop

Implement the core game loop.

### Description

The game loop will consist of prompting the player for input and then responding to that input.
The loop will continue until the player decides to quit.

- During each iteration get the input from the player.
- If the player enters a valid command then perform the requested command (to be implemented later).
- If the player enters an invalid command then display an error and prmopt again.

Some rules on implementation.

- Case does not matter (e.g. `a` and `A` are the same thing).
- Use separate functions to actually handle the commands (e.g. `Move`, `Look`).
- Do not recursively call the game loop because this will result in a stack overflow.
- Ensure the input displays properly without spelling errors.

### Acceptance Criteria

- Player is continaully prompted for input. At this time there is no way to exit the loop.
- If the player enters an invalid input then display an error.
- If the player enters a valid input then perform the command and prompt again. At this time there is no way to verify this works.

## Story 4 - Support Exiting the Program

Implement the command to exit the program after a confirmation message.

### Description

Add support for exiting the program.
When thee player selects this option prompt them if they are sure.
If they confirm then exit the program otherwise continue normally.

### Acceptance Criteria

- When selected the player is prompted to close the program.
- If the player confirms then exit the program.
- If the player does not confirm then return to the main menu.

## Story 5 - Implement the Rooms

Implement the classes and create the rooms.

### Description

In the business project create a class `Room` (or `Area`) to represent a room in your design.
At a minimum you will need the following information.

- Name for a room.
- Description for the room to be displayed to the player.
- Which rooms are connected to the room on each side.

*Note: Expand the class with members as you need more information about a room.*

Create a `World` class to represent a set of rooms.
At a minimum the class should contain an introduction to the game world to orient the player to the environment.
Show the world introduction when the game begins.

For each room in your design add the appropriate room to the world.
Be sure to properly connect the rooms together.

Add a member to represent the starting room for the game world.

### Acceptance Criteria

- Class defined and properly documented to represent a room.
- Class defined and properly documented to represent the world.
- Starting room defined in world.
- World introduction is shown at game startup.

## Story 6 - Implement Player State

create a class to track the player's state such as position.

### Description

Create a class to represent the state of the player.
At a minimum the class should track the room the player is currently in.

Create an instance of the class when the game starts.
Set the player's current position to the starting position of the world.
Each time the player moves (see later) then the state should be updated.

### Acceptance Criteria

- Class defined and properly documented to represent player state.
- Current position set to starting position of world.

## Story 7 - Support Moving Between Rooms

Add commands to allow moving between rooms.

### Description

Add commands to support moving between rooms.
Since a room may have multiple exits the user must be able to choose the direction to move.

Using the current position in the game world, determine what exits are available from the room.
Display a menu allowing the player to move to another, available room.

When a player moves to another room update the current position in the player's state.

### Acceptance Criteria

- Player can move between rooms.
- Player cannot move to a room that is not connected to the existing room.

## Story 8 - Provide Room Descriptions

Provide a description for each room.

### Description

When the player enters a room display the current room's description.

Be sure to show the starting room's description when the game starts.

### Acceptance Criteria

- When player enters a room they see a description.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in Canvas by providing the link to the Github repository.
