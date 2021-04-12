# EmployeeWebApi
EmployeeWebApiWithUnitTest

-> Neues Web API Projekt (.NET Core 2.x oder 3.x) 
-> In der Datenbank LocalDB eine neue Tabelle Employees anlegen 
  --> Spalten: Id, FirstName, LastName, BirthDate, IsActive 
  --> Einen Controller mit folgenden Routen anlegen: 
  ---> GET ohne Parameter 
       Gibt alle Mitarbeiter zurück 
  ---> GET mit Parameter BirthDate
       Gibt alle Mitarbeiter zurück, die älter sind als das angegebene Datum 
  ---> POST 
       Legt einen neuen Mitarbeiter an 
       Validierung: Kein Feld darf leer sein, IsActive wird im Code immer auf TRUE gesetzt. 
  ---> DELETE mit Parameter Id 
       Löscht den entsprechenden Mitarbeiter 
  ---> Optional PATCH 
       Es können einzelne Werte eines Mitarbeiters geändert werden. Im Body kann bestimmt 
       werden, welche Eigenschaft geändert und mit welchem Wert zugewiesen wird. 
-> Bitte Dependency Injection verwenden 
-> Für alle Routen müssen Unit-Tests existieren. 
