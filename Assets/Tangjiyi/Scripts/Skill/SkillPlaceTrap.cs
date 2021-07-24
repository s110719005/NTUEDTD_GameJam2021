using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
namespace SkillSystem
{
    public class SkillPlaceTrap : Skill
    {
        List<Collider2D> traps = new List<Collider2D>();
        public SkillPlaceTrap()
        {
            MovementManager.Instance.OnRoundStartEvent -= TrapsEnable;
            MovementManager.Instance.OnRoundStartEvent += TrapsEnable;
        }
        public override void MapUse(RaycastHit2D hit)
        {
            Vector2 pos = hit.transform.position;
            pos.x = ((int)pos.x) + 0.5f;
            pos.y = ((int)pos.y) + 0.5f;
            GameObject trap = Resources.Load<GameObject>("PushTrap");
            trap.transform.position = pos;
            trap.transform.SetParent(Map.Instance.mapSections[Map.GetSectionGridPosFromWorldPos(pos)].transform);
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
    }
}
