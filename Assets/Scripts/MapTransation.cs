using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MapTran : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] float additivePos = 1.75f;
    enum Direction { UP, DOWN, LEFT, RIGHT }

    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPositionPlayer(collision.gameObject);
        }

    }

    private void UpdatePlayerPositionPlayer(GameObject player)
    {
        Vector3 newPos = player.transform.position;
        switch (direction)
        {
            case Direction.UP:
                newPos.y += additivePos;
                break;
            case Direction.DOWN:
                newPos.y -= additivePos;
                break;
            case Direction.LEFT:
                newPos.x -= additivePos;
                break;
            case Direction.RIGHT:
                newPos.x += additivePos;
                break;
        }

        player.transform.position = newPos;
        if (player.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.position = newPos;
        }
    }
}
