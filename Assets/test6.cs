using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test6 
{
    public string className = "test6";
    public int classNo = 6;

    public test6(string className, int classNo)
    {
        this.className = className;
        this.classNo = classNo;
    }

    public void Info()
    {
        Debug.Log($"My class name is {this.className} and my class number is {this.classNo}.");
    }
}
