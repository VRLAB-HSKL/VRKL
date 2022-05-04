# Logging
Mit Logging ist hier nicht die Verwendung von Debug.Log in Unity gemeint,
sondern der Einsatz von Logging-Frameworks wie log4net von Apache.

Mit solchen Lösungen können wir gezielt während der Laufzeit Ausgaben auf einer Konsole,
aber auch in Dateien, erzeugen und später auswerten, zum Beispiel im Rahmen einer Evaluation.

## Voraussetzungen

Wir benötigen die dll, die wir auf der [Download-Seite](https://logging.apache.org/log4net/download_log4net.html) von Apache finden. Kopieren Sie diese Datei in das Verzeichnis *Plugins*, in dem Sie die dll verwenden möchten.

## Appender 

Zusätzlich benötigen Sie sogenannte *Appender* - C#-Klassen, die die Log-Ausgaben entgegennehmen und entsprechend ausgeben. Hier gibt es natürlich File-Appender.

Die Konfiguration für das Logging finden wir in einer XML-Datei im Verzeichnis *Resources*. Diese Konfiguration wird in der Klasse *LoggingConfiguration* geladen. 

Wir finden mehrere Appender:

- AssetsAppender: die Ausgaben werden in die Datei LogOutput.txt im Verzeichnis StreamingAssets geschrieben (auch in Builds!)
- UnityDebugAppender: alle Log-Ausgaben für log4net werden ohne Rücksicht auf den Level mit Hilfe von Debug.Log auf der Konsole ausgegeben.
- UnityConsoleAppender: Ausgabe der Logs aus log4net auf die Unity-Konsole. Abhängig von der Log-Stufe werden verschiedene Funktion der Unity-Debug-Klasse eingesetzt.
- LogtoScreenAppender: Ausgabe der Logs auf die Text-Komponente eines in der Szene vorhandenen GameObjects. Dabei werden nur die fünf letzten Ausgaben angezeigt.

## Konfiguration

Welche Appender mit welcher Logging-Stufe arbeiten konfigurieren wir in einer Datei, die wir im Verzeichnis *Resources* finden. Im Projekt wurde dafür *log4netconfig.xml* verwendet. Dort kann man angeben, welche Klasse mit welchem Level und und mit welchem Appender arbeitet.

## Logging

Mehr Details zum Thema *Logging* finden Sie [hier](https://olat.vcrp.de/m/32f7ae540851874d9735cfcd117e5a92/Assets/downloads/software_logging.pdf).

## Unity-Version

Alle Anwendungen verwenden (Stand Mai 2022) die Version Unity 2020.3.33f1 LTS.


![Lizenzlogo](https://licensebuttons.net/l/by-nc-sa/3.0/de/88x31.png)

