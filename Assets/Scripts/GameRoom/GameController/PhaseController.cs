using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseController : Photon.MonoBehaviour {

    public enum Phase
    {
        SELECT, ZIP, EXECUTION, END, CLEANUP
    };

    public Phase CurrentPhase;

    [SerializeField]
    Toggle OpponentReady;

    [SerializeField]
    Toggle PlayerReady;

    [SerializeField]
    GameObject deck;

    [SerializeField]
    GameObject hand;

    [SerializeField]
    GameObject mat;

    [SerializeField]
    Text PhaseName;

    // Use this for initialization
    void Start() {
        CurrentPhase = Phase.SELECT;
        PhaseName.text = "Select";
        for (int i = 0; i < 5; i++) DrawCard();
    }

    #region
    public void ChangeToNextPhase()
    {
        switch (CurrentPhase)
        {
            case Phase.SELECT:
                MoveFromSelect();
                return;
            case Phase.ZIP:
                MoveFromZip();
                return;
            case Phase.EXECUTION:
                MoveFromExecution();
                return;
            case Phase.END:
                MoveFromEnd();
                return;
            case Phase.CLEANUP:
                MoveFromCleanup();
                return;
        }
    }


    private void MoveFromSelect() { CurrentPhase = Phase.ZIP; PhaseName.text = "Zip"; }
    private void MoveFromZip() { CurrentPhase = Phase.EXECUTION; PhaseName.text = "Execution"; }
    private void MoveFromExecution() { CurrentPhase = Phase.END; PhaseName.text = "End"; }
    private void MoveFromEnd() { CurrentPhase = Phase.CLEANUP; PhaseName.text = "Cleanup"; }
    private void MoveFromCleanup() { CurrentPhase = Phase.SELECT; DrawCard(); PhaseName.text = "Select"; }
    #endregion
    #region Deck Manipulation
    public void DrawCard()
    {
        if(deck.transform.childCount > 0)
        {
            deck.transform.GetChild(0).SetParent(hand.transform);
        }
    }
    #endregion
    #region SELECT PHASE
    public void OnBothPlayersReady()
    {
        if (OpponentReady.isOn && PlayerReady.isOn)
        {
            ChangeToNextPhase();
        }
    }
    #endregion
}
