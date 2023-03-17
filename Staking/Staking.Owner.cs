﻿using Neo;
using Neo.SmartContract;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Services;
using System.Numerics;

namespace FLMStaking
{
    partial class FLMStaking
    {
        [InitialValue("NaBUWGCLWFZTGK4V9f4pecuXmEijtGXMNX", ContractParameterType.Hash160)]
        private static readonly UInt160 InitialOwner;

        [Safe]
        public static UInt160 GetOwner()
        {
            return OwnerStorage.Get();
        }

        public static bool SetOwner(UInt160 owner)
        {
            ExecutionEngine.Assert(Runtime.CheckWitness(GetOwner()), "SetOwner: CheckWitness failed, owner-".ToByteArray().Concat(owner).ToByteString());
            ExecutionEngine.Assert(CheckAddrValid(true, owner), "SetOwner: invalid owner-".ToByteArray().Concat(owner).ToByteString());
            OwnerStorage.Put(owner);
            return true;
        }

        public static bool AddAuthor(UInt160 author)
        {
            ExecutionEngine.Assert(Runtime.CheckWitness(GetOwner()), "AddAuthor: CheckWitness failed, owner-".ToByteArray().Concat(GetOwner()).ToByteString());
            ExecutionEngine.Assert(CheckAddrValid(true, author), "AddAuthor: invalid author-".ToByteArray().Concat(author).ToByteString());
            AuthorStorage.Put(author);
            return true;
        }

        [Safe]
        public static bool IsAuthor(UInt160 author)
        {
            ExecutionEngine.Assert(CheckAddrValid(true, author), "IsAuthor: invalid author-".ToByteArray().Concat(author).ToByteString());
            return AuthorStorage.Get(author);
        }

        [Safe]
        public static BigInteger GetAuthorCount()
        {
            return AuthorStorage.Count();
        }

        [Safe]
        public static UInt160[] GetAllAuthor()
        {
            BigInteger count = GetAuthorCount();
            return AuthorStorage.Find(count);
        }

        public static bool RemoveAuthor(UInt160 author)
        {
            ExecutionEngine.Assert(Runtime.CheckWitness(GetOwner()), "RemoveAuthor: CheckWitness failed, owner-".ToByteArray().Concat(GetOwner()).ToByteString());
            ExecutionEngine.Assert(CheckAddrValid(true, author), "RemoveAuthor: invalid author-".ToByteArray().Concat(author).ToByteString());
            ExecutionEngine.Assert(AuthorStorage.Get(author), "RemoveAuthor: not author".ToByteArray().Concat(author).ToByteString());
            AuthorStorage.Delete(author);
            return true;
        }
    }
}
