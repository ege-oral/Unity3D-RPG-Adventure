using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test4 : MonoBehaviour
{
    public static test4 instance {get; private set;}
    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }
    
    public void SingletonTest()
    {
        print("singleton testing");
    }
}
