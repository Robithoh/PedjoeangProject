using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject
{
    public Vector3 charPos;
    public bool isNextScene = false;

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
