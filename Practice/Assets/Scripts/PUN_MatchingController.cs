using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon;

public class PUN_MatchingController : Photon.PunBehaviour {

	void Start(){
		PhotonNetwork.ConnectionSettings("0.1");
		PhotonNetwork.logLevel = Photon.logLevel.Full;
	}

	void OnGUI()
	{
		GUILayout.Lavel(PhotonNetwork.connectionStateDetailed.ToString());
	}

	public override void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
	{
		PhotonNetwork.CreateRoom(null);
	}
}