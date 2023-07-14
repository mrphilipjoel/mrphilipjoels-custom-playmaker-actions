using UnityEngine;
using HutongGames.PlayMaker;

namespace Lander.Actions
{
	[ActionCategory(ActionCategory.Math)]

	public class QuatFromXYZ : FsmStateAction
	{
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		[UIHint(UIHint.Variable)]
		public FsmQuaternion quaternion;
		public bool everyFrame;

		public override void Reset()
		{
			x = null;
			y = null;
			z = null;
			quaternion = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoIt();
			if (!everyFrame)
            {
				Finish();
            }
		}

		public void DoIt()
        {
			Vector3 euler = new Vector3();
			euler.x = x.Value;
			euler.y = y.Value;
			euler.z = z.Value;
			quaternion.Value = Quaternion.Euler(euler);
		}
	}
}
