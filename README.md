CookingPal

CookingPal is a cross-platform recipe application built with C# and .NET MAUI. The application allows users to create an account, select ingredients they currently have available, and find recipes they can make using those ingredients.

The project uses a local SQLite database to store users, ingredients, and recipes.

Project status: Older university project / portfolio project. The project was originally developed using an earlier .NET MAUI environment and may require version adjustments to run with current tooling.

---

About the Project

CookingPal was developed as a mobile application focused on helping users decide what they can cook based on the ingredients they already have.

The main idea is simple:

Select your ingredients → CookingPal checks the recipes → See what you can make.

The application combines a graphical user interface with local database storage and C# application logic.

---

Features

User Accounts

* User registration
* User login
* Required-field validation
* Password confirmation during registration
* Basic password-strength validation
* SHA-256 password hashing during registration
* Password verification functionality

Ingredient Selection

* Displays a list of available ingredients
* Allows users to select ingredients they currently have
* Stores ingredient selection information in SQLite
* Uses the selected ingredients when searching for recipes

Recipe Matching

The **What Can I Cook?** feature compares the ingredients selected by the user with the ingredients required by each recipe.

A recipe is displayed when the user has all of its required ingredients.


Meal Type Filtering

Recipes can be filtered by:

* All
* Breakfast
* Lunch
* Dinner

Recipe Browsing

The All Recipes page retrieves recipes from the SQLite database and displays them for browsing.

Users can select a recipe to view its details.

Recipe Details

The recipe details page displays:

* Recipe name
* Ingredients
* Cooking instructions

---

Technologies Used

| Technology       | Purpose                                    |
| ---------------- | ------------------------------------------ |
| **C#**           | Application logic                          |
| **.NET MAUI**    | Cross-platform application development     |
| **XAML**         | User interface design                      |
| **SQLite**       | Local database storage                     |
| **SQLite-net**   | SQLite database access                     |
| **Async/Await**  | Asynchronous database operations           |
| **Data Binding** | Connecting UI elements to application data |

---

Project Structure

```text
CookingPal/
│
├── Model/
│   ├── Ingredient.cs
│   ├── Recipes.cs
│   └── User.cs
│
├── Pages/
│   ├── AllRecipesPage.xaml
│   ├── AllRecipesPage.xaml.cs
│   ├── HomePage.xaml
│   ├── HomePage.xaml.cs
│   ├── LoginPage.xaml
│   ├── LoginPage.xaml.cs
│   ├── MyIngredientsPage.xaml
│   ├── MyIngredientsPage.xaml.cs
│   ├── RecipeDetailPage.xaml
│   ├── RecipeDetailPage.xaml.cs
│   ├── RegisterPage.xaml
│   ├── RegisterPage.xaml.cs
│   ├── WhatCanICookPage.xaml
│   └── WhatCanICookPage.xaml.cs
│
├── Service/
│   └── LocalDb.cs
│
├── App.xaml
├── App.xaml.cs
├── AppShell.xaml
├── AppShell.xaml.cs
├── MauiProgram.cs
└── CookingPal.csproj
```

---

Database

CookingPal uses a local SQLite database named:

```text
Userinfo.db
```

The database contains three main tables:

User

Stores user account information such as:

* ID
* Name
* Email
* Password
* User ingredient information

IngredientItem

Stores ingredient information including:

* ID
* Ingredient name
* Selection state

Recipes

Stores:

* Recipe ID
* Recipe name
* Recipe instructions
* Recipe category
* Ingredients

---

How the Application Works

The main application flow is:

```text
             ┌──────────────┐
             │   CookingPal │
             └──────┬───────┘
                    │
             ┌──────▼───────┐
             │ Login /      │
             │ Registration │
             └──────┬───────┘
                    │
                    ▼
              ┌───────────┐
              │   Home    │
              └─────┬─────┘
                    │
       ┌────────────┼────────────┐
       │            │            │
       ▼            ▼            ▼
  Ingredients   What Can I    All Recipes
                  Cook?
       │            │            │
       │            ▼            ▼
       │       Ingredient    Recipe List
       │         Matching         │
       │            │             │
       └────────────┤             │
                    ▼             ▼
              Matching       Recipe Details
               Recipes
```

---

Key Programming Concepts

