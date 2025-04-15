# 🚗 ABZ Vehicle Insurance Management System

This is a full-stack web application built using ASP.NET Core (.NET 8), Entity Framework, and SQL Server that allows users to manage vehicle insurance data, including customers, policies, claims, and proposals. The system includes role-based features for admins, agents, and customers.

## 🔧 Features

- User Authentication & Authorization (Admin, Agent, Customer)
- Policy creation and assignment
- Customer and vehicle registration
- Insurance claim management
- Proposal handling
- RESTful Web APIs for modular structure
- API Gateway for unified routing
- Azure-deployed backend services

## 🏗️ Project Structure

- `ABZAuthenticationWebApi` – Handles login, signup, JWT auth
- `ABZCustomerWebApi`, `ABZPolicyWebApi`, etc. – Domain-specific APIs
- `ABZCustomerDBProject`, `ABZPolicyDBProject`, etc. – Database layers
- `ABZVehicleInsuranceMVCApp` – MVC-based front-end application
- `ABZWebApi-GateWay` – Central API Gateway

## ☁️ Deployment

All APIs and services are deployed to **Microsoft Azure** for accessibility and scalability.

## 💻 Technologies Used

- ASP.NET Core Web API
- .NET MVC Framework
- Entity Framework Core
- SQL Server
- Azure App Services
- RESTful APIs
- Git & GitHub

## 🧠 Team & Contributions

This project was developed as part in intern with a focus on building real-world, scalable enterprise-level software.

## 📂 Setup Instructions

1. Clone the repo:
   ```bash
   git clone https://github.com/GANJI01/VehicleInsuranceWeb.git
