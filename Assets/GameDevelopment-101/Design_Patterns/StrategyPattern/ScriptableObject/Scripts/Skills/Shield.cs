using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StrategyPattern.ScriptableObject.Scripts.Skills
{
    [CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills/Shield")]
    public class Shield : SkillStrategy
    {
        public override void CastSkill()
        {
            var shield = Instantiate(skillPrefab);
            Destroy(shield, skillDuration);
        }
    }
}