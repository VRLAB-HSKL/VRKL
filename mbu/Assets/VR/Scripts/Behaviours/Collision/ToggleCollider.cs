using UnityEngine;
using VRKL.VR.Behaviour;

public class ToggleCollider : AbstractCollider
{
    private bool isPressed = false;
    public bool IsPressed
    {
        get
        {
            return isPressed;
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        isPressed = true;
    }

    protected override void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }
}
