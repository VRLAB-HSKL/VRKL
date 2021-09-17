# Design Patterns
Beispiele für die Verwendung von Design Patterns in Unity.
Aktuell finden wir hier Beispiele für die folgenden Patterns:

* Singleton
* State
* Observer

Mehr zu den Patterns finden wir im Buch *Design Patterns" von Erich Gamma et. al.

## Singleton
Es gibt mehrere Möglichkeiten in C# das Singleton-Pattern zu implementieren.
Eine Möglichkeit, die man als Beispiel in der Datei *Singleton.cs* 
im Verzeichnis *MBU/Scripts/DesignPatterns* findet ist ein privater Default-Konstruktor
und eine Variable mit einer Referenz auf die Klasse, die als public static readonly
vereinbart ist. Diese Variante wird auch in der Demo *StatePattern*
für die Zustände der Verkehrsampel verwendet - logisch, jeden Zustand gibt es nur einmal.

Als weitere Variante findet man in der Klasse *GenericSingleton* eine generisch deklarierte
Singleton-Klasse. Eine Demo dafür gibt es aktuell noch nicht.

## State
Ein endlicher Zustandsautomat ist ein Hauptbestandteil von grafischen und interaktiven Anwendungen.
Eigentlich enthält jede Game Enginge einen solchen Automaten.  

Schon bei Gamma et. al. wird eine Verkehrsampel als Beispiel für eine state machine beschrieben,
die wir im Verzeichnis StatePattern vorfinden.

| Verzeichnis | Thema |
| ---- | --------------- |
| StatePattern | Eine Verkehrsampel als Beispiel einer state machine. |
| ----- | ------- |

## Observer
Das Observer Pattern entkoppelt das Subject von einem Observer, also einer View. Der Observer
reagiert auf Veränderungen des Subjects. Eine Uhr ist ein hervorragendes Beispiel für einen solchen
Observer. Wir können analoge oder digitale Uhren anzeigen und wir können entscheiden, ob wir nur
Stunden und Minuten oder zusätzlich die Sekunden anzeigen. Damit erhalten wir vier verschiedene Observer
für ein Subject.

Die Observer-Klasse ist in Unity von MonoBehaviour abgeleitet und ist als Component einem GameObject
hinzugefügt. Die Subject-Klassen sind C#-Klassen ohne Verbindung zu Unity, können also auch
in .NET-Anwendungen eingesetzt werden.

## Model View Control
Vermutlich das bekannteste Pattern, das wir in einer Drei-Schichten Architektur vorfinden.

# Unity-Version
Alle Anwendungen verwenden (Stand September 2021) die Version Unity 2020.3 LTS.


![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

