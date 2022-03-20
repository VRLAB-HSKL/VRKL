using UnityEngine.SceneManagement;
using VR.Scripts.Behaviours.Button;

public class CutTransitionBehaviour : AbstractButtonBehaviour
{
    public string TargetScene;
    
    protected override void HandleButtonEvent()
    {
        SceneManager.LoadSceneAsync(TargetScene);
    }
}
