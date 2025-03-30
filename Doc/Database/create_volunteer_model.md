# [14](https://github.com/AdrienGomes/Imin/issues/14) - Adding the Volunteer model

| Date | Name | Action |
|:----:|:----:|:------:|
|30/03/2025|AdrienGomes|Creation|

_Keywords :_ Database, volunteer, model, migration

## Context

- Creation of the **Volunteer** and **Pole** model

## Analysis

## Implementation | [PR 15](https://github.com/AdrienGomes/Imin/pull/15)

- Add `Volunteer` model class.
- Add `Pole` model class.
- Add `PoleMembership` model class that represent a mepmbership to one of the poles.
  - An `Volunteer` might have many `PoleMembership` to different `Pole`s

## Remarks
- How to run migration :
  - First add migration :
	1. Move to **./Imin/Backend/** folder
	2. Run the command : `dotnet ef migrations add InitDatabase_Volunteer --project .\IMINBackend.Services\IMINBackend.Services.csproj --startup-project .\IMINBackend\IMINBackend.csproj` where _InitDatabase_User_AccessAccount_ sholuld represent the purpose of the migration

  - Then run the app. The `DbBootstrapService` class should apply the migrations. You should see :
	- _EF migrations succesfully applied_ message
	
## Test
- [X] heck that the database has the correct structure 
