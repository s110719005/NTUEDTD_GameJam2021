using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
namespace SkillSystem
{

    public class SkillManager : MonoBehaviour
    {
        static SkillManager instance = null;
        public static SkillManager Instance
        {
            get { return instance ?? (instance = FindObjectOfType(typeof(SkillManager)) as SkillManager); }
        }
        private void Awake()
        {
            instance = SkillManager.Instance;
            if (instance == null) instance = this as SkillManager;
            if (instance == this) DontDestroyOnLoad(this);
            else DestroyImmediate(this);
        }
        int selectedMapSkill = -1;
        //This is bad, but i think this is fine;
        float angle;
        public void UseMapSkill(int index, float angle)
        {
            selectedMapSkill = index;
            this.angle = angle;
        }
        public List<Skill> skills = new List<Skill>();
        public List<Skill> mapSkills = new List<Skill>();
        private void Start()
        {
            skills.Add(new SkillRotate(90));
            skills.Add(new SkillRotate(-90));
            skills.Add(new SkillRotate(180));
            mapSkills.Add(new SkillPlaceTrap("PushTrap"));
            mapSkills.Add(new SkillPlaceTrap("SwapTrap"));
        }

        private void Update()
        {
            if (selectedMapSkill != -1 && Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("Floor"));
                if (hit.transform == null) return;
                Debug.Log(hit.transform.name);
                mapSkills[selectedMapSkill].MapUse(hit, angle);
                selectedMapSkill = -1;
            }


        }
    }

}