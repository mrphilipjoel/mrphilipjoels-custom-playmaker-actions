using HutongGames.PlayMaker.Pun2;
using Photon.Realtime;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Photon")]
	public class PunGetFriendsOnlineStatus : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The Playmaker Photon Proxy")]
		public FsmGameObject proxy;

		[RequiredField]
		[Tooltip("Online Status of Friends. ")]
		[UIHint(UIHint.Variable)]
		[ArrayEditor(VariableType.Bool)]
		public FsmArray onlineStatus;

		[RequiredField]
		[Tooltip("Room name if in one.")]
		[UIHint(UIHint.Variable)]
		[ArrayEditor(VariableType.String)]
		public FsmArray roomName;


		// Code that runs on entering the state.
		public override void OnEnter()
		{
			var friendList = (proxy.Value).GetComponent<PlayMakerPunCallbacksProxy>().LastFriendList;
			foreach (FriendInfo info in friendList)
			{
				//setting online status
				onlineStatus.Resize(onlineStatus.Length + 1);
				onlineStatus.Set(onlineStatus.Length - 1, info.IsOnline);

				//setting room names
				roomName.Resize(roomName.Length + 1);
				roomName.Set(roomName.Length - 1, info.Room);

			}
			Finish();
		}


	}

}
