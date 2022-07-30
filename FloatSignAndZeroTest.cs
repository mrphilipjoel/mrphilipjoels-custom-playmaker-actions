// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Logic)]
	[Tooltip("Sends Events or sets bools based on the sign of a Float (positive or negative).")]
	public class FloatSignAndZeroTest : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("The float variable to test.")]
		public FsmFloat floatValue;

        [Tooltip("Event to send if the float variable is positive non-zero.")]
		public FsmEvent isPositiveNonZeroEvent;

		[Tooltip("Event to send if the float variable is zero.")]
		public FsmEvent isZeroEvent;

		[Tooltip("Event to send if the float variable is negative.")]
		public FsmEvent isNegativeEvent;

		[UIHint(UIHint.Variable)]
		public FsmBool isPositive;

		[UIHint(UIHint.Variable)]
		public FsmBool isZero;

		[UIHint(UIHint.Variable)]
		public FsmBool isNegative;

        [Tooltip("Repeat every frame. Useful if you want to wait until a float is positive/negative.")]
		public bool everyFrame;

		public override void Reset()
		{
			floatValue = 0f;
			isPositiveNonZeroEvent = null;
			isNegativeEvent = null;
			isZeroEvent = null;
			everyFrame = false;
			isPositive = false;
			isZero = false;
			isNegative = false;
		}

		public override void OnEnter()
		{
			DoSignTest();
			
			if (!everyFrame)
			{
			    Finish();
			}
		}

		public override void OnUpdate()
		{
			DoSignTest();
		}

		void DoSignTest()
		{
			if (floatValue == null)
			{
			    return;
			}
			
			if (floatValue.Value > 0)
            {
				isPositive.Value = true;
				Fsm.Event(isPositiveNonZeroEvent);
            }
			else if (floatValue.Value == 0)
            {
				isZero.Value = true;
				Fsm.Event(isZeroEvent);
            }
            else
            {
				isNegative.Value = true;
				Fsm.Event(isNegativeEvent);
            }
		}

	}
}