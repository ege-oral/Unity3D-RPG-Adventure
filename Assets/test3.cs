using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test3 : test
{
    private void Awake() 
    {
        testCallback += Merhaba;
        //SayHi();    
    }
    public override void SayHi()
    {
        base.SayHi();
        print("child 2");
    }

    public void Merhaba()
    {
        print("merhaba");
    }
}
