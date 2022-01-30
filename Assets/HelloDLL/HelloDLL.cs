using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloDLL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void SayHello()
    {
        Debug.LogWarning("SayHello888");
    }
}
