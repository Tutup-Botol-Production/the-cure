using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    private float scale = .8f;
    public void mouseDown()
    {
        gameObject.GetComponent<Transform>().localScale = new Vector2(scale, scale);
    }

    public void mouseUp()
    {
        gameObject.GetComponent<Transform>().localScale = new Vector2(1, 1);
    }
}
