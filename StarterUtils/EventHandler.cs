using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using Exiled.Events.EventArgs.Server;
using InventorySystem.Items.Firearms.Attachments;
using MEC;
using PlayerRoles;
using StartUtilis;
using System.Linq;

namespace StartUtilis
{
    internal class EventHandler
    {
        public Config _config;
        public EventHandler(Plugin plugin) => _config = plugin.Config;

        internal void OnWaitingForPlayers()
        {
            if (!_config.IsDisableLock) return;
            Warhead.IsLocked = false;
            Round.IsLobbyLocked = false;
            Round.IsLocked = false;
        }

        internal void OnRoundStarted()
        {
            if (!_config.IsFriendlyFire) return;
            Server.FriendlyFire = false;
        }

        internal void OnJoined(VerifiedEventArgs ev)
        {
            if (_config.IsUnmute)
            {
                ev.Player.UnMute();
            }

            if (_config.IsJoinBroadcast)
            {
                ev.Player.Broadcast(10, _config.JoinBroadcast.Replace("%nick%", ev.Player.Nickname));
            }
        }

        internal void OnSpawned(SpawnedEventArgs ev)
        {
            if (ev.Player == null) return;

            if (!_config.IsGiveAmmo) return;

            if (ev.Player.IsHuman)
            {
                Timing.CallDelayed(0.1f, () =>
                {
                    var value = _config.GiveAmmo;
                    ev.Player.SetAmmo(AmmoType.Nato9, value);
                    ev.Player.AddAmmo(AmmoType.Ammo44Cal, value);
                    ev.Player.AddAmmo(AmmoType.Nato556, value);
                    ev.Player.AddAmmo(AmmoType.Nato762, value);
                    ev.Player.AddAmmo(AmmoType.Ammo12Gauge, value);
                });
            }
        }

        internal void OnShooting(ShootingEventArgs ev)
        {
            if (!_config.IsInfiniteAmmo) return;

            var fire = (Firearm)ev.Player.CurrentItem;

            if (fire.Type == ItemType.ParticleDisruptor) return;
            ev.Player.AddAmmo(fire.AmmoType, 1);

            if (fire.AttachmentIdentifiers.Last().Name == AttachmentName.ShotgunDoubleShot)
            {
                ev.Player.AddAmmo(fire.AmmoType, 1);
            }
        }

        internal void OnDropAmmo(DroppingAmmoEventArgs ev)
        {
            if (!_config.IsAllowDropAmmo) return;
            ev.IsAllowed = false;
        }

        internal void OnAddTarget(AddingTargetEventArgs ev)
        {
            if (!_config.IsTriggerScp) return;
            ev.Target.ShowHint(_config.TriggerHint, 5f);
        }

        internal void OnDied(DiedEventArgs ev)
        {
            if (ev.Attacker == null) return;

            if (!_config.IsScpBroadcast) return;

            if (ev.TargetOldRole.GetTeam() == Team.SCPs)
            {
                if (ev.TargetOldRole == RoleTypeId.Scp0492) return;

                Map.Broadcast(_config.ScpBroadcastTime, _config.ScpBroadcast.
                    Replace("{scpRole}", ev.TargetOldRole.ToString().ToUpper()).
                    Replace("{scp}", ev.Player.Nickname).Replace("{attacker}", ev.Attacker.Nickname));
            }
        }

        internal void OnRoundEnd(RoundEndedEventArgs ev)
        {
            if (!_config.IsFriendlyFire) return;
            Server.FriendlyFire = true;
        }

        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            if (!_config.IsInfiniteRadio) return;
            ev.Drain = 0;
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (!_config.IsFriendlyFire) return;
            if (ev.Player != null && ev.Attacker != null && Round.IsEnded)
            {
                ev.Amount = _config.HitAmount;
                ev.IsAllowed = true;
            }
        }
    }
}
