# Modular E-mail system

System poczty elektronicznej napisany w języku C# w ramach projektu na studiach.

Głównym założeniem projektu było stworzenie modułowej aplikacji opierającej się na komunikacji protokołem TCP.

Na aplikację składa się:
- Aplikacja serwera - występująca w trzech wariantach:
  - Wykorzystująca połączenie synchroniczne
  - Wykorzystująca połączenie asynchroniczne APM
  - Wykorzystująca połączenie asynchroniczne TAP
- Aplikacja klienta
- Baza danych - przechowująca informacje o użytkownikach i wiadomościach, stworzona przy wykorzystaniu SQLite
- Logger - występujący w dwóch wariantach:
  - Zapisujący wpisy dziennika do pliku tekstowego
  - Zapisujący wpisy dziennika do bazy danych
  
--------------------------------------------------------------------------------------------------

Electronic mail system written in C# as part of University project.

Main objective of the project was to create a modular application that uses TCP protocol.

Application consists of:
- Server - of which there are three variants:
  - Implementing synchronous connection
  - Implementing APM asynchronous connection
  - Implementing TAP asynchronous connection
- Client
- Database - stores information about users and messages, created using SQLite
- Logger - of which there are two variants:
  - Saving logs to text file
  - Saving logs to database
