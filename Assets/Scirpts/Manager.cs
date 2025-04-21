using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance => instance;
    private static Manager instance;

    #region Manager
    public static CardManager Card => Instance._card;
    public static DataManager Data => Instance._data;


    private CardManager _card = new();
    private DataManager _data =new();

    #endregion

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Init();
    }

    private void Init()
    {
        _card = new();
        Card.Init();
        _data = new();

    }


    private void OnApplicationQuit()
    {
        SMGDebug.Log("[Quit Game] Play Time: " + Time.time);
    }
}
