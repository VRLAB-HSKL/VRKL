# Eine Verkehrsampel als Beispiel für das State Pattern

Eine Verkehrsampel ist ein hervorragendes Beispiel für die Anwendung eines Zustandsautomaten.
Im Gang-of-four Buch wird nicht festgeschrieben wer
letztlich dafür verantwortlich ist welche Zustandsübergänge stattfinden.
Im Beispiel liegt dies in der Verantwortung der konkreten Zustände.

Die Basisklasse enthält folgende abstrakte Funktionen:
- OnStateEntered
- OnStateUpdate
- OnStateQuit

Zusätzlich ist die logische Property *DebugOutput* implementiert.
Damit können wir im Inspektor steuern, ob es Ausgaben auf der Konsole in den
Zustandsklassen gibt.

## Basisklasse TrafficState
Von dieser Basisklasse ist für die Verkehrsampel die abstrakte Klasse *TrafficState*
abgeleitet. Jeder Zustand, der hiervon abgeleitet wird kennt seinen Nachfolger.
Für den Wechsel ist die abstrakte Funktion ChangeState() vorgesehen. Die von *TrafficState*
abgeleiteten Klassen implementieren diese Basisklasse und setzen den nächsten Zustand.


## Die vier Zustände einer Verkehrsampel
In der Demo wird eine Verkehrsampel implementiert, die vier Zustände hat. Die Klassen
für diese Zustände sind

- StateStop für "Die Ampel ist rot"
- StateWait für "Die Ampel wird demnächst grün"
- StateGo für "Die Ampel ist grün"
- StateAttention für "Die Ampel ist gelb".

Diese vier Klassen verwenden aktuell noch UnityEngine. Jedoch wird nur Debug.Log
verwendet für Knosolenausgaben. Dies sollte noch verändert werden, damit diese Klassen
überhaupt nicht von Unity abhängen und damit auch in einer .NET-Anwendung eingesetzt werden können.

## Anzeige und Management der Ampel
Die bisher beschriebenen Klassen können nicht zu einem GameObject hinzugefügt werden.
Damit wir die Verkehrsampel in einer Szene einsetzen können gibt es die
Klasse *ApplicationManager*, die von MonoBehaviou abgeleitet ist.

Mit Hilfe dieser Klasse können wir die Umschaltzeiten verändern, auch die Farben für die Ampel
werden hier verwaltet. Letztendlich überprüft die Klasse einen Timer und ruft in *FixedUpdate*
für den aktuellen Zustand, der auf der Variable *CurrentState* abgelegt ist 
die Funktion*CurrentState.changeState()*
auf. Damit wird die Ampel geschaltet.

# State und Observer
Im Repository *UnityGit* in dieser Organization findet man eine Verkehrsampel,
die sowohl das State Pattern wie hier beschrieben und das Observer Pattern verwendet.
Hier wird die Klasse ApplicationManager durch eine von der Basisklasse Observer abgeleiteten
Klasse TrafficLight ersetzt und damit eine komplett objekt-orientierte Implementierung der Verkehrsampel
realisiert.

Wir können hier komplett neue Ansichten einer Verkehrsampel erzeugen ohne die States anzufassen!

![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

