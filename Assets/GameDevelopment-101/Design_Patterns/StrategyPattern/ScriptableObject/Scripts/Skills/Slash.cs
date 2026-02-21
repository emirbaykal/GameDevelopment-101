using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.StrategyPattern.ScriptableObject.Scripts.Skills
{
    [CreateAssetMenu(fileName = "Skills", menuName = "ScriptableObjects/Skills/Slash")]
    public class Slash : SkillStrategy
    {
        public override void CastSkill()
        {
            var slash = Instantiate(skillPrefab);
            Destroy(slash, skillDuration);
        }
    }
}