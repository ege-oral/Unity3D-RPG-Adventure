using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : test
{

    private void Awake() {
        //SayHi();
        testCallback += Selam;
        testINTCallback += Selam_INT;
    }

    public override void SayHi()
    {
        base.SayHi();
        Debug.Log("this is child");
    }

    public void Selam()
    {
        print("selam");

    }

    public int Selam_INT(int i)
    {
        return i;
    }
}
