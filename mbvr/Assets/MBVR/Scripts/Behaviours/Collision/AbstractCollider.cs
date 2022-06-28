using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VRKL.VR.Behaviour
{
    public abstract class AbstractCollider : MonoBehaviour
    {
        protected abstract void OnTriggerEnter(Collider other);
        protected abstract void OnTriggerExit(Collider other);
    }
}


