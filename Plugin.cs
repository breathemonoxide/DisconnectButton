using BepInEx;
using PlayFab.DataModels;
using System;
using UnityEngine;
using Utilla;
using UnityEngine.XR;
using Photon.Pun;

namespace DisconnectButton
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private bool pressed;
        bool inRoom;

        void Start()
        {

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
           

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
        }

        void Update()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                if (!pressed)
                {
                    PhotonNetwork.LeaveRoom();
                }


            }
        }

        
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
           

            inRoom = true;
        }

       
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            

            inRoom = false;
        }
    }
}
