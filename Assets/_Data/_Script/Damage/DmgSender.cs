using System;
using UnityEngine;

public class DmgSender : GameMonoBehaviour
{
    [SerializeField] protected int dmg = 1;
    public virtual void SetDmg(int dmg)
    {
        this.dmg = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DmgReceiver>(out DmgReceiver component))
        {
            component.Deduct(dmg);
        }
    }

}
