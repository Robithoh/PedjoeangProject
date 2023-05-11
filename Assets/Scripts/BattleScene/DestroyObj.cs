using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject gameObj;

    void Start()
    {
        Destroy(gameObj, 3);
    }
}
