# rectangle
In dieser Szene wird demonstriert, wie wir mit Hilfe der Komponente *WaypointManager*
ein GameObject entlang einer Liste von Punkten animieren können. Die Waypoints werden 
in der Szene erzeugt und über eine C#-Komponente an den WaypointManager übergeben.


Inhalt dieser Szene:

- Richtungslichtquelle
- Fest eingestellte Kamera mit Komponente *QuitApplication*
- Boden
- 6 GameObjects vom Typ *Capsule*, die mit den Namen *waypoint-0* bis *waypoint-5* versehen sind.
- Ein GameObject *MovedObject* vom Typ *Sphere* mit den Komponenten *InteractiveWaypoints*
und *MoveTowardWaypoint*. In *InteractiveWaypoints* werden die Waypoints im Inspektor gesetzt, es kann
entschieden werden ob die Zielpunkte während der Ausführung der Anwendung dargestellt werden.
Die Komponente *MoveTowardsWaypoint* instanziiert den WaypointManager und fragt die Liste
der Wegpunkte aus der Komponente *InteractiveWaypoints* ab. Die Geschwindigkeit der Bewegung
und der Abstand, ab dem ein Zielpunkt als erreicht gilt, können im Inspektor eingestellt werden.

![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

