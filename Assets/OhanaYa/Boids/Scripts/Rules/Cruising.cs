using UnityEngine;
using UnityEngine.Assertions;

namespace OhanaYa.Boids.Rules
{
    [CreateAssetMenu(menuName = "OhanaYa/Boids/Rules/Cruising")]
    public sealed class Cruising : BoidRule
    {
        #region BoidRule
        public override Vector3 Evaluate(IBoid boid)
        {
            return boid.Transform.forward;
        }
        #endregion
    }
}