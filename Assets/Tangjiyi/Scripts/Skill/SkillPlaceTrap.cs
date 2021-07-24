using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
namespace SkillSystem
{
    public class SkillPlaceTrap : Skill
    {
        private string trapPrefabName;
        public SkillPlaceTrap(string trapPrefabName)
        {
            this.trapPrefabName = trapPrefabName;
            MovementManager.Instance.OnRoundStartEvent -= TrapsEnable;
            MovementManager.Instance.OnRoundStartEvent += TrapsEnable;
        }
        List<Collider2D> traps = new List<Collider2D>();

        public override void MapUse(Transform target,float angle)
        {
            Debug.Log(trapPrefabName);
            Vector2 pos = target.position;
            pos.x = ((int)pos.x) + 0.5f;
            pos.y = ((int)pos.y) + 0.5f;
            GameObject trap = GameObject.Instantiate(
                Resources.Load<GameObject>(trapPrefabName)
                , pos
                , Quaternion.Euler(0,0,angle)
                , Map.Instance.mapSections[Map.GetSectionGridPosFromWorldPos(pos)].transform
            );
            // trap.transform.position = pos;
            // trap.transform.SetParent(Map.Instance.mapSections[Map.GetSectionGridPosFromWorldPos(pos)].transform);
            traps.Add(trap.GetComponent<Collider2D>());
            traps[traps.Count - 1].enabled = false;
        }

        public void TrapsEnable()
        {
            for (int i = 0; i < traps.Count; i++)
            {
                traps[i].enabled = true;
            }
            traps.Clear();
        }
        public override void Use(Transform t)
        {
            throw new System.NotImplementedException();
        }

        public override void Reset()
        {
            foreach (var item in traps)
            {
                GameObject.Destroy(item.gameObject);
            }
            traps.Clear();
        }
    }
}
