using Data;
using EventComponents;
using Leopotam.Ecs;
using UIScripts;
using UnityEngine;

namespace Systems
{
    public class PauseSystem : IEcsRunSystem
    {
        private EcsFilter<PauseGameEvent> _filter;
        private RuntimeData _runtimeData;
        private UI _ui;

        public void Run()
        {
            foreach (var i in _filter)
            {
                _filter.GetEntity(i).Del<PauseGameEvent>();
                _runtimeData.IsPaused = !_runtimeData.IsPaused;
                Time.timeScale = _runtimeData.IsPaused ? 0f : 1f;
                _ui.pauseScreen.Show(_runtimeData.IsPaused);
            }
        }
    }
}