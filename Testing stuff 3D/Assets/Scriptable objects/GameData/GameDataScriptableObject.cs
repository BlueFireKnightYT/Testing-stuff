using UnityEngine;

[CreateAssetMenu(fileName = "GameDataScriptableObject", menuName = "Scriptable Objects/GameDataScriptableObject")]
public class GameDataScriptableObject : ScriptableObject
{
    public int playerScore;
    public string playerName;
}
