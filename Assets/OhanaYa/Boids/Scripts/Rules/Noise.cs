using UnityEngine;
using UnityEngine.Assertions;

namespace OhanaYa.Boids.Rules
{
    [CreateAssetMenu(menuName = "OhanaYa/Boids/Rules/Noise")]
    public sealed class Noise : BoidRule
    {
        #region BoidRule
        public override Vector3 Evaluate(IBoid boid)
        {
            return Random.onUnitSphere;
        }
        #endregion
    }
}