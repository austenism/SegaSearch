requirement -  File explaining the structure of the files in your submission. This should aid the grader in finding the components described below.

Data initialization:
  Python files - InitializeData.py is the main file that does all of the initialization, using methods from GetRatingsAndNumberSold.py (separated only for readability and clarity)
  Platform Init.sql - initializes the platforms table since it is so small, allows for perfect standardization across other tables utilizing the platform

Tables.sql - This is the table creation code

Procedures.sql - This is a collection of the sql commands used within the program. This is simply for grading purposes as all queries are called from the c# code using Microsoft's SQL Adapter for C#

Application - written in C#, the SegaSearch.sln and SegaSearch file are the visual studio project that this whole project runs in. This is the source code and will need to be opened in Visual Studio.
