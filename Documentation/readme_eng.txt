>> 19:30 16.10.2022
----------------
Purpose
-C# language
- knowledge and skills of using generally accepted development patterns/techniques of object-oriented programming
-documenting the software you create yourself
-quality control

Content description:
Realize the following business task using domain-driven design principles
layered architecture with appropriate development patterns (keywords: weak connections between layers, dependency injection, inversion of control).

Create a visual user interface using the instructions in the "UI Material" folder.

Create a database and database diagram.
As for the database, the created application can use a freely chosen abstraction (Microsoft SQL Server, SQLite, PostgreSQL, Oracle, etc.).

Create automatic tests to verify the software's operation according to the given requirements. Free choice of testing framework.

Prepare the minimum necessary documentation.
Documentation is required to describe the installation of the application,
to get a general idea of ​​the architecture of the application (the roles of different layers in the application),
to understand the code of the application (if the code in the application documents itself, no documentation about the code is needed).

Non-functional requirements:
The web application must be implemented in the C# programming language using the latest .NET framework.

It is recommended to use the latest version of Visual Studio as a development tool

The application code must compile without errors and can be opened and run from Visual Studio without prior configuration.

The user interface must comply with the HTML5 standard
when creating the user interface, it is recommended to use a framework (for example, Bootstrap) as a basis.

Use a publicly available Git repository for work (for example, one of the three most common: GitHub, GitLab or Bitbucket).
The progress of the work must be clearly observable by the evaluator from version management.

Business Task:
Create a guest registration system that must allow for additions/changes in the future
events taking place and view events that have already taken place.
The user can also delete future events if necessary.
It should be possible to add participants to each event, which are divided into private individuals and legal entities (companies).
It must be possible to view, change and, if necessary, delete the recorded data of participants,
in addition, existing registered participants must be able to be added to other events.
A complete list of guests must be visible for each event.

Functional requirements:
-Home page
-Add event view
-The view of the persons participating in the event
-View to add a participant
-A view for viewing and editing the participant's detailed data

Home - Contains a list of past and future events.
The event name, time, place, number of participants are displayed visually.
A link or button for adding a participant (which leads to the form for adding a participant) and
possibility to delete the event for future events
(deletes both the event and the participants registered for the event).
In addition, it must be possible to move to the form for adding an event.

Add Event View - Contains a form to add new future events.
The form should be able to enter the following data:
event name,
event time (only future date and time can be entered),
venue,
additional information (maximum 1000 characters),
add button and back button to navigate to home page.
After adding the event, automatic redirection to the home page could take place.

View of people participating in the event - Clicking on the name of the event on the home page should open a view of everyone in the event
with the list of participating persons.
The list should include the first and last name for each person (legal name in the case of a company),
personal identification number (register code in the case of a company),
the possibility of deletion from the event
and the back button to navigate to the home page.

Participant addition view - On the home page, there is a button or link behind each event to add a participant, which leads to a separate form.
The form must have a choice whether to add a natural or legal person
and according to the choice made, it must be possible to enter the following data:

Private person/Company

First name/Legal name of the company
Surname/Company registration code
Personal ID/Number of participants from the company
Method of paying the participation fee (choice: bank transfer or cash)
Additional information field (maximum 1500/5000 characters), wishes of the participant

We assume that all self-employed participants have an Estonian personal identification number
and when entered, its correctness is validated.
Payment methods must be able to be managed without changing the source code.
The form also has a save button and a back button to navigate to the home page.
After adding a participant, automatic redirection to the home page could take place.

The view for viewing/changing the detailed data of the participant – the view of the persons participating in the event opens when clicking on the person,
where it is possible to view and change the data saved from the participant addition form.


-------------------------------------------------- -------------------------------------------------- ------------
Login:

----------------
STAGE 1
----------------

>> 20:00 16.10.2022
----------------
Ideas:
-Log (For diagnostic purposes, probably hard to read, but useful later)

>> 21:30 16/10/2022
----------------
-Bootstrap Inspection

>> 23:30 16/10/2022
----------------
Software download and setup.

>> 01:00 17.10.2022
----------------
Technical difficulties with SQL server installation, related to operating system services (VSS refuses to work...)

>> 09:30 17.10.2022
----------------
The OS was reinstalled and the environment was prepared.

>> 11:00 17.10.2022
----------------
SQL Preparations

>> 17:00 18.10.2022
----------------
A break (and I got sick too)

>> 20:00 18.10.2022
----------------
Project Creation Option 1
(CMD commands)
cd.. (navigate to C drive)
mkdir NETAPP (create project folder)
cd NETAPP (navigate to 'C:\NETAPP')
dotnet
dotnet new webapp -o MyWebApp -f net6.0 (creates project folder 'C:\NETAPP')
cd MyWebApp
dotnet watch (the command creates and starts the application, Ctrl+C closes the application, if you wish, you can use the dotnet run command and then manually host..)

>> 12:00 19.10.2022
----------------
(I moved and got sick too... I also informed by email)

----------------
STAGE 2
----------------

>> 13:00 30.10.2022
----------------
Project Creation Option 2 (the previous option was too complicated)
Creating an ASP.NET Web Application in the Microsoft Visual Studio 2019 environment (steps.txt)

>> 17:00 30.10.2022
----------------
Base HTML ready
Adding Bootstrap
Creating and configuring Bootstrap pages

>> 20:00 30.10.2022
----------------
Pause

