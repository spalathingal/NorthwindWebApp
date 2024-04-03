# NorthwindWebApp

## Overview
Exposes two REST API endpoints (get/post)

1) GET: queries the [NorthWind SQLite DB](https://github.com/jpwhite3/northwind-SQLite3) to get lists of products for sale. Each
product should returs: Category Name, Category Description, Product Name, Supplier Name,
Quantity, Price, In Stock Units.
2) POST: Places orders using customer and product information (see example_post_request.json)

## Dependencies
- Install [.NET](https://dotnet.microsoft.com/en-us/download)
- Install [Visual Studio](https://pipenv.pypa.io/en/latest/)

## To Run
- Import project into Visual Studio
- Click Run (https) in Visual Studio

## Results
- GET output: get_response.json
- POST output: "New Product 1" can be seen in get response