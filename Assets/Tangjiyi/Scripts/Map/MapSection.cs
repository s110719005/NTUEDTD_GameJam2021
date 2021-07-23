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
        }
        /// <summary>
        /// Swap position with target
        /// </summary>
        /// <param name="gridX">target gridX</param>
        /// <param name="gridY">target gridY</param>

    }
}