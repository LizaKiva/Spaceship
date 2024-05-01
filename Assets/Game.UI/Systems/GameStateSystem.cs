
using Game.Gameplay.Player;
using Game.Settings.Destroy;
using Leopotam.Ecs;
using System;
using UnityEditor;
using UnityEngine;

namespace Game.UI
{
    public class GameStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EndScreenComponent> endScreen = null;
        private readonly EcsFilter<ToggleEndScreenRequest> requests = null;
        void IEcsRunSystem.Run()
        {
            if (requests.IsEmpty()) return;

            foreach (var r in requests)
            {
                ref var request = ref requests.Get1(r);

                foreach (var s in endScreen)
                {
                    ref var screen = ref endScreen.Get1(s);

                    screen.root.gameObject.SetActive(request.enable);
                    if (request.enable)
                    {
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        Time.timeScale = 1f;
                    }
                }
            }
        }
    }
}
