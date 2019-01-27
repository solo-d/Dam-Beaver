using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
public class NetworkManager : Photon.PunBehaviour
{

    public GameObject player;
 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Connection");
        PhotonNetwork.ConnectUsingSettings("1");
    }
    public override void OnJoinedLobby()
    {
        bool status = PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        Debug.Log(status);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        PhotonNetwork.Instantiate("Beaver-Final", player.transform.position, Quaternion.identity, 0);
    }

    void Update()
    {
        if (!PhotonNetwork.connected)
        {
            Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
        }
    }

    public override void OnConnectionFail(DisconnectCause cause)
    {
        Debug.Log("Fail To Connected");
        base.OnConnectionFail(cause);
    }
}
