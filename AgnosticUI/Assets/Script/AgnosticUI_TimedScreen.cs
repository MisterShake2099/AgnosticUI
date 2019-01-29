using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ColdPants.AgnosticUI
{
	public class AgnosticUI_TimedScreen : AgnosticUI_Screen
	{
		[Header("Timed Screen Properties")]
		public float WaitTime = 1f;
		public UnityEvent OnTimeCompleted = new UnityEvent();

		private float startTime;


		#region Helpers
		public override void StartScreen()
		{
			base.StartScreen();

			startTime = Time.time;
			StartCoroutine(WaitForTime());
		}

		IEnumerator WaitForTime()
		{
			yield return new WaitForSeconds(WaitTime);

			if (OnTimeCompleted != null)
			{
				OnTimeCompleted.Invoke();
			}
		}
		#endregion
	}

}
