# Movies Full-Stack Web Application
## Description
- Movies Full-Stack Web Application is a portfolio project designed to demonstrate end-to-end full-stack development with **an Angular frontend, Firebase hosting, an ASP.NET Core backend, SQL Server data persistence, JWT-based authentication, role-based authorization, Azure cloud deployment with Azure DevOps pipelines**.

- The application allows all users to browse movie-related information, registered users to rate movies and administrators to manage data for genres, actors, theaters, and movies.

## Application URL
- URL: https://angularmovies20260609113-c0808.web.app

- **Note**: The backend and database are hosted on low-cost cloud resources (Free F1 tier and Basic DTUs) for portfolio purposes. The first request may take **10–15 seconds** due to **cold start** and database wake-up time. Subsequent requests are significantly faster.

## Architecture
- Diagram

    ![](./images/movies_architecture.png)

## Deployment and Azure services
- Frontend: Firebase Hosting 

    ![](./images/deployment/firebase.png)

- Backend: Azure App Service (Free F1 tier) 

    ![](./images/deployment/azure_app_service.png)

- Backend build and deploy: Azure DevOps pipelines

    ![](./images/deployment/pipeline_build_deploy.png)

- Image Storage: Azure Storage 

    ![](./images/deployment/azure_storage.png)

- Database: Azure SQL Database  (Basic DTUs)

    ![](./images/deployment/azure_sql_database.png)

- Database migration: Azure DevOps pipelines

    ![](./images/deployment/pipeline_database_migration.png)

- Monitoring: Application Insights 

    ![](./images/deployment/azure_application_insights.png)

## Application Functions
- Browse all the movies without logging in

    ![](./images/app_functions/landing_page.png)

- Browse all the movies while logged in as an admin

    ![](./images/app_functions/landing_page_admin.png)

- View movie details

    ![](./images/app_functions/movie_details.png)

- Search for movies

    ![](./images/app_functions/movie_search.png)

- Register new users

    ![](./images/app_functions/register.png)

- Restrict movie rating to authenticated users

    ![](./images/app_functions/movie_rating.png)

    ![](./images/app_functions/movie_rating_2.png)

- Manage genres, actors, theaters, and movies when logged in as an admin

    ![](./images/app_functions/genres.png)

    ![](./images/app_functions/create_movies.png)

- List all the application users

    ![](./images/app_functions/list_users.png)

## API Examples
### Get all genres
- This endpoint is available to all users because the movie search page requires the full genre list. In contrast, actor, theater and movie management endpoints are restricted to administrators.

- Request

    ```
    GET /api/genres/all
    ```

- Response code: `200`

- Response body

    ```
    [
        {
            "id": 1,
            "name": "Action"
        },
        {
            "id": 2,
            "name": "Adventure"
        },
        {
            "id": 3,
            "name": "Animation"
        },
        {
            "id": 4,
            "name": "Comedy"
        },
        {
            "id": 5,
            "name": "Crime"
        },
        {
            "id": 6,
            "name": "Documentary"
        },
        {
            "id": 7,
            "name": "Drama"
        },
        {
            "id": 8,
            "name": "Fantasy"
        },
        {
            "id": 9,
            "name": "Horror"
        },
        {
            "id": 10,
            "name": "Romance"
        },
        {
            "id": 11,
            "name": "Sci-Fi"
        }
    ]
    ```

- Response headers

    ```
    content-encoding: gzip 
    content-type: application/json; charset=utf-8 
    date: Thu,09 Jul 2026 01:00:03 GMT 
    request-context: appId=cid-v1:bae7f47f-e7c8-458a-be98-3d4364d8cb1b 
    server: Microsoft-IIS/10.0 
    transfer-encoding: chunked 
    vary: Accept-Encoding 
    x-powered-by: ASP.NET 
    ```

### Register new user
- Request

    ```
    POST /api/users/register

    {
        "email": "user3@example.com",
        "password": "USER3@example.com"
    }
    ```

- Response code: `200`

- Response body

    ```
    {
        "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVzZXIzQGV4YW1wbGUuY29tIiwid2hhdGV2ZXIgSSB3YW50IjoiYW55IHZhbHVlIiwiZXhwIjoxODE1MDk1Njg1fQ.tf5ZT4SnKZfMzt4qxRzk1reS58OIjTWLpncaJfJJPak",
        "expiration": "2027-07-09T01:14:45.6165535Z"
    }
    ```

- Response headers

    ```
    content-encoding: gzip 
    content-type: application/json; charset=utf-8 
    date: Thu,09 Jul 2026 01:14:45 GMT 
    request-context: appId=cid-v1:bae7f47f-e7c8-458a-be98-3d4364d8cb1b 
    server: Microsoft-IIS/10.0 
    transfer-encoding: chunked 
    vary: Accept-Encoding 
    x-powered-by: ASP.NET 
    ```