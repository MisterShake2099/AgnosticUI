using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ColdPants.AgnosticUI
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
	public class AgnosticUI_Screen : MonoBehaviour
	{
		[Header("Main Properties")]
		public Selectable StartSelectable;

		[Header("Screen Events")]
		public UnityEvent OnScreenStart = new UnityEvent();
		public UnityEvent OnScreenClose = new UnityEvent();

		private Animator animator;


		#region Main
		private void Start()
		{
			animator = GetComponent<Animator>();

			// Make assigned Selectable "selected" on startup.
			if (StartSelectable)
			{
				EventSystem.current.SetSelectedGameObject(StartSelectable.gameObject);
			}
		}
		#endregion

		#region Helpers
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
