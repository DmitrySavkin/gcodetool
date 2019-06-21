###  Beschreibung
***
Das Programm kann als Plugin aus dem AutoCAD aufgerufen werden. Um GCode zu generieren kann man den Befehl ***GCode*** tippen sobald das AutoCAD gestartet und bereit ist und ein Zeichen gezeichnet.
Das Innere Teil vom Bauteil muss schraffirt sein. 
***
Um der Plugin aufrufbar zu sein, kann man ihn mit ***AutoCADToolInstaller*** auf den Rechner installieren.
***
Diese Version 1.0 kann nur mit Polylinien ohne Arc und  Kreise umgehen. Die Klassen wurden zur Generierung vom GCode für Linie und Arc sind im Projekt aber deren Methoden funktionieren falsch. Deswegen sind sie nicht ausführbar.

Das Projekt  AutoCADTool wird  zuerst ausgeführt und ruft die anderen Methoden von anderen Projekten

###  Allgemein

***
Ab jetzt besteht dieses Repository aus 2 Branches. 

Das Branch **master** erhält einen funktionierenden getesteten Code.***Zur Bewertung***

 
Das Branch **developer** erhält einen momentan  bearbeitenden Code.


### Werkzeuge

* AutoCAD 2019
* Net Framework 4.8
