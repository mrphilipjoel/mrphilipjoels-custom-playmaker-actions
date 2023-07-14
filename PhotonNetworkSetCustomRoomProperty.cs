using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace HutongGames.PlayMaker.Pun2.Actions
{

	[ActionCategory("Photon")]
	public class PhotonNetworkSetCustomRoomProperty : PunActionBase
	{
		
		public FsmString customPropertyKey;
		public FsmString customPropertyValue;

		public override void OnEnter()
		{
			ExecuteAction();
			Finish();
		}

		void ExecuteAction()
        {
			ExitGames.Client.Photon.Hashtable setValue = new ExitGames.Client.Photon.Hashtable();
			setValue.Add(customPropertyKey.Value, customPropertyValue.Value);
			PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
		}


	}

}
