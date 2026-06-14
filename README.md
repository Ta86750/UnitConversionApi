# Unit Conversion API

## Description
A RESTful ASP.NET Core Web API for converting numerical values between different units of measurement.

The API currently supports:
- Length conversions
- Weight/Mass conversions
- Temperature conversions

## Technologies Used
- C#
- ASP.NET Core Web API
- Swagger/OpenAPI

## Project Structure
```text
UnitConversionApi
├── Controllers
│   └── ConversionsController.cs
├── Models
│   └── ConversionResponse.cs
├── Services
│   ├── IConversionService.cs
│   └── ConversionService.cs
├── Program.cs
└── README.md