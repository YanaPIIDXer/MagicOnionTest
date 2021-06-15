using System;
using MessagePack;

namespace MagicOnionCommon
{
    /// <summary>
    /// プレイヤーの情報
    /// </summary>
    [MessagePackObject]
    public class Player
    {
        /// <summary>
        /// 名前
        /// </summary>
        [Key(0)]
        public string Name = "";

        /// <summary>
        /// X座標
        /// </summary>
        [Key(1)]
        public float X = 0.0f;

        /// <summary>
        /// Y座標
        /// </summary>
        [Key(2)]
        public float Y = 0.0f;

        /// <summary>
        /// Z座標
        /// </summary>
        [Key(3)]
        public float Z = 0.0f;
    }
}
