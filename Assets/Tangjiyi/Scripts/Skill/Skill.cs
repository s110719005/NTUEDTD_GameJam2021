using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SkillSystem
{

    public abstract class Skill
    {
        public abstract void Use(Transform t);
        public abstract void MapUse(Transform target,float angle);
    }

}