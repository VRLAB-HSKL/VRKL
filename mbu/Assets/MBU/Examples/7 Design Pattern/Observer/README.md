# Eine Uhr als Beispiel für das Observer Pattern

Das Beispiel einer Uhr für das Observer Pattern finden wir schon im Gang-of-Four Buch.


## Das Observer Pattern
Wir verwenden die beiden Basisklassen *Subject* und *Observer* für die Realisierung
dieses Design Patterns.  Wir können Observer-Instanzen in dieser Klasse registrieren,
wieder löschen und insbesondere gibt es die Funktion *Notify*, mit der
alle registrierten Observer-Instanzen davon unterrichtet werden, dass sich das Subject
verändert hat.

Die Basisklasse *Observer* ist von MonoBehaviour abgeleitet und kann damit einem GameObject
als Component hinzugefügt werden. In der Basisklasse gibt es die Funktion *Refresh*, 
die von den konkreten Views überschriebenen werden muss.

Es gibt insgesamt fünf Szenen. In vier davon finden wir einen Observer, in einer Szene finden wir ein Beipiel für zwei Observer.

## Eine Uhr als Subject
Die Demo enthält die Klasse *Clock*, die von *Subject* abgeleitet ist. Die Klasse
kann die Uhrzeit in Stunden, Minuten und Sekunden speichern. Wie bei Gamma hat die Klasse
eine Funktion *Tick*, die mit Hilfe der .NET-Klasse *DateTime* die aktuelle Uhrzeit abfragt,
die Werte abspeichert und *Notify* aufruft.

Innerhalb der Notify-Funktion wird für jeden registrierten Observer die Funktion *Refresh*
aufgerufen. In dieser Funktion muss eine Implementierung von Observer dafür sorgen, dass die Views
aktuell ist.

Das Subject in der Klasse Clock ist als Singleton-Pattern implementiert. Das Ticken der Uhr realisieren wir mit Hilfe eines leeren GameObjects, an dem die Klasse ClockTicker hängt. Dort wird Clock.Tick() aufgerufen. In dieser Funktion passiert auch das Notify für die Observer. 

## Vier Views einer Uhr
In der Demo gibt es vier verschiedene Observer, die jeweils in einer Szene zu finden sind:
- eine digitale Uhr mit Anzeige von Stunden und Minuten
- eine digitale Uhr mit Anzeige von Stunden, Minuten und Sekunden
- eine analoge Uhr mit Zeigern für Stunden und Minuten
- eine analoge Uhr mit Zeigern für Stunden, Minuten und Sekunden

Zu jeder dieser vier Szenen gibt es auch ein entsprechende, von Oberver abgeleitete C#-Klasse.
In *Awake* wird das Subject instanziert und mit *Attach wird der Observer registriert.
In *FixedUpdate* wird die Funktion *Tick* der Uhr aufgerufen - wir erinnern uns, dann
wird auch *Notify* aufgerufen. Die Funktion *Refresh* im Observer nimmt jetzt die Variablen
aus dem Subject, hier die Uhrzeit entgegen. Die digitalen Varianten wandeln die Information
in Text um und zeigen dies in Unity an. Die beiden analogen Uhren berechnen mit der Information
aus der Klasse *Clock* Rotationswinkel, mit denen wir dann die Rotation für die Uhrzeiger-GameObjects
neu gesetzt werden.

# Model-View-Control
Das MVC-Pattern ist eine Erweiterung des Observer Patterns. Wie wir mit Hilfe der Basisklassen
*Subject* und *Observer* und einem Controller eine Uhr mit Hilfe des MVC-Pattern implementieren 
findet man im Repository *UnityGit* in dieser Organization im Verzeichnis *DesignPattern/ClockMVC*.

![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

