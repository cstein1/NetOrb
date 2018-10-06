using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateRoom : MonoBehaviour {

    [SerializeField] private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public void OnClickCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("create room sent");
        } else
        {
            print("create room failed to send");
        }
    }

    public void OnPhotonCreateRoomFailed(object[] codeAndMsg)
    {
        print("Create Room failed: " + codeAndMsg[1]);
    }

    private void OnCreatedRoom()
    {
        print("Room Created Successful!");
    }
}
