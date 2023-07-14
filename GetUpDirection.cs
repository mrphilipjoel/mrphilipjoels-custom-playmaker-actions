//Created by Philip Herlitz. On Discord as mrphilipjoel#0074.

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Transform)]
    [Tooltip("Transforms a Direction from a Game Object's local space to world space.")]
    public class GetUpDirection : FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmVector3 upDirection;
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
         
            upDirection = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            DoTransformDirection();

            if (!everyFrame)
                Finish();
        }

        public override void OnUpdate()
        {
            DoTransformDirection();
        }

        void DoTransformDirection()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            upDirection.Value = go.transform.up;
        }
    }
}

