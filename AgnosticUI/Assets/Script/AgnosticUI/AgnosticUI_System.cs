using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ColdPants.AgnosticUI
{
	public class AgnosticUI_System : MonoBehaviour
	{
		[Header("Main Properties")]
		public AgnosticUI_Screen DefaultScreen;

		[Header("System Events")]
		public UnityEvent OnScreenSwitch = new UnityEvent();

		[Header("Transition Properties")]
		public Image TransitionImage;
		public float TransitionInDuration = 1f;
		public float TransitionOutDuration = 1f;

		public AgnosticUI_Screen CurrentScreen { get; private set; }
		public AgnosticUI_Screen PreviousScreen { get; private set; }

		private Component[] screens = new Component[0];


		#region Main
		private void Start()
		{
			screens = GetComponentsInChildren<AgnosticUI_Screen>(true);
			InitializeScreens();

			if (DefaultScreen)
			{
				SwitchScreen(DefaultScreen);
			}

			if (TransitionImage)
			{
				TransitionImage.gameObject.SetActive(true);
			}

			TransitionIn();
		}
		#endregion

		#region Helpers
		void InitializeScreens()
		{
			foreach (Component screen in screens)
			{
				screen.gameObject.SetActive(true);
			}
		}

		public void SwitchScreen(AgnosticUI_Screen screen)
		{
			if (screen)
			{
				if (CurrentScreen)
				{
					CurrentScreen.CloseScreen();
					PreviousScreen = CurrentScreen;
				}

				CurrentScreen = screen;
				CurrentScreen.gameObject.SetActive(true);
				CurrentScreen.StartScreen();

				if (OnScreenSwitch != null)
				{
					OnScreenSwitch.Invoke();
				}
			}
		}

		public void GoToPreviousScreen()
		{
			if (PreviousScreen)
			{
				SwitchScreen(PreviousScreen);
			}
		}

		public void LoadScene(int sceneIndex)
		{
			StartCoroutine(WaitToLoadScene(sceneIndex));
		}

		IEnumerator WaitToLoadScene(int sceneIndex)
		{
			yield return null;
		}

		public void TransitionIn()
		{
			if (TransitionImage)
			{
				TransitionImage.CrossFadeAlpha(0f, TransitionInDuration, false);
			}
		}

		public void TransitionOut()
		{
			if (TransitionImage)
			{
				TransitionImage.CrossFadeAlpha(1f, TransitionOutDuration, false);
			}
		}
		#endregion

	}
}
