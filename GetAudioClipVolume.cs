using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory(ActionCategory.Audio)]
	[Tooltip("Gets the volume of an audio clip.")]
	public class GetAudioClipVolume : FsmStateAction
	{
		[ObjectType(typeof(AudioClip))]
		[Tooltip("The AudioClip to assign to the AudioSource.")]
		public FsmObject audioClip;

		public FsmFloat volume;

		public override void OnUpdate()
        {
			volume.Value = ((audioClip.Value as AudioClip).samples * (audioClip.Value as AudioClip).channels);
		}


	}

}
