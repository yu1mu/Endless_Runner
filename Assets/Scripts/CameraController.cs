using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController Player;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    private void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = Player.transform.position;
    }

    private void Update()
    {
        distanceToMove = Player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = Player.transform.position;
    }
}
