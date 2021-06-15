using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using MagicOnion.Client;
using MagicOnionCommon;

namespace Client
{
    /// <summary>
    /// Hubイベントテスト用Component
    /// </summary>
    public class HubTest : MonoBehaviour, IGameHubReceiver
    {
        /// <summary>
        /// チャンネル
        /// </summary>
        private Channel channel = null;

        /// <summary>
        /// Hub
        /// </summary>
        private IGameHub hub = null;

        async void Start()
        {
            channel = new Channel("localhost:12345", ChannelCredentials.Insecure);
            hub = await StreamingHubClient.ConnectAsync<IGameHub, IGameHubReceiver>(channel, this);

            Debug.Log("Join");
            await hub.JoinAsync("TestUser" + UnityEngine.Random.Range(0, 100));
        }

        async void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("SendMessage");
                await hub.SendMessageAsync("Test");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("Move");
                await hub.MoveAsync(10, 0, 10);
            }
        }

        async void OnDestroy()
        {
            if (hub != null)
            {
                await hub.LeaveAsync();
                await hub.DisposeAsync();
            }

            if (channel != null)
            {
                await channel.ShutdownAsync();
            }
        }

        public void OnJoin(string name)
        {
            Debug.Log("Join:" + name);
        }

        public void OnLeave(string name)
        {
            Debug.Log("Leave:" + name);
        }

        public void OnMove(Player player)
        {
            Debug.Log("Move:" + player.Name);
        }

        public void OnSendMessage(string name, string message)
        {
            Debug.Log("Message " + name + " : " + message);
        }
    }
}
