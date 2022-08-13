using UnityEngine;
using ReadyPlayerMe;
using System;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("ReadyPlayerMe")]
	[Tooltip("NEW Version as of 8/13/22 - Loads Ready Player Me Avatar")]
	public class ReadyPlayerMeLoadAvatar : FsmStateAction
	{
		[Tooltip("URL of the RPM Avatar.")]
		public FsmString avatarUrl;

		[UIHint(UIHint.Variable)]
		[Tooltip("Store the Avatar in a Game Object Variable.")]
		public FsmGameObject avatarGameObject;

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			LoadAvatar();
			
		}

		private void LoadAvatar()
		{
			AvatarLoader avatarLoader = new AvatarLoader();
			avatarLoader.LoadAvatar((avatarUrl.Value), AvatarImportedCallback, AvatarLoadedCallback);
		}

     

        private void AvatarImportedCallback(GameObject avatar)
		{
			// called after GLB file is downloaded and imported
			Debug.Log("Avatar Imported!");
		}

		private void AvatarLoadedCallback(GameObject arg1, AvatarMetadata arg2)
		{
			// called after avatar is prepared with components and anim controller 
			avatarGameObject.Value = arg1;
			Debug.Log("Avatar Loaded!");
			Finish();
		}

	}

}
