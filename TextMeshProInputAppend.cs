using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("TextMeshProUGUIBasic")]
	[Tooltip("Gets TMP UGUI Text and appends a string to the end of it.")]
	public class TextMeshProInputAppend : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TMP_InputField))]
		[Tooltip("Textmesh Pro Input component is required.")]
		public FsmOwnerDefault gameObject;

		public FsmString toAppend;
		private TMP_InputField _inputField;

		public override void Reset()
		{
			gameObject = null;
			toAppend = null;
		}

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			_inputField = go.GetComponent<TMP_InputField>();
			if (go == null)
			{
				return;
			}

			if (_inputField == null)
			{
				Debug.LogError("No input field component was found on " + go);
				return;
			}

			_inputField.text += toAppend.Value;

			Finish();
		}


	}

}
