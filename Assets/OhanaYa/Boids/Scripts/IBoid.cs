using UnityEngine;

using System.Collections.Generic;

namespace OhanaYa.Boids
{
    public interface IBoid
    {
        Transform Transform { get; }

        List<IBoid> Neighbors { get; }
    }
}