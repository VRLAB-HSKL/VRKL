#  Simple Mesh
Wir erzeugen ein Dreieck auf der Basis der abstrakten Basisklasse *PolyMesh*. 
Dazu leiten wir von dieser Basis die Klasse *SimpleMesh* ab und implementieren
die abstrakte Funktion *Create*. Hier erzeugen wir drei Eckpunkte und besetzen die Topologie
eines Dreiecks. Dabei achten wir darauf, dass die Frontseite eines Dreiecks in Unity
im Uhrzeigersinn durchlaufen wird.

Die Klasse *SimpleMesh* wird im Editor durchgeführt, so dass wir das Dreieck auch im Editor sehen.

Inhalt dieser Szene *triangle*:

- Festeingestellte Kamera mit Komponente *QuitApplication*
- Richtungslichtquelle
- Das Prefab für das Weltkoordinatensystem zur Orientierung und zur Überprüfung der Durchlaufrichtung
- Boden
- 3 Spheres mit Namen V0, V1, V2 als Visualisierung der in *SimpleMesh* verwendeten Eckpunkte.
- Leeres GameObject *SimpleMesh* mit Komponente *SimpleMesh* für das Dreieck. 
- Fünf leere GameObjects mit jeweils einem der fünf platonischen Körpern. Nur einer der
GameObjects ist aktiv. Alle GameObjects enthalten die Komponente *RotateObject*, so dass
die platonischen Körper rotiert werden können. 
- Als Material für die platonischen Körper wird *Cartoon* verwendet.

![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

