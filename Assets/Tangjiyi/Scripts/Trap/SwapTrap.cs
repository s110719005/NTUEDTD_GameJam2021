using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
public class SwapTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RaycastHit2D target = Physics2D.Raycast(transform.position, Vector2.zero, 1, 1 << LayerMask.NameToLayer("Floor"));
        if (!target)
        {
            Debug.Log("Walking on the walls huh? Feeling fancy today don't ya?");
            return;
        }
        Debug.Log($"{target.collider.transform.parent.name}");
        MapSection section = target.transform.GetComponentInParent<MapSection>();
        Map.Instance.SwapSectionByGridPos(section.gridPos, section.gridPos + new Vector2Int((int)transform.up.x, (int)transform.up.y));
        //Destroy(gameObject);
    }
}
