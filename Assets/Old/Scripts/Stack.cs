using UnityEngine;
using System.Collections;

public class Stack : MonoBehaviour
{
    public GameObject[] stck;
    public int tos;

    public Stack()
    {
        
    }

    public Stack(int size)
    {
        stck = new GameObject[size];
        tos = 0;
    }

    public void Push(GameObject obj)
    {
        if (tos>=stck.Length)
        {
            Debug.Log("Стек заполнен");
            return;
        }
        stck[tos] = obj;
        tos++;
    }

    public GameObject Pop()
    {
        if (tos<=0)
        {
            Debug.Log("Стек пуст");
            return null;
        }
        tos--;
        return stck[tos];
    }
}
