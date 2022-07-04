using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("TextMeshProUGUIBasic")]
	[Tooltip("Gets TMP UGUI Text and appends a string to the end of it.")]
	public class TextMeshProUGUIAppend : FsmStateAction
	{
		public FsmGameObject textMeshProUgui;
		public FsmString toAppend;
		public FsmBool addLineBreak;

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var go = textMeshProUgui.Value;
			TextMeshProUGUI tmp = go.GetComponent<TextMeshProUGUI>();
			if (addLineBreak.Value)
            {
				tmp.text += System.Environment.NewLine;
            }
			tmp.text += toAppend.Value;
			Finish();
		}


	}

}
