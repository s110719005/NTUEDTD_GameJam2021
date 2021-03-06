using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MapSystem;
public class PushTrap : Trap
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.position != transform.position) return;
        RaycastHit2D target = Physics2D.Raycast(transform.position, transform.up, 40/*Map length*/, 1 << LayerMask.NameToLayer("Wall"));
        // Debug.Log($"{target2.collider.transform.parent.name}");
        // Debug.Log(Vector2.Distance(transform.position, target.point))
        float dist = Vector2.Distance(transform.position, target.point);
        if (!(dist <= 1))
        {
            MovementManager.Instance.ForceAddDelay(dist / 4);
            other.transform.DOMove(target.point + target.normal / 2, dist / 4).SetEase(Ease.Linear);
            // Debug.Log("OH");
        }
        // other.transform.position = target.point + target.normal / 2;

        // MovementManager.Instance.AddAction(direction%4);
        Destroy(gameObject);
    }

}
