using System;
using System.ComponentModel;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;

namespace Flund_Staking_Flamingo
{
    [DisplayName("Flund_Staking_Flamingo")]
    [ManifestExtra("Author", "NEO")]
    [ManifestExtra("Email", "developer@neo.org")]
    [ManifestExtra("Description", "This is a Flund_Staking_Flamingo")]
    public class Flund_Staking_Flamingo : SmartContract
    {
        public static bool Main()
        {
            return true;
        }
    }
}
