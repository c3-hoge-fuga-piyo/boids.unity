using UnityEngine;
using UnityEngine.Assertions;

using System.Collections.Generic;

namespace OhanaYa.Boids.Rules
{
    [CreateAssetMenu(menuName = "OhanaYa/Boids/Rules/Cohesion")]
    public sealed class Cohesion : BoidRule
    {
        #region BoidRule
        public override Vector3 Evaluate(IBoid boid)
        {
            Assert.IsNotNull(boid);

            var neighbors = boid.Neighbors;
            Assert.IsNotNull(neighbors);
            var n = neighbors.Count;

            var p = Vector3.zero;

            if (n <= 0)
            {
                return p;
            }

            foreach (var other in neighbors)
            {
                p += other.Transform.position;
            }

            var centroid = p / n;

            return (centroid - boid.Transform.position).normalized;
        }
        #endregion
    }
}