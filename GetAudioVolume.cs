// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Audio)]
	[Tooltip("Gets the Volume of the Audio Clip played by the AudioSource component on a Game Object.")]
	public class GetAudioVolume : ComponentAction<AudioSource>
	{
		[RequiredField]
		[CheckForComponent(typeof(AudioSource))]
        [Tooltip("A GameObject with an AudioSource component.")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Get the volume.")]
        public FsmFloat volume;

        [Tooltip("Repeat every frame. Useful if you're driving the volume with a float variable.")]
        public bool everyFrame;
		
		public override void Reset()
		{
			gameObject = null;
			volume = 1;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoSetAudioVolume();

		    if (!everyFrame)
		    {
		        Finish();
		    }
		}
		
		public override void OnUpdate ()
		{
			DoSetAudioVolume();
		}
		
		void DoSetAudioVolume()
		{
            if (UpdateCache(Fsm.GetOwnerDefaultTarget(gameObject)))
			{
			    if (!volume.IsNone)
			    {
			        volume.Value = audio.volume;
			    }
			}
		}

#if UNITY_EDITOR
	    public override string AutoName()
	    {
	        return ActionHelpers.AutoName(this, volume);
	    }
#endif

	}
}