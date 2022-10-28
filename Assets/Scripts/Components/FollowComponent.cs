using Leopotam.Ecs;

namespace Components
{
    public struct FollowComponent
    {
        public EcsEntity targetEntity;
        public float nextAttackTime;
    }
}