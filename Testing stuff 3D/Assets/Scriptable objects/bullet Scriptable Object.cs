using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "bulletScriptableObject", menuName = "Scriptable Objects/bulletScriptableObject")]
public class bulletScriptableObject : ScriptableObject
{
    public Material bulletMaterial;
    public string bulletName;
    public float bullerLifeTime;
    public float bulletVelocity;
    public int damage;
}
