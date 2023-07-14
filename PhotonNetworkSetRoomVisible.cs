using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace HutongGames.PlayMaker.Pun2.Actions
{

	[ActionCategory("Photon")]
	public class PhotonNetworkSetRoomOpenVisible : PunActionBase
	{

		public FsmBool isVisible;
		public FsmBool isOpen;

		private Player _player;

		// Code that runs on entering the state.
		public override void OnEnter()
		{
			ExecuteAction();
			Finish();
		}

		void ExecuteAction()
        {
			_player = player.GetPlayer(this);

			if (_player == null)
			{
				return;
			}

			customPropertiesValue.Value = (string)_player.CustomProperties[customPropertyKey.Value];
		}


	}

}
