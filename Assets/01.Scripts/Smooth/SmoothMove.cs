using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public GameObject Smoothtext;
    public GameObject Player;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Wall")
        {
            Debug.Log("SMOOTH");
            Smoothtext.SetActive(true);


        }

    }
    private void Update()
    {
        transform.position = Player.transform.position; // �÷��̾� ��ġ�� ������Ʈ �̵�
    }
}
