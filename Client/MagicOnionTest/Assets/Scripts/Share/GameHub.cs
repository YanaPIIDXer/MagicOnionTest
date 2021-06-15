﻿using MagicOnion;
using System.Threading.Tasks;

namespace MagicOnionCommon
{
    /// <summary>
    /// イベント
    /// </summary>
    public interface IGameHub : IStreamingHub<IGameHub, IGameHubReceiver>
    {
        /// <summary>
        /// 参加
        /// </summary>
        /// <param name="name">名前</param>
        Task JoinAsync(string name);

        /// <summary>
        /// 離脱
        /// </summary>
        /// <param name="name">名前</param>
        Task LeaveAsync(string name);

        /// <summary>
        /// メッセージ送信
        /// </summary>
        /// <param name="name">発言者名</param>
        /// <param name="message">発言内容</param>
        Task SendMessageAsync(string name, string message);

        /// <summary>
        /// 移動
        /// </summary>
        /// <param name="player">プレイヤー情報</param>
        Task MoveAsync(Player player);
    }

    /// <summary>
    /// イベント受信
    /// </summary>
    public interface IGameHubReceiver
    {
        /// <summary>
        /// 誰かが参加した
        /// </summary>
        /// <param name="name">名前</param>
        void OnJoin(string name);

        /// <summary>
        /// 誰かが離脱した
        /// </summary>
        /// <param name="name">名前</param>
        void OnLeave(string name);

        /// <summary>
        /// メッセージを受信した
        /// </summary>
        /// <param name="name">発言者名</param>
        /// <param name="message">発言内容</param>
        void OnSendMessage(string name, string message);

        /// <summary>
        /// 移動した
        /// </summary>
        /// <param name="player">プレイヤー情報</param>
        void OnMove(Player player);
    }
}
