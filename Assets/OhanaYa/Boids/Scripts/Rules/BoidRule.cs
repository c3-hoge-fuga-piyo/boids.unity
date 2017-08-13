using UnityEngine;

namespace OhanaYa.Boids.Rules
{
    public abstract class BoidRule : ScriptableObject
    {
        public abstract Vector3 Evaluate(IBoid boid);
    }
}