>> 08:30 31.10.2022
----------------
Adding Bootstrap Pages functionality
-dashboard.aspx
-addevent.aspx
-addparticipant.aspx
-participantinfo.aspx
- C# code

>> 17:30 31.10.2022
----------------
Pause

----------------
STAGE 3
----------------

>> 18:00 31.10.2022
----------------
-Designing the event home page view (dashboard.aspx)
-Writing modules and interfaces
-Adding functionality (following instructions)

>> 21:00 31.10.2022
----------------
Pause

>> 10:00 01.11.2022
----------------
-Introducing the change (I changed the code-based panel populating to asp.net gridview)
-Adding functionality (following instructions)
-Adding modals for a smooth experience

>> 17:00 01.11.2022
----------------
Pause

>> 18:00 01.11.2022
----------------
-Participant view design (addparticipant.aspx)
-Variable passing functionality (dashboard.aspx --> addparticipant.aspx)
-SQL Formation of commands
-Participant addition functionality (SQL commands)

>> 19:00 01.11.2022
----------------
- Placing SQL commands in a separate class and cleaning up the code

>> 21:00 01.11.2022
----------------
-Creating an interface between participants and events (prototype, must be inventive as participants can participate in several events, etc...)
- Add disposal of the table (hopefully there will be no problems with IDs...)
-Initially only private individuals (because actually they could be stored in the same table... I don't know which would be more reasonable)
- Personal code limiters, etc. technical

>> 00:00 02.11.2022
----------------
-It got very difficult with the modals... but since they look good, I will contribute a little
-Creating alternatives

>> 02:00 02.11.2022
----------------
Pause

>> 08:00 02.11.2022
----------------
- The communication between the tables became too complicated, I decided to make my own table for each event.
-Each event now has its own table of participants
-Adding participants (basic)

>> 12:00 02.11.2022
----------------
-Cleaning the code, removing bugs.
-Since I use a modal to delete/remove, removing participants is currently broken (beauty requires sacrifices...)

>> 13:00 02.11.2022
----------------
-Evaluating the code, searching for errors.
-Removal of redundant comments.

>> 13:30 02.11.2022
----------------
-Adding a debugger (useful)
-Removing participants
-Participant modal now updates the data in the database

>> 15.00 02.11.2022
----------------
- Expected functionality achieved, Add and remove events, Add and remove participants to an event, Change data
-Error checking
- Work in sufficient readiness to present existing shortcomings, as there are different ways of solving...

>> 15.20 02.11.2022
----------------
- Preparation of documentation. (how to use etc...)

>> 16.20 02.11.2022
----------------
- finishing and uploading

----------------
Mistakes:
- Double ID if the previous entries have been deleted ("easy to fix" on the SQL side, but the ID should be worked on a bit more)
- The ID of the entry comes from the GridView component (it would be better to solve it in another way, but this is how it works at the moment)
- Payment method not set (dropdown)
- Entry type not set, Individual/Company (toggle)
- Participant. The mod freezes when you make a choice in the dropdown
- The number of participants is not set (because I changed the approach in the meantime)
- No character limit
- No personal code validation (easy to set up, but other priorities at the moment...)
- Currently it is possible to add participants to events that have worked (perhaps useful in the future?)
- It rarely happens that the event table is named [Participants_?SQLGetField]. not sure why at the moment... with the debugger this error does not occur.
  The debugger can be enabled in the Admin.Master.cs file, in the Admin.Debug class, with the isEnabled variable (line 40)
  The command that causes this is SQLGetField() and is located in the SQLClass.cs file (line 182)
  It is called by SQLDeleteAtID() and is located in the SQLClass.cs file (line 149)
  This is called by RemoveFromDatabase() and is located in the Admin.Master.cs file (line 95)
  I suspect that something is happening with the id in the meantime, I implemented some kind of correction, it seems to work, but this error has occurred many times!

-------------------------------------------------- -------------------------------------------------- ------------
Manual:
1. Assuming that Microsoft SQL Server Management Studio has been successfully installed, Run SQLQuery_START.sql to enter the sample data. (Empty events)
2. Open the project SQL_Test_Project with Visual Studio
3. Create a connection to the SQL server (described in the steps.txt file)
4. Press F5 or 'run' button
5. If the web application started successfully, further instructions are already written in the application.

-------------------------------------------------- -------------------------------------------------- ------------
Used:
-Bootstrap 5.2.2 (https://getbootstrap.com/docs/5.0/getting-started/download/)
-ASP.NET (dotnet-sdk-6.0.402-win-x64.exe) (https://download.visualstudio.microsoft.com/download/pr/9f4d3331-ff2a-4415-ab5d-eafc9c4f09ee/1922162c9ed35d6c10160f46c26127d6/dotnet-sdk-6.0.402-win-x64.exe) sdk-6.0.402-win-x64.exe)
-Microsoft SQL Server (SQL2019-SSEI-Dev.exe) (https://go.microsoft.com/fwlink/p/?linkid=866662)
-SQL Server Management Studio (SSMS) 18.12.1 (SSMS-Setup-ENU.exe) (https://aka.ms/ssmsfullsetup)
-Visual Studio Community 2019 (16.11.11)
(it was recommended to download the latest one, but my previous works were written with this version, and there is currently enough downloadable material, approx. 10GB. Unfortunately, there is no time for a virtual machine at the moment either.
I believe that the evaluation of the work will go smoothly.)