using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace HutongGames.PlayMaker.Pun2.Actions
{

	[ActionCategory("Photon")]
	public class PhotonNetworkGetCustomRoomProperty : PunActionBase
	{
		
		public FsmString customPropertyKey;
		[UIHint(UIHint.Variable)]
		public FsmString customPropertyValue;

		public override void OnEnter()
		{
			ExecuteAction();
			Finish();
		}

		void ExecuteAction()
        {
			ExitGames.Client.Photon.Hashtable table = new ExitGames.Client.Photon.Hashtable();
			table = Photon.Pun.PhotonNetwork.CurrentRoom.CustomProperties;
			customPropertyValue.Value = table[customPropertyKey.Value].ToString();
		}


	}

}
