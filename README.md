# MovieDB 🎬

A .NET Core web application that displays currently playing movies using The Movie Database (TMDB) API.

## Features

- Displays currently playing movies in a responsive grid layout
- Shows movie details including title, release date, rating, and overview
- Individual movie detail pages
- Responsive design with Bootstrap
- Error handling for API requests

## Prerequisites

- .NET 6.0 or later
- TMDB API key

## Setup

1. Clone the repository:
```bash
git clone https://github.com/yourusername/MovieDB.git
```

2. Add your TMDB API key to `appsettings.json`:
```json
{
  "TMDb": {
    "ApiKey": "your_api_key_here"
  }
}
```

3. Run the application:
```bash
dotnet run
```

## Project Structure

- `Controllers/MoviesController.cs`: Handles movie-related HTTP requests
- `Services/TmdbClient.cs`: TMDB API integration service
- `Views/Movies/Index.cshtml`: Main movie grid view
- `Models/`: Contains movie-related data models

## Technologies Used

- ASP.NET Core MVC
- C#
- Bootstrap
- TMDB API
- HTML/CSS

![image](https://github.com/user-attachments/assets/ab21a8b4-402d-48f9-9b0e-26d4d89a1d5e)

