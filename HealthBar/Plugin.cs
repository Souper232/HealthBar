using Exiled.API.Features;
using System;

namespace HealthBar
{
    public class Instance : Plugin<Config>
    {
        public static Instance Plugin;
        public override string Author { get; } = "Soup";
        public override string Name { get; } = "HealthBar";

        private EventHandlers _eventHandlers;
        public override void OnEnabled()
        {
            Plugin = this;
            _eventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Player.UsedItem += _eventHandlers.OnHeal;
            Exiled.Events.Handlers.Player.Spawned += _eventHandlers.OnSpawned;
            Exiled.Events.Handlers.Player.Hurt += _eventHandlers.OnHurt;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.UsedItem -= _eventHandlers.OnHeal;
            Exiled.Events.Handlers.Player.Spawned -= _eventHandlers.OnSpawned;
            Exiled.Events.Handlers.Player.Hurt -= _eventHandlers.OnHurt;
            base.OnDisabled();
        }
    }
}