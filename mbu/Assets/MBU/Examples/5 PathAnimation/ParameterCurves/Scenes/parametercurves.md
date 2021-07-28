# parametercurves
In dieser Szene wird demonstriert, wie wir mit Hilfe der abstrakten Basisklasse *PathAnimation*
ein GameObject entlang einer Parameterkurve bewegen können. Intern werden in Klassen, die
von *PathAnimation* abgeleitet sind (*Circle* und *Ellipse*) Waypoints berechnet und an eine Instanz
von *WaypointManager* übergeben.


Inhalt dieser Szene:

- Richtungslichtquelle
- Fest eingestellte Kamera mit Komponente *QuitApplication*
- Boden
- Ein GameObject *MovedObject* vom Typ *Sphere* mit den Komponenten *Circle*
und *Ellipse*. Es sollte immer nur eine dieser beiden Komponenten aktiv sein. Die Attribute von Kreis
und Ellipse wie Radius, Halbachsen oder die Anzahl der erzeugten Zielpunkte können im Inspektor eingestellt werden.
Die Zielpunkte werden während der Ausführung **nicht** angezeigt.

![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

