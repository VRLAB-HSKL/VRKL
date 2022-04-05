using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VR.Scripts.Behaviours.Collision;

/// <summary>
/// Dieses Skript beschreibt die Auswahl einer Schneekugel. Dabei kann der Benutzer mit zwei Pfeilen die jeweiligen vorherigen oder folgenden Schneekugeln anzeigen.
/// </summary>
public class SelectScenario : MonoBehaviour
{
    /// <summary>
    /// Wird benoetigt um herauszufinden, ob im Moment eine Szene geladen wird oder nicht.
    /// </summary>
    [SerializeField]
    LoadSceneCollider IsLoading;

    /// <summary>
    /// Enthaelt alle Schneekugel Modelle.
    /// </summary>
    [SerializeField]
    List<GameObject> Globes;

    /// <summary>
    /// Left arrow collider
    /// </summary>
    [SerializeField]
    ToggleCollider LeftArrow;

    /// <summary>
    /// Right arrow collider
    /// </summary>
    [SerializeField]
    ToggleCollider RightArrow;

    /// <summary>
    /// Das beschreibende Label welches sich unterhalb der Schneekugel Modelle befindet.
    /// </summary>
    [SerializeField]
    TextMeshProUGUI Label;

    /// <summary>
    /// Urspruengliche Startposition der aktuell aktivierten Schneekugel.
    /// </summary>
    private Vector3 startPosition;

    /// <summary>
    /// Index zum Speichern des aktuell sichtbaren Schneekugel Model.
    /// </summary>
    private int actualGameObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Globes.Capacity; i++)
        {
            // Erstes Element auswaehlen
            if (i == 0)
            {
                Globes[i].SetActive(true);
                startPosition = Globes[i].transform.position;
                actualGameObject = i;
                Label.text = Globes[i].name;
            }
            // Alle anderen deaktivieren
            else
            {
                Globes[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Wird aktuell eine Szene geladen?
        // Falls ja, lass alle anderen Schneekugeln außer der
        // ausgewaehlten Schneekugel aus der Szene verschwinden.
        if (IsLoading.IsLoading)
        {
            for (int i = 0; i < Globes.Capacity; i++)
            {
                if (i == actualGameObject)
                {
                    return;
                }
                else
                {
                    Globes[i].SetActive(false);
                }
            }
        }
        // Wenn nicht ueberpruefe im naechsten Schritt ob der linke oder rechte Pfeil gedrueckt wurde.
        else
        {
            // Wenn der rechte Pfeil gedrueckt wurde, dann ueberpruefe ob ein Inkrement
            // zur noch im Indizes Bereich der Liste waere.
            if (RightArrow.IsPressed)
            {
                if (actualGameObject + 1 < Globes.Capacity)
                {
                    actualGameObject++;
                    for (int i = 0; i < Globes.Capacity; i++)
                    {
                        if (i == actualGameObject)
                        {
                            Globes[i].SetActive(true);
                            Label.text = Globes[i].name;

                        }
                        else
                        {
                            Globes[i].transform.position = startPosition;
                            Globes[i].SetActive(false);
                        }
                    }
                    startPosition = Globes[actualGameObject].transform.position;
                }
            }

            // Wenn der linke Pfeil gedrueckt wurde, dann ueberpruefe ob ein Inkrement
            // zur noch im Indizes Bereich der Liste waere.
            else if (LeftArrow.IsPressed)
            {
                if (actualGameObject - 1 >= 0)
                {
                    actualGameObject--;
                    for (int i = 0; i < Globes.Capacity; i++)
                    {
                        if (i == actualGameObject)
                        {
                            Globes[i].SetActive(true);
                            Label.text = Globes[i].name;

                        }
                        else
                        {
                            Globes[i].transform.position = startPosition;
                            Globes[i].SetActive(false);
                        }
                    }
                    startPosition = Globes[actualGameObject].transform.position;
                }
            }
        }
    }
}