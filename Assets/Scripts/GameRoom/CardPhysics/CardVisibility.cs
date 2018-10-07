using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisibility : Photon.MonoBehaviour {

    private PhotonView PhotonView;
    private bool isRevealed;

    private void Awake()
    {
        PhotonView = this.GetComponent<PhotonView>();
    }

    // Use this for initialization
    void Start()
    {
        isRevealed = false;
        if (!isRevealed && !PhotonView.isMine)
        {
            this.GetComponent<Image>().color = Color.gray;
        }
    }
}
