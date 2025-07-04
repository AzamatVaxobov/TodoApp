# TodoApp

A backend project to manage todos built with **ASP.NET Core**, **Entity Framework Core**, and follows Clean Architecture principles.

---

## Features
- Create, retrieve, update, and delete todos via RESTful APIs.
- Follows a layered architecture:
  - **DataAccess Layer**: Handles database access and `DbContext`.
  - **Repository Layer**: Abstracts database queries.
  - **Service Layer**: Applies business logic and validations.
  - **Controller Layer**: Exposes APIs via endpoints.
- Integrated **unit testing** with `xUnit` and mocking service calls using **Moq`.

---

## Prerequisites 🧙‍♂️
Before you can run the application, ensure you have the following installed:
- [.NET SDK 8](https://dotnet.microsoft.com/download/) (or later)
- [MySQL Server](https://dev.mysql.com/downloads/)

---

## Feedback on the Project 🚀
### 1. Was it easy to complete the task using AI?
Yes, using AI like ChatGPT made the process **much smoother**. Guidance for setting up the project architecture, resolving errors, and writing unit tests was clear and actionable. It simplified concepts like dependency injection, mocking with Moq, and unit testing for the Service and Controller layers.

---

### 2. How long did the task take you to complete?
Approximately **8–10 hours**, including:
- Setting up the project.
- Resolving dependency/version mismatches (e.g., EF Core + Pomelo versions).
- Writing and debugging tests.
- Documenting everything in the README.

---

### 3. Was the code ready to run after generation?
**Not entirely**, but close:
- Most of the AI-generated code was **90% functional**, but I had to make adjustments.
- Key adjustments included:
  - Fixing **namespace issues** between the test layer and controller.
  - Debugging **Entity Framework package version mismatches** (e.g., `Microsoft.EntityFrameworkCore.Relational` conflicts).
  - Adding proper exception handling and validation checks to improve API robustness.

---

### 4. Which challenges did you face during completion of the task?
- **Version Conflicts**:
  - EF Core (`8.0.0`) vs newer versions (`8.0.14`) caused dependency mismatches.
  - Resolved by aligning all EF Core versions across every project and overriding transitive dependencies.
  
- **Unit Test Setup**:
  - Setting up **Moq** for mocking repositories and services required debugging.
  - Writing unit tests for controllers while ensuring HTTP responses matched expectations (`200`, `404`, etc.).

- **Debugging Dependency Injection**:
  - Had to ensure `ITodoService` and `ITodoRepository` were registered properly in the DI container.

---

### 5. Which specific prompts did you learn as a good practice to complete the task?
The following prompts were the most helpful during the development process:
- *"How to set up clean architecture with Repository and Service layers in .NET?"*
- *"How to write unit tests for Controller methods using xUnit and Moq?"*
- *"How to debug 'Metadata file not found' errors in a multi-project .NET solution?"*
- *"How to resolve version conflicts in EF Core and transitive dependencies?"*
- *"How to generate and apply migrations in EF Core for MySQL?"*

These prompts taught me how to break down problems into smaller, actionable tasks and allowed me to troubleshoot effectively using AI guidance.

---

### 6. Overall Reflection
This project was a great learning experience, especially for:
- Writing cleaner, modular code following layered principles.
- Testing APIs with xUnit to ensure functionality at both the **Service** and **Controller** layers.
- Debugging issues related to dependency injection and package versioning.