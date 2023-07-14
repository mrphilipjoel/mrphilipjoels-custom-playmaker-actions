//created by ChatGPT using prompts from mrphilipjoel in discord on 6/29/23
using UnityEngine;
using Photon.Pun;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Network)]
    [Tooltip("Change the region in PhotonServerSettings.AppSettings.")]
    public class SetPhotonRegion : FsmStateAction
    {
        [Tooltip("The region for connecting to Photon Cloud.")]
        public FsmString region;

        public override void Reset()
        {
            region = null;
        }

        public override void OnEnter()
        {
            if (PhotonNetwork.PhotonServerSettings == null || PhotonNetwork.PhotonServerSettings.AppSettings == null)
            {
                Debug.LogError("PhotonServerSettings or AppSettings not found!");
                Finish();
                return;
            }

            var appSettings = PhotonNetwork.PhotonServerSettings.AppSettings;

            // Change the region in AppSettings based on the provided FSM variable
            if (!region.IsNone) appSettings.FixedRegion = region.Value;

            Finish();
        }
    }
}
