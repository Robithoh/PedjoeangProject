using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject
{
    public Vector3 charPos;
    public bool isNextScene = false;
    public List<string> listScene = new List<string>();
    public List<bool> listEnemy = new List<bool>();

    public void SaveCharPos(Vector3 pos)
    {
        charPos = pos;
    }

    public void OnEnable()
    {
        charPos = new Vector3(46.78f, 2.447f, -25.7f);
        isNextScene = false;
    }
}
