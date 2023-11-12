
# Exchange-rate-site

# Task description:

A feladat, hogy készíts egy mini site-ot, frontendként Angulart, backendként .NET Core WebAPI-t használva.

Az alábbi funkciókat kérjük megvalósítani:

Bejelentkezés
User regisztráció
Bejelentkezett oldal funkciói:
- Jelenítse meg az MNB interfészéről (https://www.mnb.hu/arfolyamok.asmx) lekérdezhető árfolyamokat egy táblázatban. Az oldalon lehessen az egyes árfolyamok aktuális állapotát elmenteni adatbázisba egy opcionális megjegyzéssel.
- Mini form, ahol megadott input adatra (forint összeg) kiírja a program az annak megfelelő EUR összeget.
- Egy oldal, ami megjelenít egy listát elmentett árfolyamokról, és szerkeszteni lehet a megjegyzést, és törölni a rekordokat. Az alábbi adatokat kérjük elmenteni:
-- Mentés időpontja
-- Valuta
-- Érték
-- Megjegyzés (szöveges, nem kötelező, max. 100 karakter)

Az adatokat kérlek MSSQL adatbázisban tárold el.

# Setup

Frontend can be started with "ng serve", will listen on "localhost:4200"

Backend needs EntityFramework migrations to be applied so database tables are created, this can be done with "dotnet ef database update --project ExchangeRateBackend" from the nuget package manager console.
The local MSSQL database is used (connectionstring: Server=(localdb)\\mssqllocaldb;Database=ExchangeSiteDB;Trusted_Connection=True;)

MNB service has a mocked version in case tomething unexpected happened. This mocked version can be used if in the program.cs the mocked service is added with dependency injection (the line is already there, commented out)

# Bugs

Even if the endpoint fails, the snackbar displays that it was successful

# What could be improved

Better logging
Better error handling
Use connection string from appsettings.json (or move to env variable)
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
Automapper profiles could be separated (controller-service, service-db model)
Custom exceptions in backend
Translations (i18n on UI)
Spinners/input disable on UI while waiting for response
Auth token refresh
Desktop/mobile view, responsive page
Save and edit exchange rate modals could be merged (reusable modal)
Unit tests
Move interfaces and services to a different place in the Angular app
Investigating whenever number formatting (delimiter, ',' or '.' could cause issues when deployed to different server
Optimization
- Not tracking saved exchange rates on get query
- Add sealed keyword to classes that are not inherited

(CI/CD)