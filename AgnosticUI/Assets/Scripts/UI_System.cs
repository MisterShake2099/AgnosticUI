using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DevName.UI
{
	public class UI_System : MonoBehaviour
	{

		#region Variables
		[Header("System Events")]
		public UnityEvent onSwitchedScreen = new UnityEvent();

		private Component[] screens = new Component[0];
		private UI_Screen currentScreen;
		public UI_Screen CurrentScreen { get { return currentScreen; } }
		private UI_Screen previousScreen;
		public UI_Screen PreviousScreen { get { return previousScreen; } }
		#endregion


		#region Main Methods
		#endregion
		private void Start()
		{
			screens = GetComponentsInChildren<UI_Screen>(true);
		}


		#region Helper Methods
		public void SwitchScreen(UI_Screen screen)
		{
			if (screen)
			{
				if (currentScreen)
				{
					//currentScreen.Close();
					previousScreen = currentScreen;
				}

				currentScreen = screen;
				currentScreen.gameObject.SetActive(true);
				//currentScreen.StartScreen();

				if (onSwitchedScreen != null)
				{
					onSwitchedScreen.Invoke();
				}
			}
		}

		public void GoToPreviousScreen()
		{
			if (previousScreen)
			{
				SwitchScreen(previousScreen);
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
		#endregion

	}
}
