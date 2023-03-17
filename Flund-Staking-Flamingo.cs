using System;
using System.ComponentModel;
using System.Numerics;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

namespace Flund_Staking_Flamingo
{
    [ManifestExtra("Author", "")]
    [ManifestExtra("Email", "")]
    [ManifestExtra("Description", "")]
    [ContractPermission("*", "*")]
    public partial class Flund_Staking_Flamingo : SmartContract
    {
        [InitialValue("NftS1gfUFrJ46oByhpVavEBB1ywmNUKZ5h", ContractParameterType.Hash160)];
        private static readonly byte[] firstUserHash;
        private static readonly byte[] StakingAddress = {0x01, 0x23, 0x45, 0x67, 0x89, 0xab};
        private static readonly uint StartClaimTimeStamp = 1601269200;
        [DisplayName("Smart Contract Transfer Lock")]
        public static bool Locking(byte[] fromAddress, BigInteger amount)
        {
            byte[] self = ExecutionEngine.ExecutingScriptHash;
            
            // Check that the sender has enough funds
            BigInteger assetBalance = (BigInteger)((DyncCall)FirstUserHash.ToDelegate())("balanceOf", new object[] { self });
            if (assetBalance < amount)
            {
                return false;
            } 
            object[] Params = new object[]
            {
                fromAddress,
                StakingAddress,
                amount
            }
            // Transfer the funds to the staking address
            Transfer(Callers(0), StakingAddress, amount);

            // Store the staking information in the contract storage
            byte[] key = new byte[] { 0x01 };
            Storage.Put(Storage.CurrentContext, key.Concat(address), amount);
            key = new byte[] { 0x02 };
            Storage.Put(Storage.CurrentContext, key.Concat(address), duration);
        }

        // [DisplayName("withdraw")]
        // public static void Withdraw(byte[] address)
        // {
        //     // Get the staking information from the contract storage
        //     byte[] key = new byte[] { 0x01 };
        //     BigInteger amount = Storage.Get(Storage.CurrentContext, key.Concat(address)).AsBigInteger();
        //     if (amount == 0) return;

        //     key = new byte[] { 0x02 };
        //     int duration = (int)Storage.Get(Storage.CurrentContext, key.Concat(address)).AsBigInteger();

        //     // Check that the staking period has ended
        //     uint timestamp = Neo.SmartContract.Framework.Services.Neo.Runtime.Time;
        //     uint stakedTime = timestamp - (uint)duration;
        //     if (stakedTime < Storage.Get(Storage.CurrentContext, key.Concat(address)).r()) return;

        //     // Calculate the reward amount
        //     BigInteger reward = amount * 10 / 100;

        //     // Transfer the staked amount and reward to the user
        //     Transfer(StakingAddress, address, amount + reward);

        //     // Delete the staking information from the contract storage
        //     key = new byte[] { 0x01 };

        // }

        private static BigInteger GetCurrentTimeStamp() 
        {
            return Runtime.Time;
        }

    }
}

