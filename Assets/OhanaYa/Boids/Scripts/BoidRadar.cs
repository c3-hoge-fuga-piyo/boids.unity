using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace OhanaYa.Boids
{
    using Events;

    [DisallowMultipleComponent]
    public sealed class BoidRadar : MonoBehaviour
    {
        #region Unity Events
        void OnTriggerEnter(Collider other)
        {
            var boid = other.GetComponent<IBoid>();
            Assert.IsNotNull(boid);

            ExecuteEvents.ExecuteHierarchy<IBoidFoundHandler>(
                this.gameObject,
                EventData.Get(boid),
                (h, d) => h.OnBoidFound(((EventData<IBoid>)d).Item1));
        }

        void OnTriggerExit(Collider other)
        {
            var boid = other.GetComponent<IBoid>();
            Assert.IsNotNull(boid);

            ExecuteEvents.ExecuteHierarchy<IBoidLostHandler>(
                this.gameObject,
                EventData.Get(boid),
                (h, d) => h.OnBoidLost(((EventData<IBoid>)d).Item1));
        }
        #endregion
    }
}