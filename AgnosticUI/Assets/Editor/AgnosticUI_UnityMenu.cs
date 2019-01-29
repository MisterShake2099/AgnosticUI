using UnityEditor;
using UnityEngine;

namespace ColdPants.AgnosticUI
{
	public class AgnosticUI_UnityMenu : MonoBehaviour
	{
		[MenuItem("ColdPants/AgnosticUI/Create Instance")]
		public static void CreateAgnosticUI()
		{
			GameObject agnosticUI = AssetDatabase
					.LoadAssetAtPath<GameObject>("Assets/Prefab/AgnosticUI/AgnosticUI.prefab");

			if (agnosticUI)
			{
				GameObject agnosticInstance = Instantiate(agnosticUI);
				agnosticInstance.name = "AgnosticUI";
			}
			else
			{
				EditorUtility.DisplayDialog(
						"AgnosticUI Warning", "AgnosticUI prefab missing.", "Agreed");
			}
		}
	}

}
