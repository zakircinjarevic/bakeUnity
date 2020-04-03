using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaHitCheck : MonoBehaviour
{
    public GameObject player;
    public GameObject shell;
    public Vector3 koopaPosition;
    void Start()
    {
        shell.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "groundCheck")
        {
            shell.GetComponent<Shell>().speed = 0f;
            koopaPosition = transform.parent.gameObject.transform.position;
            koopaPosition.y -= 0.5f;
            transform.parent.gameObject.SetActive(false);
            shell.transform.position = koopaPosition;
            shell.SetActive(true);
        }
    }
}
