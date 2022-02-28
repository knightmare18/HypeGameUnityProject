using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3L3 : MonoBehaviour
{
    public int myInteger = 5;
    public float myFloat = 3.5f;
    public bool myBool = true;
    public string myString = "Hello World";
    public int[] myArrayOfInts;

    private int _myInt = 10;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("let's sum 10 to myInteger. Right now its value is " + myInteger);
        myInteger += 10;
        Debug.Log("After the sum, the value is " + myInteger);

        IsEven(myInteger);

        if (IsEven(myInteger))
        {
            MyDebug("myInteger is even");
        }
        else
        {
            MyDebug("myInteger is odd");
        }

        if (myFloat >= 2F)
        {
            MyDebug("myFloat is greather or equal than 2");
        }
        if (IsEven(_myInt) && _myInt == 10)
        {
            MyDebug("_myInt is 10");
        }
        if (IsEven(myInteger) || IsEven(_myInt))
        {
            MyDebug("any of the two variables is ok to me and want to execute some code");
        }

        //flow control

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }

        for (int i = 0; i < myArrayOfInts.Length; i++)
        {
            Debug.Log(myArrayOfInts[i]);
        }

        SpriteRenderer mySpriteRenderer = GetComponent<SpriteRenderer>();

        if(mySpriteRenderer != null)
        {
            MyDebug("I can use mySpriteRenderer");
        }
        else
        {
            mySpriteRenderer.enabled = false;
            MyDebug("The Game will crash if you try to use the component!");
        }

        GameObject anObjectWithSpriteRenderer = FindObjectOfType<SpriteRenderer>().gameObject;

        GameObject anObjectWithTag = GameObject.FindWithTag("Player");

        GameObject anObjectWithName = GameObject.Find("Whatever name you now");

        if (anObjectWithName != null)
        {
            anObjectWithName.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool IsEven(int num)
    {
        if (num % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }
    void MyDebug(string message)
    {
        Debug.Log(message);
    }
}