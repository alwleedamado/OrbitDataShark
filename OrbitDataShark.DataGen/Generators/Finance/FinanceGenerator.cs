using Bogus;
using Bogus.Extensions.UnitedKingdom;
using OrbitDataShark.DataGen.Generators.Name;
using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Finance
{
    public class FinanceGenerator : Generator
    {
        public FinanceGenerator(GeneratorDescriptor descriptor) : base(descriptor)
        {
        }

        public override Func<Faker, T, R> Generate<T, R>()
        {
            var descriptor = (FinanceGeneratorDescriptor)base.Descriptor;

            return descriptor.FinanceType switch
            {
                FinanceType.Account => (Faker f, T owner) => Convert<R>(f.Finance.Account()),
                FinanceType.AccountName => (Faker f, T owner) => Convert<R>(f.Finance.AccountName()),
                FinanceType.Amount => (Faker f, T owner) => Convert<R>(f.Finance.Amount()),
                FinanceType.BankingSortCode => (Faker f, T owner) => Convert<R>(f.Finance.SortCode()),
                FinanceType.BIC => (Faker f, T owner) => Convert<R>(f.Finance.Bic()),
                FinanceType.BitcoinAddress => (Faker f, T owner) => Convert<R>(f.Finance.BitcoinAddress()),
                FinanceType.CreditCardCvv => (Faker f, T owner) => Convert<R>(f.Finance.CreditCardCvv()),
                FinanceType.CreditCardNumber => (Faker f, T owner) => Convert<R>(f.Finance.CreditCardNumber()),
                FinanceType.Currency => (Faker f, T owner) => Convert<R>(f.Finance.Currency()),
                FinanceType.EthereumAddress => (Faker f, T owner) => Convert<R>(f.Finance.EthereumAddress()),
                FinanceType.Iban => (Faker f, T owner) => Convert<R>(f.Finance.Iban()),
                FinanceType.LitecoinAddress => (Faker f, T owner) => Convert<R>(f.Finance.LitecoinAddress()),
                FinanceType.RountingNumber => (Faker f, T owner) => Convert<R>(f.Finance.RoutingNumber()),
                FinanceType.TransactionType => (Faker f, T owner) => Convert<R>(f.Finance.TransactionType()),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
