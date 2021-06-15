using MagicOnion;

namespace MagicOnionCommon
{
    /// <summary>
    /// 計算用サービスインタフェース
    /// </summary>
    public interface ICalcService : IService<ICalcService>
    {
        /// <summary>
        /// 引数同士を加算
        /// </summary>
        /// <param name="x">引数１</param>
        /// <param name="y">引数２</param>
        /// <returns>引数の合計値</returns>
        UnaryResult<int> Sum(int x, int y);

        /// <summary>
        /// 引数同士を乗算
        /// </summary>
        /// <param name="x">引数１</param>
        /// <param name="y">引数２</param>
        /// <returns>引数の乗算値</returns>
        UnaryResult<int> Product(int x, int y);
    }
}
