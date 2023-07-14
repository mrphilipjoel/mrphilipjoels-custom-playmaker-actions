//mrphilipjoel#0074 on Discord. May 23, 2023

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
using HutongGames.PlayMaker;

namespace GooglyEyesGames
{
    [ActionCategory("PlayerInput")]
    [Tooltip("mrphilipjoel's version of InputActionPerformed")]
    public class InputActionPerformed : FsmStateAction
    {
        [RequiredField]
        [ObjectType(typeof(InputActionReference))]
        [Tooltip("An InputAction used by the PlayerInput component.")]
        public FsmObject inputAction;

        [Tooltip("The event to send on Input Performed")]
        public FsmEvent sendEvent;

        private InputActionReference reference;
        private InputAction action;

        public override void Reset()
        {
            sendEvent = null;
        }

        public override void OnEnter()
        {
            reference = inputAction.Value as UnityEngine.InputSystem.InputActionReference;
            action = reference.action;
            action.performed += OnPerformed;
        }
        private void OnPerformed(InputAction.CallbackContext ctx)
        {
            Fsm.Event(sendEvent);
        }
    }
}

#endif
