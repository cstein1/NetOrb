using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }

    private void Awake()
    {
        print("Instance Created");
        Instance = this;
        PlayerName = "Pingu#" + Random.Range(1000, 9999);
    }
}
