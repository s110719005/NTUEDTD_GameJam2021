using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
public class SwapTrap : MonoBehaviour
{
    [SerializeField]
    private int xDistance, yDistance;
    private Vector2 direction;
    private void OnTriggerEnter2D(Collider2D other)
    {
        RaycastHit2D target1 = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("Wall"));
        Debug.Log($"{target1.collider.transform.parent.name}");
        MapSection section1 = target1.transform.GetComponentInParent<MapSection>();

        RaycastHit2D target2 = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, 1 << LayerMask.NameToLayer("Wall"));
        Debug.Log($"{target2.collider.transform.parent.name}");
        MapSection section2 = target2.transform.GetComponentInParent<MapSection>();
        //Map.Instance.SwapSectionByGridPos(section.gridX, section.gridY, section.gridX + xDistance, section.gridY + yDistance);
        //Destroy(gameObject);
    }
}
