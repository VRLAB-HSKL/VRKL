#  Platonics
Diese Szene demonstriert die Verwendung der abstrakten Basisklasse *PolyMesh*. 
Klassen, die wir von dieser Klasse ableiten realisieren ein polygonales Netz
durch Definition der Geometrie und der Topologie. Als Beispiele dafür
werden in diesem Projekt die Klassen *Tetraeder*, *Dodekaeder*, *Oktaeder*,
*Hexaeder* und *Ikosaeder* verwendet. Fügt man diese Klassen einem leeren GameObject
hinzu erhalten wir die entsprechenden platonsichen Körper.

Die Klassen stellen sicher, dass ein MeshRenderer in der Szene vorhanden ist.


Inhalt dieser Szene:

- Festeingestellte Kamera mit Komponente *QuitApplication*
- Richtungslichtquelle
- Fünf leere GameObjects mit jeweils einem der fünf platonischen Körpern. Nur einer der
GameObjects ist aktiv. Alle GameObjects enthalten die Komponente *RotateObject*, so dass
die platonischen Körper rotiert werden können. 
- Als Material für die platonischen Körper wird *Cartoon* verwendet.

![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

