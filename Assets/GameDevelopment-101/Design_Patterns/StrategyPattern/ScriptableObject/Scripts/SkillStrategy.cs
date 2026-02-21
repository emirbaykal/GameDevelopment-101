using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StrategyPattern.ScriptableObject.Scripts
{
    public abstract class SkillStrategy : UnityEngine.ScriptableObject
    {
        public GameObject skillPrefab;
        public float skillDuration;
        
        public abstract void CastSkill();
    }
}