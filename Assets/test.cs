using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int counter = 0;

    public delegate void TestCallback();
    public TestCallback testCallback;

    public delegate int TestINTCallback(int amount);
    public TestINTCallback testINTCallback;


    // Start is called before the first frame update
    void Start()
    {
        if(testCallback != null)
        {
            testCallback();
        }

        if(testINTCallback != null)
        {
            int tmp = testINTCallback.Invoke(3);
            print(tmp);
        }

        print("Parent Object");
        test4.instance.SingletonTest();
        // SayHi();
        // print(counter);
    }

    public virtual void SayHi()
    {
        Debug.Log("this is parent");
    }
}
