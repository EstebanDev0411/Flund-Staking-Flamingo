using System.Numerics;
using Neo.SmartContract.Framework;

namespace Flund_Staking_Flamingo
{
    public partial class Flund_Staking_Flamingo : SmartContract
    {
        struct StakingReocrd
        {
            public BigInteger timeStamp;
            public BigInteger FlundDepositAmount;
            public BigInteger FUSDTDepositAmount;
            public BigInteger FlundPrice;
            public byte[] firstUserAddress;
            public byte[] secondUserAddress;
            public byte[] assetId;
            public BigInteger Profit;
        }
    }
}
