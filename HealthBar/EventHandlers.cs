using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;

namespace HealthBar
{
    public class EventHandlers
    {
        public void OnSpawned(SpawnedEventArgs ev)
        {
            if (ev.Player.Role.Team == PlayerRoles.Team.Dead)
            {
                // Pak změnit (musíte optimalizovat kód a změnit systém )
                ev.Player.CustomInfo = string.Empty;
                return;
            }
            Timing.CallDelayed(1f, () =>
            {
                Player player = ev.Player;
                float maxHealth = player.MaxHealth;
                float currentHealth = player.Health;
                int healthPercentage = Mathf.RoundToInt((currentHealth / maxHealth) * 36);
                // zinscenování změny personálních informací o hráči představuje počet symbolů krychle o 36 procent na každou kostku v různých barvách
                string customInfo = $"<size=8><color=#DC143C>{new string('█', healthPercentage)}</color><color=#FFFFFF>{new string('█', 36 - healthPercentage)}</color></size>\n";

                if (player.CustomInfo != null)
                {
                    string pattern = @"<size=8><color=#DC143C>.+?</color><color=#FFFFFF>.+?</color></size>";
                    string replaceci = Regex.Replace(player.CustomInfo, pattern, "");
                    replaceci = replaceci.Replace("<size=8><color=#DC143C>████████████████████████████████████</color><color=#FFFFFF></color></size>\n", string.Empty);
                    replaceci = replaceci.Replace("<size=8><color=#DC143C></color><color=#FFFFFF>████████████████████████████████████</color></size>\n", string.Empty);
                    customInfo += replaceci;
                }
                player.CustomInfo = customInfo;
            });
        }
        public void OnHeal(Exiled.Events.EventArgs.Player.UsedItemEventArgs ev)
        {
            if (ev.Player != null)
            {
                Player player = ev.Player;
                float maxHealth = player.MaxHealth;
                float currentHealth = player.Health;
                if (currentHealth <= 0 || player.IsDead)
                {
                    ev.Player.CustomInfo = string.Empty;
                    return;
                }
                // představuje v procentech
                int healthPercentage = Mathf.RoundToInt((currentHealth / maxHealth) * 36);
                // počet symbolů na jednu kostku symbol
                string customInfo = $"<size=8><color=#DC143C>{new string('█', healthPercentage)}</color><color=#FFFFFF>{new string('█', 36 - healthPercentage)}</color></size>\n";
                // zinscenování změny personálních informací o hráči představuje počet symbolů krychle o 36 procent na každou kostku v různých barvách
                if (player.CustomInfo != null)
                {
                    string pattern = @"<size=8><color=#DC143C>.+?</color><color=#FFFFFF>.+?</color></size>\n";
                    string replaceci = Regex.Replace(player.CustomInfo, pattern, "");
                    replaceci = replaceci.Replace("<size=8><color=#DC143C>████████████████████████████████████</color><color=#FFFFFF></color></size>\n", string.Empty);
                    replaceci = replaceci.Replace("<size=8><color=#DC143C></color><color=#FFFFFF>████████████████████████████████████</color></size>\n", string.Empty);
                    customInfo += replaceci;
                }
                player.CustomInfo = customInfo;
            }
        }
        public void OnHurt(HurtEventArgs ev)
        {
            if (ev.Player != null)
            {
                Player player = ev.Player;
                float maxHealth = player.MaxHealth;
                float currentHealth = player.Health;
                if (currentHealth <= 0 || player.IsDead)
                {
                    ev.Player.CustomInfo = string.Empty;
                    return;
                }
                int healthPercentage = Mathf.RoundToInt((currentHealth / maxHealth) * 36);
                // zinscenování změny personálních informací o hráči představuje počet symbolů krychle o 36 procent na každou kostku v různých barvách
                string customInfo = $"<size=8><color=#DC143C>{new string('█', healthPercentage)}</color><color=#FFFFFF>{new string('█', 36 - healthPercentage)}</color></size>\n";

                if (player.CustomInfo != null)
                {
                    string pattern = @"<size=8><color=#DC143C>.+?</color><color=#FFFFFF>.+?</color></size>\n";
                    string replaceci = Regex.Replace(player.CustomInfo, pattern, "");
                    replaceci = replaceci.Replace("<size=8><color=#DC143C>████████████████████████████████████</color><color=#FFFFFF></color></size>\n", "");
                    replaceci = replaceci.Replace("<size=8><color=#DC143C></color><color=#FFFFFF>████████████████████████████████████</color></size>\n", "");
                    customInfo += replaceci;
                }
                player.CustomInfo = customInfo;
            }
        }
    }
}
