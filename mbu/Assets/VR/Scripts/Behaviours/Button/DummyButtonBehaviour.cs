using UnityEngine;
using VRKL.VR.Behaviour;

public class DummyButtonBehaviour : AbstractButtonBehaviour
{
    public override void HandleButtonEvent()
    {
        Debug.Log("DummyButton hit!");
    }
}
