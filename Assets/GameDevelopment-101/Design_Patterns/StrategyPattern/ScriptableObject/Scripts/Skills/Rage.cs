using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StrategyPattern.ScriptableObject.Scripts.Skills
{
    [CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills/Rage")]
    public class Rage : SkillStrategy
    {
        public override void CastSkill()
        {
            var rage = Instantiate(skillPrefab);
            Destroy(rage, skillDuration);
        }
    }
}