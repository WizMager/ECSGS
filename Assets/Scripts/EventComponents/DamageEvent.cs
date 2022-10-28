using Leopotam.Ecs;

namespace EventComponents
{
    public struct DamageEvent
    {
        public EcsEntity Target;
        public int Damage;
    }
}