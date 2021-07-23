using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MapSystem
{

    public class Map : MonoBehaviour
    {
        public static Map instance = null;
        public static Map Instance
        {
            get { return instance ?? (instance = FindObjectOfType(typeof(Map)) as Map); }
        }
        public float gameDeltaTime;
        private void Awake()
        {
            instance = Map.Instance;
            if (instance == null) instance = this as Map;
            if (instance == this) DontDestroyOnLoad(this);
            else DestroyImmediate(this);
        }

        public Dictionary<(int, int), MapSection> mapSections = new Dictionary<(int, int), MapSection>();

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                MapSection sec = transform.GetChild(i).GetComponent<MapSection>();
                (sec.gridX, sec.gridY) = GetSectionGridPosFormWorldPos(sec.transform.position);
                mapSections.Add((sec.gridX, sec.gridY), sec);
            }
        }

        public void Rotate(float eulerAngle)
        {
            transform.Rotate(0f, 0f, eulerAngle);
            //awdwd
        }

        public void SwapSectionByWorldPos(Vector2 target1, Vector2 target2)
        {
            if (!mapSections.ContainsKey(GetSectionGridPosFormWorldPos(target1)) || !mapSections.ContainsKey(GetSectionGridPosFormWorldPos(target2)))
            {
                Debug.Log("Target not exits mate.");
                return;
            }
            //swap pos
            mapSections[GetSectionGridPosFormWorldPos(target1)].transform.position = target2;
            mapSections[GetSectionGridPosFormWorldPos(target2)].transform.position = target1;

            //update key
            MapSection sec = mapSections[GetSectionGridPosFormWorldPos(target1)];
            mapSections[GetSectionGridPosFormWorldPos(target1)] = mapSections[GetSectionGridPosFormWorldPos(target2)];
            mapSections[GetSectionGridPosFormWorldPos(target1)] = sec;
        }

        public void SwapSectionByGridPos(int gridX1, int gridY1, int gridX2, int gridY2)
        {
            if (!mapSections.ContainsKey((gridX1, gridY1)) || !mapSections.ContainsKey((gridX2, gridY2)))
            {
                Debug.Log("Target not exits mate.");
                return;
            }
            //swap pos
            Vector2 pos = mapSections[(gridX1, gridY1)].transform.position;
            mapSections[(gridX1, gridY1)].transform.position = mapSections[(gridX2, gridY2)].transform.position;
            mapSections[(gridX2, gridY2)].transform.position = pos;

            //update key
            MapSection sec = mapSections[(gridX1, gridY1)];
            mapSections[(gridX1, gridY1)] = mapSections[(gridX2, gridY2)];
            mapSections[(gridX2, gridY2)] = sec;
        }

        #region Grid position covert
        public static (int, int) GetSectionGridPosFormWorldPos(Vector2 pos)
        {
            return ((int)pos.x / 2, (int)pos.y / 2);
        }
        #endregion
    }

}