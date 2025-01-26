# Imin - Project

## Summary
- [Description]
- [Project organization]
	- [Structure]
	- [Branches]
	- [Scenario for contributors]
- [Environment and deployement]
	- [Environment]
	- [Deployement]
	- [Secrets]
- [Documentation]
- [Local developement]

## Description

**Imin** is a project of 3 applications to support organization for a french charity. 
This charity is called **AHM** _(Association humanitaire de montpelier)_ and organize food distribution every day of the year.

This association also has a **French class** department, which will be our focus first.

### Project organization

The project will be divide into 3 applications :

1. A <u>**backend**</u> application that supports API functionnalities made with <u>**.Net framework (C#)**</u>
2. A <u>**mobile frontend**</u> application for final users made with <u>**the flutter framework (dart)**</u>
3. A <u>**desktop frontend**</u> aplication, that will arrive later, to help manage administration task more easily than from a phone made with the <u>**flutter framework (dart)**</u>

## Project organization

### Structure

We use GitHub project feature to help organize our work.
The project is build upon the **kanban** methodology, with 5 columns :

- **New** 

For items that are newly added to the project but not mature enaugh for someone to work on it. 
At this point the item **is not turned into an issue yet**.

- **To do**

When a _New_ item is found mature enaugh for someone to take it, we transform it into an issue.
This will trigger an action to sort the item into the To do column.
_PI:_ add labels for contributors to know which subjects it tackles

- **In progress**

Item has been assigned to someone, therefore the action will move automatically the item into the _In progress_ column.
Someone is handling it

- **In review**

The assignee has made a pull request, and requires someone to review its changes.

- **Done**

Well its done

### Branches
**Master is protected to avoid updating directly**, it always requires a pull request.

For developemnt, branch naming convention is as followed :

- If the subject is a bug, branch name is -> **fix/the_branch_name**
- If the subject is a dev, branch name is -> **dev/the_branch_name**

For deployement, branch convention is as followed :

- If the deployment is for the _development environement_, branch name is -> **version/dev/v.x.x.x**
- If the deployment is for the _release environement_, branch name is -> **version/release/v.x.x.x**

These branches has greater protection than master, **as their creation (as well as tags creation) will trigger a deployement upon the dedicated environement**

If a bug is found upon one of these 2 branches, the process is as followed :
1. Fix the bug from master _(see [Scenario for contributors] section)_
2. Create a pull request upon master
3. Once validated and merged, cherry-pick the fix onto the **version/release/v.x.x.x** branch
4. _Automatic_ -> The branch merge will trigger an action that will redeploy the  

### Scenario for contributors

Anyone that want to takle a suject will assign itself to the project item, create a branch following the naming convention as describer in [Branches]

Once dev is finished, create a pull request onto <u>**master**</u>, pull request will need review. Once review is made, the PR is merged and dev is done.

## Environment and deployement

### Environment

We will have 2 public and online envirnement :
1. **Developement** :
This environement is for _in-real-condition_ tests. This will be used by contributors

2. **Release** :
This environment is the production one

### Deployement

Our application will be hosted onto Hostinger for cost purposes. 
Only contributors with **project-write** rights will be able to deploy upon one of theses environments

Deploymenent is made by creating a branch according to [Branches] naming convention

### Secrets

Our secrets will be stored into GitHub and scoped for each environments

_PI:_ Secrets cannot be seen from GitHub. 

## Documentation

The folder **Doc** is made to hold each of the documentation files.
The folder structure is as followed :
- Backend
- Frontend 
	- Mobile
	- Desktop
- Devops

A dev requires a **_$dev-name$.md_** file in order to be validated. A template can be found within **Doc** folder (_template-dev.md_)

The idea behind this process, is to have a quick look over a developement to know **how it works and the choices made by the developpers**.

If someone is **to update an existing dev**, it will update the dedicated _$dev-name$.md_ file

## Local developement

- I strongly recomend having <u>Visual Stodio</u> for _.Net developement_, as it has full support for .Net core Framework
- Docker as we will use docker to deploy our applications
- Dbeaver or any ORM DB manager softwares
- I recomend VSCode for _Flutter developement_
- For screenshots, i recommend [Screenpresso](https://www.screenpresso.com/fr/telecharger/)

For secrets management in local, a **dev_env_file.env.txt** is made to store these secrets. No need to change anything, but if you do, its here
For running the backend docker-compose file :
1. Use Visual Studio IDE (a docker compose project should be found)
2. Use cmd within the docker-compose folder -> <u>docker-compose up --env-file _**dev_env_file.env.txt**\_path_</u>. If not within the docker-compose file, use **-f** docker-compose argument to specify the path

See :
- [docker-compose](https://docs.docker.com/reference/cli/docker/compose/) documentation
- [Visual Studio Docker Doc](https://learn.microsoft.com/en-us/visualstudio/containers/docker-compose-properties?view=vs-2022#docker-compose-msbuild-properties)
