using UnityEngine.EventSystems;

namespace OhanaYa.Boids.Events
{
    public interface IBoidFoundHandler : IEventSystemHandler
    {
        void OnBoidFound(IBoid boid);
    }

    public interface IBoidLostHandler : IEventSystemHandler
    {
        void OnBoidLost(IBoid boid);
    }
}