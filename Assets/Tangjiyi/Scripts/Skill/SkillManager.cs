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
        int selectedSkill = -1;
        //This is bad, but i think this is fine;
        public void UseMapSkill(int index)
        {
            selectedSkill = index;
        }
        public List<Skill> skills = new List<Skill>();
        private void Start()
        {
            skills.Add(new SkillRotate(90));
            skills.Add(new SkillRotate(-90));
            skills.Add(new SkillRotate(180));
        }

        private void Update()
        {
            if (selectedSkill != -1)
            {
                if (skills[selectedSkill].needToMapSelectMap && Input.GetMouseButtonDown(0))
                {


                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1 << LayerMask.NameToLayer("Floor"));
                    Debug.Log(hit.transform.name);
                    skills[selectedSkill].MapUse(hit);
                    selectedSkill = -1;
                }

            }
        }
    }

}