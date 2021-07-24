using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MapSystem
{

    public class Map : MonoBehaviour
    {
        static Map instance = null;
        public static Map Instance
        {
            get { return instance ?? (instance = FindObjectOfType(typeof(Map)) as Map); }
        }
        private void Awake()
        {
            instance = Map.Instance;
            if (instance == null) instance = this as Map;
            if (instance == this) DontDestroyOnLoad(this);
            else DestroyImmediate(this);
        }
        //感謝學長大力支援!!
        public Dictionary<Vector2Int, MapSection> mapSections = new Dictionary<Vector2Int, MapSection>();

        private void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                MapSection sec = transform.GetChild(i).GetComponent<MapSection>();
                sec.gridPos = GetSectionGridPosFromWorldPos(sec.transform.position);
                mapSections.Add(sec.gridPos, sec);
            }
        }
        //TEMP
        public void Rotate(float eulerAngle)
        {
            transform.Rotate(0f, 0f, eulerAngle);
        }

        //DONT USE
        // public void SwapSectionByWorldPos(Vector2 target1, Vector2 target2)
        // {
        //     if (!mapSections.ContainsKey(GetSectionGridPosFromWorldPos(target1)) || !mapSections.ContainsKey(GetSectionGridPosFromWorldPos(target2)))
        //     {
        //         Debug.Log("Target not exits mate.");
        //         return;
        //     }
        //     //swap pos
        //     mapSections[GetSectionGridPosFromWorldPos(target1)].transform.position = target2;
        //     mapSections[GetSectionGridPosFromWorldPos(target2)].transform.position = target1;

        //     //update key
        //     MapSection sec = mapSections[GetSectionGridPosFromWorldPos(target1)];
        //     mapSections[GetSectionGridPosFromWorldPos(target1)] = mapSections[GetSectionGridPosFromWorldPos(target2)];
        //     mapSections[GetSectionGridPosFromWorldPos(target1)] = sec;
        // }

        public void SwapSectionByGridPos(Vector2Int target1, Vector2Int target2)
        {
            if (!mapSections.ContainsKey(target1) || !mapSections.ContainsKey(target2))
            {
                Debug.Log("Target not exits mate.");
                return;
            }
            //swap pos
            Vector2 pos = mapSections[target1].transform.position;
            mapSections[target1].transform.position = mapSections[target2].transform.position;
            mapSections[target2].transform.position = pos;

            //swap gridPos
            mapSections[target1].gridPos = target2;
            mapSections[target2].gridPos = target1;

            //update key
            MapSection sec = mapSections[target1];
            mapSections[target1] = mapSections[target2];
            mapSections[target2] = sec;

        }

        #region Grid position covert
        public static Vector2Int GetSectionGridPosFromWorldPos(Vector2 pos)
        {
            return new Vector2Int((int)pos.x / 2, (int)pos.y / 2);
        }
        #endregion
    }

}