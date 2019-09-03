# DeratControl System

## Purpose
The purpose of the system is tracking and managing the activity of traps that are established in customers' facilities.
### Features
* Managing users of the system
* Managing Organizations and their Facilities
* Adding / Viewing / Editing traps on a map.
* Creating appointments for reviewing traps activity.
* Storing all the traps activitity history.
* Generating reports.

### System Roles
* Administrator :
  This user is responsible for managing the system
* Customer :
  This user is a person who is assigned to a certain organization , a user can view activity/reports of his organization.
* Employee :
  This user is responsible for reviewing facilities and filling all the information about traps activity and saving it in the system.

### Project Architecture

#### DeratControl.Domain module
The core functionality resides here.
This module has no dependencies on other modules in the system.

Types:
* Entities 
* Value Objects
* Aggregates
* Repository Interfaces
* Business Exceptions

#### DeratControl.Application module
All the business use-cases are described in this project.
This module has dependency on DeratControl.Domain and DeratControl.Infrastructure

Types:
* Query Request DTOs/ Query Handlers / Query Response DTOs 
* Command Request DTOs / Command Handlers

#### DeratControl.Infrastructure module
Data Access Layer , HTTP clients to other services reside in this project.
This module has dependency on DeratControl.Domain

Types:
* EF Core Context
* Entities' Configurators
* Implementations of Repositories

#### DeratControl.API project
Exposes http endpoints
This module has dependency on DeratControl.Application

Types:
* Query/Command Dispatchers
* Controllers
* Filters/ Middleware
