using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour {

    [Tooltip("The options menu will provide further settings to the user.")]
    public GameObject OptionsMenu;

    [Tooltip("This will encompass the playscape panel.")]
    public GameObject TopPanel;

	// Use this for initialization
	void Start () {
        OptionsMenu.SetActive(false);
        TopPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OpenOptionsButtonPress()
    {
        OptionsMenu.SetActive(true);
        TopPanel.SetActive(false);
    }

    public void CloseOptionsButtonPress()
    {
        OptionsMenu.SetActive(false);
        TopPanel.SetActive(true);
    }
}
