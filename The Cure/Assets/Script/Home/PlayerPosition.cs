using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Transform player;
    private float posX;
    private float posY;
    void Awake()
    {
        posX = PlayerPrefs.GetFloat("playerPosX", player.transform.position.x);
        posY = PlayerPrefs.GetFloat("playerPosY", player.transform.position.y);
        player.transform.position = new Vector2(posX, posY);
    }
}
