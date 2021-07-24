using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
namespace SkillSystem
{

    public class SkillRotate : Skill
    {
        int angle;


        public SkillRotate(int angle)
        {
            this.angle = angle;
        }

        public override void MapUse(RaycastHit2D hit,float angle)
        {
            throw new System.NotImplementedException();
        }

        public override void Use(Transform t)
        {
            RaycastHit2D target = Physics2D.Raycast(t.position, Vector2.zero, 1, 1 << LayerMask.NameToLayer("Floor"));
            //Debug.Log(t.name);
            t.SetParent(target.transform);
            target.transform.GetComponentInParent<MapSection>().Rotate(angle);
            t.parent = null;
            t.rotation = Quaternion.identity;
            // if (t.position.x > target.transform.position.x)
            // {
            //     if (t.position.y > target.transform.position.y)
            //     {
            //         switch (angle)
            //         {
            //             case 90:
            //                 MovementManager.Instance.AddAction(3);
            //                 break;
            //             case -90:
            //                 MovementManager.Instance.AddAction(1);
            //                 break;
            //             case 180:
            //                 MovementManager.Instance.AddAction(3);
            //                 MovementManager.Instance.AddAction(1);
            //                 break;
            //         }
            //     }
            //     else
            //     {
            //         switch (angle)
            //         {
            //             case 90:
            //                 MovementManager.Instance.AddAction(0);
            //                 break;
            //             case -90:
            //                 MovementManager.Instance.AddAction(3);
            //                 break;
            //             case 180:
            //                 MovementManager.Instance.AddAction(0);
            //                 MovementManager.Instance.AddAction(3);
            //                 break;
            //         }
            //     }
            // }
            // else
            // {
            //     if (t.position.y > target.transform.position.y)
            //     {
            //         switch (angle)
            //         {
            //             case 90:
            //                 MovementManager.Instance.AddAction(1);
            //                 break;
            //             case -90:
            //                 MovementManager.Instance.AddAction(2);
            //                 break;
            //             case 180:
            //                 MovementManager.Instance.AddAction(1);
            //                 MovementManager.Instance.AddAction(2);
            //                 break;
            //         }
            //     }
            //     else
            //     {
            //         switch (angle)
            //         {
            //             case 90:
            //                 MovementManager.Instance.AddAction(2);
            //                 break;
            //             case -90:
            //                 MovementManager.Instance.AddAction(0);
            //                 break;
            //             case 180:
            //                 MovementManager.Instance.AddAction(2);
            //                 MovementManager.Instance.AddAction(0);
            //                 break;
            //         }
            //     }
            // }

        }
    }

}