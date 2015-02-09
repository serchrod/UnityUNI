using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour
{   //destruye
    public float DestructTime = 2.0f;

    void Start()
    {
        Destroy(gameObject, DestructTime);
    }
}
