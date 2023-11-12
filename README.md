# exchange-rate-site

# Task description:

A feladat, hogy készíts egy mini site-ot, frontendként Angulart, backendként .NET Core WebAPI-t használva.

Az alábbi funkciókat kérjük megvalósítani:

  Bejelentkezés
  User regisztráció
  Bejelentkezett oldal funkciói:
    Jelenítse meg az MNB interfészéről (https://www.mnb.hu/arfolyamok.asmx) lekérdezhető árfolyamokat egy táblázatban. Az oldalon lehessen az egyes árfolyamok aktuális állapotát elmenteni adatbázisba egy opcionális megjegyzéssel.
    Mini form, ahol megadott input adatra (forint összeg) kiírja a program az annak megfelelő EUR összeget.
    Egy oldal, ami megjelenít egy listát elmentett árfolyamokról, és szerkeszteni lehet a megjegyzést, és törölni a rekordokat. Az alábbi adatokat kérjük elmenteni:
      Mentés időpontja
      Valuta
      Érték
      Megjegyzés (szöveges, nem kötelező, max. 100 karakter)

Az adatokat kérlek MSSQL adatbázisban tárold el.

# Setup

Frontend can be started with "ng serve", will listen on "localhost:4200"

Backend needs EntityFramework migrations to be applied so database tables are created, this can be done with "dotnet ef database update --project ExchangeRateBackend" from the nuget package manager console.
The local MSSQL database is used (connectionstring: Server=(localdb)\\mssqllocaldb;Database=ExchangeSiteDB;Trusted_Connection=True;)

# Features

JWT token auth
Angular material design (on some pages)

# Bugs


# What could be improved

Move database, frontend and backend to docker
More secure connection string storing
Pagination for saved exchange rates
Code smell check for backend
More secure password storage for users (encryption)
Design improvements
Remove unnecessary MNB data structure
Refactor request, response, model and service layer object in .net app
Redirection to 404 page if needed, not logged in users should only access login page
Redirection to main page on login
Optimization
- Not tracking saved exchange rates on get query
- Add sealed keyword to classes that are not inherited

# Todo:

Better validation for requests
Better error handling
Unit tests
Move connection string to appsettings.json
Logging
Move interfaces and services to a different place in the Angular app
