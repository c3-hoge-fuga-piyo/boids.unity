using UnityEngine;
using UnityEngine.Assertions;

namespace OhanaYa.Boids.Rules
{
    [CreateAssetMenu(menuName = "OhanaYa/Boids/Rules/Alignment")]
    public sealed class Alignment : BoidRule
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

            foreach (var other in neighbors)
            {
                v += other.Transform.forward;
            }

            var average = v / n;

            return average.normalized;
        }
        #endregion
    }
}