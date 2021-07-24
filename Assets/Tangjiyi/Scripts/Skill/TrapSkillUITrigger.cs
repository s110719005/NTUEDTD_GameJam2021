using System;
using UnityEngine;
using UnityEngine.UI;
namespace SkillSystem
{
    public class TrapSkillUITrigger : MonoBehaviour
    {
        public int index = 0;
        public enum Direction
        {
            up = 0, down = 180, right = -90, left = 90
        }
        public Direction direction = Direction.up;
        void OnEnable()
        {
            //Register Button Events
            gameObject.GetComponent<Button>().onClick.AddListener(() => buttonCallBack(index, direction));
        }

        private void buttonCallBack(int index, Direction direction)
        {
            if (MovementManager.Instance.ExcutingRound)
            {
                Debug.Log("You Cannot do this during order-excuting stage");
                return;
            }

            SkillManager.Instance.UseMapSkill(index, (float)direction);
        }

        void OnDisable()
        {
            //Un-Register Button Events
            gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        }

    }
}