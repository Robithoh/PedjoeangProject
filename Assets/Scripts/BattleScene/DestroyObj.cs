using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject gameObj;

    public void Update() {
        if(Input.GetKeyDown(KeyCode.W)){
            Destroy(gameObj);
        }
    }
}