This project gave me practical experience with several C# and application-development concepts.

Object-Oriented Programming

The application uses classes to represent different parts of the system, including:

* `User`
* `Ingredient`
* `Recipes`
* `LocalDb`

Database Operations

The `LocalDb` service handles database operations including:

* Creating tables
* Adding users
* Adding recipes
* Adding ingredients
* Retrieving recipes
* Retrieving selected ingredients
* Updating users
* Clearing ingredient data

### Asynchronous Programming

Database operations use C# asynchronous programming with `async` and `await`.

For example:

```csharp
var recipes = await _localDb.GetAllRecipes();
```

This allows database operations to run asynchronously rather than blocking the application while data is being retrieved.

Data Binding

The application uses XAML data binding to connect UI elements with C# model properties.

For example, ingredient selection is connected to the `IsSelected` property:

```xml
<CheckBox IsChecked="{Binding IsSelected}" />
```

 Collection Views

`CollectionView` is used to display collections of ingredients and recipes dynamically.

Navigation

The application uses page navigation to move between different parts of the application, such as:

```text
Login → Home
Home → My Ingredients
Home → What Can I Cook?
Home → All Recipes
Recipe List → Recipe Details
```

---

 Recipe Matching Logic

One of the main pieces of application logic is the ingredient-matching system.

CookingPal retrieves the ingredients selected by the user and compares them against the ingredients required by each recipe.

Conceptually:

```text
User Ingredients
       +
Recipe Ingredients
       ↓
Compare Ingredients
       ↓
Are any ingredients missing?
       │
   ┌───┴───┐
   │       │
  No      Yes
   │       │
   ▼       ▼
 Show    Don't show
 recipe    recipe
```

This allows the application to provide recipe suggestions based on what the user already has available.

---

Sample Recipes

The application includes initial recipe data that can be seeded into the local database.

Examples include:

* Grilled Cheese Sandwich
* Pasta Alfredo
* Veggie Omelette
* Avocado Toast
* Chicken Stir Fry

Each recipe contains a name, category, ingredients, and cooking instructions.

---

Authentication

During registration, passwords are processed using SHA-256 hashing before being stored.

The project also contains password verification functionality.

> **Security note:** This implementation was created as part of a learning project. For a production application, password storage should use a modern password-hashing approach such as Argon2, bcrypt, or PBKDF2 with appropriate salting and security practices.

---

 User Interface

The application uses **XAML and .NET MAUI controls** to create its interface.

The UI includes:

* Scrollable layouts
* Buttons
* Labels
* Checkboxes
* Pickers
* CollectionViews
* Recipe detail views
* Page navigation

The design uses a warm cooking-inspired visual style with rounded UI elements, emojis, and custom fonts.

---

What I Learned

Through this project, I gained practical experience with:

* C# application development
* .NET MAUI
* XAML
* SQLite databases
* CRUD-style database operations
* Object-oriented programming
* Data binding
* Collections
* Asynchronous programming
* Page navigation
* Input validation
* Password hashing
* Filtering and comparison logic
* Connecting a user interface to a local database

---

 Current Limitations

This is an older university project and there are areas that could be improved.

Some potential improvements include:

* Updating the project to a current .NET MAUI version
* Improving authentication and password security
* Adding stronger input validation
* Improving database relationships between users and their ingredients
* Adding the ability to create and manage recipes
* Improving error handling
* Improving the overall UI/UX
* Adding automated tests
* Adding more recipes and ingredients
* Improving the recipe matching system

---

Future Improvements

Possible future development could include:

* A fully implemented favourites system
* Allowing users to add their own recipes
*  Automatically managing each user's ingredient collection
*  Generating a shopping list for missing ingredients
*  More advanced recipe filtering
*  Recipe images
*  Improved user-specific data management
*  More secure authentication
*  Cloud-based data storage
*  Automated unit and integration testing

---

Project Purpose

CookingPal was created as a university project to apply programming and software-development concepts in a practical application.

I am continuing to use the project as part of my development portfolio and as a foundation for improving my understanding of **C#, databases, application architecture, and software development**.

---

 Project Status

**Status:** Completed university project / ongoing portfolio improvement

The original application was developed using an older .NET MAUI environment. The code is being preserved and documented as part of my programming portfolio, with potential improvements planned for future development.
