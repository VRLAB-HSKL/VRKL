using UnityEngine;
using VRKL.VR.Behaviour;

namespace VR.Scripts.Behaviours.Button
{
    public class DummyButtonBehaviour : AbstractButtonBehaviour
    {
        protected override void HandleButtonEvent()
        {
            Debug.Log(gameObject + " hit!");
        }
    }
}
