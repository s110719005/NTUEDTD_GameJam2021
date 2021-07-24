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

        List<Skill> skills = new List<Skill>();
        private void Start()
        {
            skills.Add(new SkillRotate(90));
            skills.Add(new SkillRotate(180));
            skills.Add(new SkillRotate(-90));
        }
        public void TriggerSkill(int index)
        {
            selectedSkill = index;
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
                else
                {
                    if (MovementManager.Instance.currentRound == 1)
                    {
                        //Debug.Log($"{target.collider.transform.parent.name}");
                        skills[selectedSkill].Use(MovementManager.Instance.Player1.transform);
                    }
                    else
                    {
                        //Debug.Log($"{target.collider.transform.parent.name}");
                        skills[selectedSkill].Use(MovementManager.Instance.Player2.transform);
                    }
                    selectedSkill = -1;
                }
            }
        }
    }

}