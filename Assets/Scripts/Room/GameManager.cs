using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


namespace Com.StinkyBrotherStudio.Orbu
{
    public class GameManager : Photon.PunBehaviour
    {

        #region Photon Messages


        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        override public void OnLeftRoom()
        {
            LeaveRoom();
            SceneManager.LoadScene(0);
            
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName); // seen when other disconnects

            LeaveRoom();
            SceneManager.LoadScene(0);
           
        }


        #endregion


        #region Public Methods


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }


        #endregion
    }
}