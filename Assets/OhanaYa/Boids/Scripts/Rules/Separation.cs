using UnityEngine;
using UnityEngine.Assertions;

namespace OhanaYa.Boids.Rules
{
    [CreateAssetMenu(menuName = "OhanaYa/Boids/Rules/Separation")]
    public sealed class Separation : BoidRule
    {
        #region BoidRule
        public override Vector3 Evaluate(IBoid boid)
        {
            Assert.IsNotNull(boid);

            var neighbors = boid.Neighbors;
            Assert.IsNotNull(neighbors);
            var n = neighbors.Count;

            var v = Vector3.zero;

            if (n <= 0)
            {
                return v;
            }

            var position = boid.Transform.position;

            foreach (var other in neighbors)
            {
                var distance = other.Transform.position - position;

                if (distance.sqrMagnitude < 3 * 3)
                {
                    v -= distance;
                }
            }

            return v.normalized;
        }
        #endregion
    }
}