using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

namespace Lander.Actions
{
	[ActionCategory(ActionCategory.Physics)]
	[Tooltip("Set a Rigidbody rotation. It's more efficient then accessing the transform of the gameObject.")]
	public class SetRigidbodyRotationZ : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Rigidbody))]
		[Tooltip("The rigid body to rotate.")]
		public FsmOwnerDefault gameObject;

		public FsmFloat z;

		private GameObject go;
		

		[Tooltip("Repeat every frame.")]
		public bool everyFrame;
		
		private Rigidbody rigidBody;
		
		public override void Reset()
		{
			gameObject = null;
			z = null;
			everyFrame = true;
		}
		
		public override void OnPreprocess()
        {
            Fsm.HandleFixedUpdate = true;
        }
		
		public override void OnEnter()
		{

			go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				LogError("Missing gameObject target");
				return;
			}
			
			rigidBody = go.GetComponent<Rigidbody>();
			if (rigidBody == null)
			{
				LogError("Missing Rigidbody component");
				return;
			}
				
		}

        public override void OnFixedUpdate()
        {
            DoRotation();
           
            if (!everyFrame)
            {
                Finish();
            }
        }

		void DoRotation()
		{
			if (rigidBody != null && z != null)
			{
				var rotation = go.transform.eulerAngles;

				Vector3 angles = new Vector3();
				angles.x = rotation.x;
				angles.y = rotation.y;
				angles.z = z.Value;
				Quaternion quat = Quaternion.Euler(angles);
				quat = quat.normalized;
				rigidBody.rotation = quat;
			}
		}

	}
}
