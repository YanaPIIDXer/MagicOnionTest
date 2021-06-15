using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using MagicOnion.Client;
using MagicOnionCommon;

namespace Client
{
    /// <summary>
    /// APIを叩くテスト用Component
    /// </summary>
    public class ServiceTest : MonoBehaviour
    {
        /// <summary>
        /// チャンネル
        /// </summary>
        private Channel channel = null;

        /// <summary>
        /// API
        /// </summary>
        private ICalcService service = null;

        void Awake()
        {
            channel = new Channel("127.0.0.1:12345", ChannelCredentials.Insecure);
            service = MagicOnionClient.Create<ICalcService>(channel);

            ServiceCallTest();
        }

        async void OnDestroy()
        {
            await channel.ShutdownAsync();
        }

        /// <summary>
        /// APIを叩くテスト
        /// </summary>
        private async void ServiceCallTest()
        {
            var result = await service.Sum(1, 2);
            Debug.Log("Sum:" + result);

            result = await service.Product(3, 4);
            Debug.Log("Product:" + result);
        }
    }
}
