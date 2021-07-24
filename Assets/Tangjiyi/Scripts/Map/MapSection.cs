using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MapSystem
{

    public class MapSection : MonoBehaviour
    {
        public Vector2Int gridPos;
        public void Rotate(float eulerAngle)
        {
            transform.Rotate(0f, 0f, eulerAngle);
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform ct = transform.GetChild(i);
                if (ct.tag == "Trap")
                {
                    switch (eulerAngle)
                    {
                        case 90f:
                            ct.GetComponent<Trap>().direction+=3;
                            break;
                        case -90f:
                            ct.GetComponent<Trap>().direction ++;
                            break;
                        case 180f:
                            ct.GetComponent<Trap>().direction += 2;
                            break;

                    }
                }
            }
        }
        /// <summary>
        /// Swap position with target
        /// </summary>
        /// <param name="gridX">target gridX</param>
        /// <param name="gridY">target gridY</param>

    }
}