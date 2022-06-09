using HTC.UnityPlugin.Vive;

namespace VRKL.MBVR
{
    /// <summary>
    /// Walk mit Start und Stop mit Hilfe des Buttons.
    /// </summary>
    public class WalkSteady : Walk
    {
        /// <summary>
        /// Walk wird so lange durchgef�hrt bis der Trigger-Button
        /// wieder gedr�ckt wird.
        /// </summary>
        protected override void Trigger()
        {
            if (ViveInput.GetPressUp(moveHand, moveButton))
                Moving = !Moving;
        }
    }
}
