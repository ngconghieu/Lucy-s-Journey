using System;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite closedChest;
    public Sprite openedChest;
    protected SpriteRenderer spriteRenderer;
    private bool isOpened = false;
    public List<DropItem> dropList;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedChest;
    }

    private void OpenChest()
    {
        isOpened = true;
        spriteRenderer.sprite = openedChest;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log(collision.transform.tag);
            if (Input.GetKey(KeyCode.E) && !isOpened)
            {
                OpenChest();
                
                DropManager.Instance.Drop(dropList, transform.position);
                
            }
                
        }
    }
}
