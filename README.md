# LightsOutGame

This Solution contains 2 separate projects - GameTest and GameTestAPI

In order to run GameTest, GameTestAPI must be running as well. I have configured it so that both projects start at the same time 

If this isn't the case it needs to be set from the solution's properties, select multiple startup projects, select "Start" under both of the projects

Attached to this solution is also a MySQL script file. This needs to be restored on a MySQL database with the name GameTestDB.

The credentials used for the MySQL connection are userid = root and password = pass. These can be changed from the code if desired by going into :

Game Test API -> DataHandling -> ParametersDH.cs - > Line 20

The Board Size can be set from the Database.

The Number of lights that are initially on are also set in the database,
however if the number of lights turned on exceed the board size, then the number of lights on is set to Board Size/2
