using HTC.UnityPlugin.Vive;
using UnityEngine;

public class SwipeSample : MonoBehaviour, IViveRoleComponent
{
	private ViveRoleProperty m_viveRole = ViveRoleProperty.New(HandRole.RightHand);

	private float m_swipeThreshold = 0.75f;

	private Vector2 m_downAxis;

	public ViveRoleProperty viveRole
	{
		get { return m_viveRole; }
	}

	private void OnEnable()
	{
		ViveInput.AddListener(m_viveRole, ControllerButton.PadTouch, ButtonEventType.Down, OnPadDown);
		ViveInput.AddListener(m_viveRole, ControllerButton.PadTouch, ButtonEventType.Up, OnPadUp);
	}

	private void OnDisable()
	{
		ViveInput.RemoveListener(m_viveRole, ControllerButton.PadTouch, ButtonEventType.Down, OnPadDown);
		ViveInput.RemoveListener(m_viveRole, ControllerButton.PadTouch, ButtonEventType.Up, OnPadUp);
	}

	private void OnPadDown()
	{
		m_downAxis = ViveInput.GetPadAxis(m_viveRole);
		Debug.Log(m_downAxis);
	}

	private void OnPadUp()
	{
		// get axis from last frame        
		var upAxis = ViveInput.GetPadAxis(m_viveRole, true);
		var swipeVector = upAxis - m_downAxis;
		// skip if swipe distance is too short        
		if (swipeVector.sqrMagnitude < m_swipeThreshold * m_swipeThreshold)
		{
			return;
		}

		// calculate direction        
		var upScore = Vector2.Dot(swipeVector, Vector2.up);
		var downScore = Vector2.Dot(swipeVector, Vector2.down);
		var leftScore = Vector2.Dot(swipeVector, Vector2.left);
		var rightScore = Vector2.Dot(swipeVector, Vector2.right);
		var maxScore = Mathf.Max(upScore, downScore, leftScore, rightScore);
		if (maxScore == upScore)
		{
			Debug.Log("Swipe Up");
		}
		else if (maxScore == downScore)
		{
			Debug.Log("Swipe Down");
		}
		else if (maxScore == leftScore)
		{
			Debug.Log("Swipe left");
		}
		else if (maxScore == rightScore)
		{
			Debug.Log("Swipe Right");
		}
	}
}