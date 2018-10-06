using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayoutGroup : MonoBehaviour {

    [SerializeField]
    private GameObject _playerListingPrefab;
    private GameObject PlayerListingPrefab
    {
        get { return _playerListingPrefab; }
    }

    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> PlayerListings
    {
        get { return _playerListings; }
    }

    //Called by Photon whenever YOU join room
    private void OnJoinedRoom()
    {
        MainCanvasManager.Instance.CurrentRoomCanvas.transform.SetAsLastSibling();

        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
        for(int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }
    
    //Called by Photon when ANY player leaves room
    private void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = PlayerListings.FindIndex(x => x.photonPlayer == photonPlayer);
        if(index != -1)
        {
            Destroy(PlayerListings[index].gameObject);
            PlayerListings.RemoveAt(index);
        }
    }
    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null) { return; }

        PlayerLeftRoom(photonPlayer);

        GameObject playerListingObj = Instantiate(PlayerListingPrefab);
        playerListingObj.transform.SetParent(this.transform, false);

        PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPlayer(photonPlayer);

        PlayerListings.Add(playerListing);
    }
}
