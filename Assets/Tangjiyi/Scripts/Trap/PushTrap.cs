using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
public class PushTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RaycastHit2D target = Physics2D.Raycast(transform.position, transform.up, 20/*Map length is around 14*/, 1 << LayerMask.NameToLayer("Wall"));
        // Debug.Log($"{target2.collider.transform.parent.name}");
        Debug.Log(target.point);
        other.transform.position = target.point+target.normal/2;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}
