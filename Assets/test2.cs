using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : test
{
    public override void SayHi()
    {
        counter += 1;
        print("merhaba");
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SayHi();
        }
    }
}
