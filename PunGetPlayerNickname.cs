// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License


using Photon.Realtime;
using Photon.Pun;

namespace HutongGames.PlayMaker.Pun2.Actions
{
	[ActionCategory("Photon")]
	[Tooltip("Get built in and custom properties of a Photon player.")]
	[HelpUrl("")]
	public class PhotonNetworkGetPlayerNickname : PunActionBase
    {

        [Tooltip("The Photon player")]
        [RequiredField]
        public PlayerReferenceProperty player;

        [ActionSection("Builtin Properties")]
		[Tooltip("The player's NickName")]
		[UIHint(UIHint.Variable)]
		public FsmString nickname;

		private Player _player;

		public override void Reset()
		{
            nickname = null;

		}

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

            if (!nickname.IsNone) nickname.Value = _player.NickName;
		}
		
	}
}