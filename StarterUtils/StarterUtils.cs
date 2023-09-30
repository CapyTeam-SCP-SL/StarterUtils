using Exiled.API.Features;
using Exiled.Events.Handlers;
using System;
using System.Collections.Generic;

namespace StartUtilis
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "StartUtils";
        public override string Author => "CapyTeam";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 2, 1);

        private EventHandler _eventHandler;
        public override void OnEnabled()
        {
            _eventHandler = new EventHandler(this);

            Exiled.Events.Handlers.Player.Spawned += _eventHandler.OnSpawned;
            Exiled.Events.Handlers.Player.Shooting += _eventHandler.OnShooting;
            Exiled.Events.Handlers.Scp096.AddingTarget += _eventHandler.OnAddTarget;
            Exiled.Events.Handlers.Player.Died += _eventHandler.OnDied;
            Exiled.Events.Handlers.Player.DroppingAmmo += _eventHandler.OnDropAmmo;
            Exiled.Events.Handlers.Player.UsingRadioBattery += _eventHandler.OnUsingRadioBattery;
            Exiled.Events.Handlers.Server.WaitingForPlayers += _eventHandler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += _eventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += _eventHandler.OnRoundEnd;
            Exiled.Events.Handlers.Player.Verified += _eventHandler.OnJoined;
            Exiled.Events.Handlers.Player.Hurting += _eventHandler.OnHurting;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Spawned -= _eventHandler.OnSpawned;
            Exiled.Events.Handlers.Player.Shooting -= _eventHandler.OnShooting;
            Exiled.Events.Handlers.Scp096.AddingTarget -= _eventHandler.OnAddTarget;
            Exiled.Events.Handlers.Player.Died -= _eventHandler.OnDied;
            Exiled.Events.Handlers.Player.DroppingAmmo -= _eventHandler.OnDropAmmo;
            Exiled.Events.Handlers.Player.UsingRadioBattery -= _eventHandler.OnUsingRadioBattery;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= _eventHandler.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= _eventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= _eventHandler.OnRoundEnd;
            Exiled.Events.Handlers.Player.Verified -= _eventHandler.OnJoined;
            Exiled.Events.Handlers.Player.Hurting -= _eventHandler.OnHurting;

            _eventHandler = null;

            base.OnDisabled();
        }
    }
}