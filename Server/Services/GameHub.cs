using MagicOnionCommon;
using System;
using System.Threading.Tasks;
using MagicOnion.Server.Hubs;

namespace MagicOnionServer
{
    /// <summary>
    /// イベント
    /// </summary>
    public class GameHub : StreamingHubBase<IGameHub, IGameHubReceiver>, IGameHub
    {
        /// <summary>
        /// ルーム名
        /// </summary>
        private static readonly string roomName = "TestRoom";

        /// <summary>
        /// ルーム
        /// </summary>
        private IGroup room = null;

        /// <summary>
        /// 自分自身の情報
        /// </summary>
        private Player myInfo = null;

        /// <summary>
        /// 参加
        /// </summary>
        /// <param name="name">名前</param>
        public async Task JoinAsync(string name)
        {
            room = await Group.AddAsync(roomName);
            myInfo = new Player()
            {
                Name = name,
                X = 0.0f,
                Y = 0.0f,
                Z = 0.0f
            };
            Broadcast(room).OnJoin(myInfo.Name);
        }

        /// <summary>
        /// 離脱
        /// </summary>
        public async Task LeaveAsync()
        {
            await room.RemoveAsync(Context);
            Broadcast(room).OnLeave(myInfo.Name);
        }

        /// <summary>
        /// メッセージ送信
        /// </summary>
        /// <param name="message">発言内容</param>
        public async Task SendMessageAsync(string message)
        {
            Broadcast(room).OnSendMessage(myInfo.Name, message);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 移動
        /// </summary>
        /// <param name="X">X</param>
        /// <param name="Y">Y</param>
        /// <param name="Z">Z</param>
        public async Task MoveAsync(float X, float Y, float Z)
        {
            myInfo.X = X;
            myInfo.Y = Y;
            myInfo.Z = Z;
            Broadcast(room).OnMove(myInfo);
            await Task.CompletedTask;
        }
    }
}
