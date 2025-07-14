# FastTech Foods Hackathon — Postgraduate in .NET Systems Architecture  

This repository corresponds to one of the microservices that compose the **FastTech Foods** solution — the final project of the Postgraduate Course in **.NET Systems Architecture**.

The objective was to develop a proprietary digital platform for **FastTech Foods**, focusing on **scalability, observability, security, and automation**.  
The solution aims to replace third-party tools, modernizing and scaling customer service and order processing.

This microservice is responsible for managing the **product lifecycle**, performing **create**, **update**, and **delete** operations.  
Data is persisted in a **relational database** and subsequently published to a **message broker (RabbitMQ)** for asynchronous consumption by other microservices in the ecosystem.

---

## 🛠️ Technologies Used  

- **.NET 8.0**  
- **Microservices Architecture**  
- **Docker**  
- **RabbitMQ (Messaging)**   
- **GitHub Actions (CI/CD)**  
- **SQL Server**  

---

## 🏗️ Architecture  

The architecture follows **Domain-Driven Design (DDD)** principles with a microservices and event-driven asynchronous communication approach.  

**Bounded Contexts:**  

- **Identity and Access:** Authentication and authorization of customers and employees.  
- **Product Catalog - Manager:** Management (CRUD) of menu items.  
- **Product Catalog - Customer:** Public catalog search with filters (e.g., Snacks, Juices).  
- **Orders:** Management of order creation, processing, and cancellation.  
- **Kitchen:** Order preparation flow, allowing kitchen staff to accept or reject items.  

---

## 📁 Microservices Repositories  

Each microservice is hosted in its own repository to ensure autonomy and ease of maintenance:  

- [Identity and Access API — `fasttech-auth-api`](#)  
- [Catalog Write API (Admin) — `fasttech-catalog-write-api`](#)  
- [Catalog Read API (Client) — `fasttech-catalog-read-api`](#)  
- [Orders API — `fasttech-ordering-api`](#)  
- [Kitchen API — `fasttech-kitchen-api`](#)  

---

## 📬 Main Repositorie  

- [FastTechFoods](https://github.com/caiofabiogomes/FastTechFoods)  

## 📄 License  

This project is for academic purposes — no commercial use intended.

