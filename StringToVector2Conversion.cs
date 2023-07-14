using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory(ActionCategory.Convert)]
	public class StringToVector2Conversion : FsmStateAction
	{
		public FsmString vector2String;
		[UIHint(UIHint.Variable)]
		public FsmVector2 vector2;

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			GetVector2();
			Finish();
		}

		private void GetVector2()
		{
			Debug.Log(vector2String.Value);
			string[] temp = vector2String.Value.Substring(1, vector2String.Value.Length - 2).Split(',');
			float x = float.Parse(temp[0]);
			float y = float.Parse(temp[1]);
			vector2.Value = new Vector2(x, y);
		}


	}

}
