using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DevName.UI
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class UI_Screen : MonoBehaviour
	{
		#region Variables
		[Header("Main Properties")]
		public Selectable m_StartSelectable;

		[Header("Screen Events")]
		public UnityEvent OnScreenStart = new UnityEvent();
		public UnityEvent OnScreenClose = new UnityEvent();

		private Animator animator;
		#endregion

		#region Main Methods
		private void Start()
		{
			animator = GetComponent<Animator>();

			// Make assigned Selectable "selected" on startup.
			if (m_StartSelectable)
			{
				EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
			}
		}
		#endregion

		#region Helper Methods
		public virtual void StartScreen()
		{
			if (OnScreenStart != null)
			{
				OnScreenStart.Invoke();
			}

			HandleAnimator("Show");
		}

		public virtual void CloseScreen()
		{
			if (OnScreenClose != null)
			{
				OnScreenClose.Invoke();
			}

			HandleAnimator("Hide");
		}

		void HandleAnimator(string trigger)
		{
			if (animator)
			{
				animator.SetTrigger(trigger);
			}
		}
		#endregion
	}
}
