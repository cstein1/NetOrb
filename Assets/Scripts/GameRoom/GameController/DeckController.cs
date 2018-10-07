using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : Photon.MonoBehaviour {

    [SerializeField]
    public GameObject cardPrefab;

	private void Start()
    {
        for(int i = 0; i < 40; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.transform.SetParent(this.transform);
        }
    }
}
