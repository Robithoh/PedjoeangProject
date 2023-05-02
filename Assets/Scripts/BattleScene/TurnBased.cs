using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBased : MonoBehaviour
{
    [SerializeField] private Transform pfPangDip;
    [SerializeField] private Transform pfTroops;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnCharacter(true);
        SpawnCharacter(false);
    }

    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 position;
        Quaternion rotation;
        if (isPlayerTeam)
        {
            position = new Vector3(-3, 0);
            rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            Instantiate(pfPangDip, position, rotation);
        }
        else
        {
            position = new Vector3(3, 0);
            rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            Instantiate(pfTroops, position, rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
