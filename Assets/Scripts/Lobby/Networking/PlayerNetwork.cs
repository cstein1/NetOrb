using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
    private PhotonView PhotonView;

    private int PlayersInGame = 0;

    private void Awake()
    {
        
        print("Instance Created");
        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        PlayerName = "Pingu#" + Random.Range(1000, 9999);

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
    }

    //Photon Callback
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Game")
        {
            if (PhotonNetwork.isMasterClient)
            {
                MasterLoadedGame();
            } else
            {
                NonMasterLoadedGame();
            }
        }
    }

    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(1);
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        PlayersInGame++;
        if(PlayersInGame == PhotonNetwork.playerList.Length) // All Players In Game
        {
            print("Game Scene now has full room of players");
            //PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.All); // This will have to draw people cards?
        }
    }

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        
        //PhotonNetwork.Instantiate(Path.Combine("Prefabs", "NewPlayer"), Vector3.up, Quaternion.identity, 0);
    }
}
