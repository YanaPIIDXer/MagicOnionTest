using MagicOnion;
using MagicOnion.Server;
using MagicOnionCommon;

namespace MagicOnionServer
{
    /// <summary>
    /// 計算API
    /// </summary>
    public class CalcService : ServiceBase<ICalcService>, ICalcService
    {
        /// <summary>
        /// 引数同士を加算
        /// </summary>
        /// <param name="x">引数１</param>
        /// <param name="y">引数２</param>
        /// <returns>引数の合計値</returns>
        public UnaryResult<int> Sum(int x, int y)
        {
            return UnaryResult(x + y);
        }

        /// <summary>
        /// 引数同士を乗算
        /// </summary>
        /// <param name="x">引数１</param>
        /// <param name="y">引数２</param>
        /// <returns>引数の乗算値</returns>
        public UnaryResult<int> Product(int x, int y)
        {
            return UnaryResult(x * y);
        }
    }
}
