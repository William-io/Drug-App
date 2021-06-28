# Drug-App
Asp.Net Core 5 Rest API 


# Getting started

## Installation

Use the package to install **EntityFramrwork & SQLite**

```bash
dotnet tool install --global dotnet-ef
```
```bash
dotnet ef 
```

## Usage on Project

```bash
 dotnet add package Microsoft.EntityFrameworkCore.Sqlite  
 dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## Using Postman
https://localhost:5001/api/Drug
1. **POST**: example JSON | on Plataform use **Body > Raw > Select: Json**
```bash
{
        "id": 1,
        "title": "ABC 10mg/g, creme dermatológico (20g)",
        "description": "Creme para o rosto",
        "manufacturer": "Kley Hertz",
        "quantity": 1,
        "price": 7.18,
        "ownership": "Similar"
}
```
2. **GET**: Duplicate tag & SET **Params** on Response _[200]_ 
| Follow the preview
```bash
{
        "id": 1,
        "title": "ABC 10mg/g, creme dermatológico (20g)",
        "description": "Creme para o rosto",
        "manufacturer": "Kley Hertz",
        "quantity": 1,
        "price": 7.18,
        "ownership": "Similar"
}
```
3. **PUT**: Duplicate tag & SET **Raw** on Response _[200]_ 
| Follow steps in the image. Edit String or Number, after just SEND

<img src="https://github.com/William-io/Drug-App/blob/main/assets/images/Screenshot%202021-06-28%20192748.png" alt="Screenshot of experience in VS2019" title="Experience in VS2019" style="max-width:100%;">

3. **PUT**: Duplicate tag & SET **Raw** on Response _[200]_ 
| Follow steps from the previous image
