// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using Photon.Pun;
using Photon.Realtime;

namespace HutongGames.PlayMaker.Pun2.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Get the room we are currently in. If null, we aren't in any room.")]
	[HelpUrl("")]
	public class PunGetPlayersInRoom : PunActionBase
	{
		
		
		[UIHint(UIHint.Variable)]
		[Tooltip("the number of players inthe room.")]
		public FsmInt playerCount;
		
		
		public override void Reset()
		{
			playerCount = 0;
		}
		
		public override void OnEnter()
		{
			getRoomProperties();			
			Finish();
		}


        public void getRoomProperties()
        {
			Room _room = PhotonNetwork.CurrentRoom;
			playerCount.Value = _room.PlayerCount;
			Finish();
		}

	}
}