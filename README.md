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

## How to Run the Application 💻
### Steps:
1. **Clone the Repository**:
   ```bash
   git clone <your-repo-url>
   cd TodoApp