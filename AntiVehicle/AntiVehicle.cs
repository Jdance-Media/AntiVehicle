using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;

namespace AntiVehicle
{
    public class AntiVehicle : RocketPlugin<AntiVehicleConfiguration>
    {
        protected override void Load()
        {
            Logger.Log("AntiVehicle is now loaded!");
            VehicleManager.onDamageTireRequested += VehicleManager_onDamageTireRequested;
        }

        private void VehicleManager_onDamageTireRequested(CSteamID instigatorSteamID, InteractableVehicle vehicle, int tireIndex, ref bool shouldAllow, EDamageOrigin damageOrigin)
        {
            if (instigatorSteamID != CSteamID.Nil && vehicle.lockedOwner != CSteamID.Nil)
            {
                var otherPlayer = UnturnedPlayer.FromCSteamID(vehicle.lockedOwner);
                var unturnedPlayer = UnturnedPlayer.FromCSteamID(instigatorSteamID);
                Logger.Log($"Hey! {unturnedPlayer.DisplayName} ({unturnedPlayer.CSteamID}) is trying to pop a tire on {otherPlayer.DisplayName}'s vehicle!");
            }
        }

        protected override void Unload()
        {
            Logger.Log("AntiVehicle is now unloaded!");
        }
    }
}

