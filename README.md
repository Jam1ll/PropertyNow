# PropertyNow: Real Estate Management Platform

## Project Description
**PropertyNow** is a comprehensive real estate management platform built with ASP.NET Core. It's designed to connect clients, agents, and administrators, providing a seamless experience for managing property listings, sales, and rentals. The application features a robust, multi-user system with distinct functionalities for each role, from browsing and favoriting properties to advanced administrative management.

## Key Features

* **👥 Multi-Role System**: Dedicated dashboards and functionalities for three main roles: **Client**, **Agent**, and **Administrator**.
* **🏘️ Dynamic Property Listings**: A public home page that displays all available properties, sorted from newest to oldest.
* **🔍 Advanced Search & Filtering**: Users can search for properties by a unique code or apply filters based on property type, price range, and the number of rooms and bathrooms.
* **👤 Agent Profiles**: A dedicated section to view all active real estate agents and browse the properties they manage.

### Client Functionalities
* **❤️ Favorite Properties**: Logged-in clients can mark properties as favorites for easy access later.
* **💬 Agent-Client Chat**: A built-in chat system on the property details page allows clients to communicate directly with the property's agent.
* **💰 Make an Offer**: Clients can submit purchase or rental offers directly on a property listing.

### Agent Functionalities
* **🛠️ Property Management**: Agents have full CRUD (Create, Read, Update, Delete) control over their own property listings.
* **📊 Agent Dashboard**: A personalized dashboard showing all registered properties, including those already sold.
* **📩 Offer Management**: View and respond to offers made by clients on their properties.
* **👤 Profile Editing**: Agents can update their personal and contact information.

### Administrator Functionalities
* **📈 Admin Dashboard**: View key metrics like the number of active/inactive agents and clients, and total properties registered.
* **👨‍💼 Agent Management**: Activate, deactivate, or delete agent accounts.
* **⚙️ System Maintenance**: Full control over core system entities, including property types, sale types, and property improvements/amenities.

---

## Technologies Used
* **Backend**: C# and **ASP.NET Core MVC**
* **Database**: SQL Server
* **ORM**: **Entity Framework Core (Code First)**
* **Architecture**: **Onion Architecture**, **CQRS** & **Mediator** (for the API)
* **Authentication**: **ASP.NET Identity** & **JWT** (for the API)
* **Validation**: FluentValidation
* **API Documentation**: Swagger
* **Front-end**: HTML, CSS, Bootstrap
* **Testing**: xUnit (Unit & Integration Tests)
* **DevOps**: Git, GitHub Actions

---

## Project Structure
The project follows a strict **Onion Architecture** to ensure a clean separation of concerns and high maintainability. The layers include:
* **Domain**: Contains the core business entities and logic.
* **Application**: Implements CQRS and Mediator patterns for handling application logic, commands, and queries.
* **Infrastructure**: Manages data persistence with Entity Framework, generic repositories, and other external services.
* **Presentation (Web)**: The user-facing layer, including the MVC Web App and the RESTful API endpoints.

---

## Getting Started

### Prerequisites
Make sure you have the following installed:
* .NET SDK (version 8.0 or later)
* SQL Server
* Visual Studio or Visual Studio Code

### Local Setup
1. **Clone the repository:**
   ```bash
   git clone [your-repository-url]
   cd PropertyNow
