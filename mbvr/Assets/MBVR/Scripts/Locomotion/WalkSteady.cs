using HTC.UnityPlugin.Vive;

namespace VRKL.MBVR
{
    /// <summary>
    /// Walk mit Start und Stop mit Hilfe des Buttons.
    /// </summary>
    public class WalkSteady : Walk
    {
        /// <summary>
        /// Walk wird so lange durchgeführt bis der Trigger-Button
        /// wieder gedrückt wird.
        /// </summary>
        protected override void Trigger()
        {
            if (ViveInput.GetPressUp(moveHand, moveButton))
                Moving = !Moving;
        }
    }
}
