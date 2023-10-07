using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OnCollect : UnityEvent { }

public class CollectibleGameObject : MonoBehaviour
{
    [SerializeField]
    private Collider2D CCollider;
    public OnCollect collectEvent;

    [SerializeField]
    protected int collectibleId;
    [SerializeField]
    protected int collectiblePositionX;
    [SerializeField]
    protected int collectiblePositionY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collectEvent.Invoke();
        }
    }
}