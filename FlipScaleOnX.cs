// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.SpriteRenderer)]
	[Tooltip("Sets the Flips values of a of a SpriteRenderer component.")]
	public class FlipScaleOnX : ComponentAction<SpriteRenderer>
	{

		public FsmOwnerDefault gameObject;

		[Tooltip("The X Flip value")]
		public FsmBool toFlip;

		public bool everyFrame;
		private bool isFlipped;
		private bool isFlippedBack = true;

		public override void Reset()
		{
			toFlip = false;
			isFlippedBack = true;
		}

		public override void OnEnter()
		{
			if (!UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
			{
				return;
			}

			FlipScale();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			FlipScale();
		}

		void FlipScale()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);

			if (toFlip.Value)
            {
				if (isFlipped == false)
                {	//flip left
					Vector3 currentScale = go.transform.localScale;
					go.transform.localScale = new Vector3(currentScale.x * -1f, currentScale.y, currentScale.z);
					isFlipped = true;
					isFlippedBack = false;
				}
            }
			else
            {
				if (isFlippedBack == false)
                {
					Vector3 currentScale = go.transform.localScale;
					go.transform.localScale = new Vector3(currentScale.x * -1f, currentScale.y, currentScale.z);
                    isFlippedBack = true;
					isFlipped = false;

                }

            }
		}
	}
}
