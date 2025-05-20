using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LauncherNetwork : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true; // Sync scenes across players
        PhotonNetwork.ConnectUsingSettings();        // Connect to Photon server
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon!");
        PhotonNetwork.JoinOrCreateRoom("MainRoom", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Photon Room: " + PhotonNetwork.CurrentRoom.Name);
    }
}