using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCollider : MonoBehaviour
{
    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void OnTriggerExit(Collider other);
}
