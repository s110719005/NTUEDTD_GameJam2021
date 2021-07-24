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
        public void ResetMapSkills()
        {
            foreach (var item in mapSkills)
            {
                item.Reset();
            }
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
                Debug.Log("ClK");
                //get target pos
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0, 1 << (LayerMask.NameToLayer("Floor")));
                if (hit.transform == null)
                {
                    Debug.Log("Target Position Outsided");
                    selectedMapSkill = -1;
                    return;
                }
                //check if the pos is blocked
                RaycastHit2D[] block = Physics2D.RaycastAll(hit.transform.position, Vector2.zero);
                for (int i = 0; i < block.Length; i++)
                {
                    if (block[i].transform.tag == "Player" || block[i].transform.tag == "Wall" || block[i].transform.tag == "Trap")
                    {
                        Debug.Log("Target Position Blocked");
                        selectedMapSkill = -1;
                        return;
                    }
                }
                //this is bad but..angle.
                int actionId = 7;
                if (selectedMapSkill == 1) actionId = 11;
                switch (angle)
                {
                    case 0:
                        MovementManager.Instance.AddAction(actionId);
                        break;
                    case 180:
                        MovementManager.Instance.AddAction(actionId + 1);
                        break;
                    case -90:
                        MovementManager.Instance.AddAction(actionId + 2);
                        break;
                    case 90:
                        MovementManager.Instance.AddAction(actionId + 3);
                        break;
                }
                //Place Trap
                mapSkills[selectedMapSkill].MapUse(hit.transform, angle);
                selectedMapSkill = -1;
            }
        }


    }
}