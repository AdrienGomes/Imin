# [13](https://github.com/users/AdrienGomes/projects/6/views/1?pane=issue&itemId=94650239&issue=AdrienGomes%7CImin%7C13) - Adding the User/AccessAccount model

| Date | Name | Action |
|:----:|:----:|:------:|
|22/03/2025|AdrienGomes|Creation|

_Keywords :_ Database, user, model, migration

## Context

- Creation of the **User** and **AccessAccount** model

## Analysis

## Implementation

- Add `AccessAccount` model class.
- Add `User` model class.
  - An `AccessAccount` must have only one `User`
  - On the other hand, a `User` can have multiple `AccessAccount`

## Remarks
- How to run migration :
  - First add migration :
	1. Move to **./Imin/Backend/** folder
	2. Run the command : `dotnet ef migrations add InitDatabase_User_AccessAccount --project .\IMINBackend.Services\IMINBackend.Services.csproj --startup-project .\IMINBackend\IMINBackend.csproj` where _InitDatabase_User_AccessAccount_ sholuld represent the purpose of the migration

  - Then run the app. The `DbBootstrapService` class should apply the migrations. You should see :
	- _EF migrations succesfully applied_ message
	
## Test
- [X] heck that the database has the correct structure 
