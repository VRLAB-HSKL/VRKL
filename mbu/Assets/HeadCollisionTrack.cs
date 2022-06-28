using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionTrack : MonoBehaviour
{
    public GameObject Head;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Head.transform.position;
    }
}
