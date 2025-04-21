using UnityEngine;

public class SMGDebug
{
    const string msgHead = "[MyDebug]";
    public static void Log(string msg)
    {
        Debug.Log(msgHead + msg);
    }

    public static void Warning(string msg)
    {
        Debug.LogWarning(msgHead + msg);
    }

    public static void sad(string msg)
    {
        Debug.LogError(msgHead + msg);
    }
}
