using Components;
using Components.Ignore;
using Leopotam.Ecs;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        public EcsEntity Entity;

        public void Shoot()
        {
            Entity.Get<HasWeapon>().weapon.Get<Shoot>();
        }

        public void Reload()
        {
            Entity.Get<HasWeapon>().weapon.Get<ReloadFinish>();
        }
    }
}