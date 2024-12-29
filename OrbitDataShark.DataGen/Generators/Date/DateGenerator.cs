using Bogus;
using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Generators.Date
{
    public class DateGenerator : Generator
    {
        public DateGenerator(GeneratorDescriptor descriptor) : base(descriptor)
        {
        }

        public override Func<Faker, T, R> Generate<T, R>()
        {
            var descriptor = (DateGeneratorDescriptor)base.Descriptor;

            return descriptor.DateType switch
            {
                DateType.Between => (Faker f, T owner) => Convert<R>(f.Date.Between(descriptor.DateStart, descriptor.DateEnd)),
                DateType.BetweenDateOnly => (Faker f, T owner) => Convert<R>(f.Date.BetweenDateOnly(descriptor.DateOnlyStart, descriptor.DateOnlyEnd)),
                DateType.BetweenOffset => (Faker f, T owner) => Convert<R>(f.Date.BetweenOffset(descriptor.DateOffsetStart, descriptor.DateOffsetEnd)),
                DateType.BetweenTimeOnly => (Faker f, T owner) => Convert<R>(f.Date.BetweenTimeOnly(descriptor.TimeOnlyStart, descriptor.TimeOnlyEnd)),
                DateType.Future => (Faker f, T owner) => Convert<R>(f.Date.Future(descriptor.Years, descriptor.RefDate)),
                DateType.FutureDateOnly => (Faker f, T owner) => Convert<R>(f.Date.FutureDateOnly(descriptor.Years, descriptor.RefDateOnly)),
                DateType.FutureOffset => (Faker f, T owner) => Convert<R>(f.Date.FutureOffset(descriptor.Years, descriptor.RefDateOffset)),
                DateType.Month => (Faker f, T owner) => Convert<R>(f.Date.Month()),
                DateType.Past => (Faker f, T owner) => Convert<R>(f.Date.Past(descriptor.Years,descriptor.RefDate)),
                DateType.PastDateOnly => (Faker f, T owner) => Convert<R>(f.Date.PastDateOnly(descriptor.Years, descriptor.RefDateOnly)),
                DateType.PastOffset => (Faker f, T owner) => Convert<R>(f.Date.PastOffset(descriptor.Years, descriptor.RefDateOffset)),
                DateType.Recent => (Faker f, T owner) => Convert<R>(f.Date.Recent(descriptor.Days, descriptor.RefDate)),
                DateType.RecentDateOnly => (Faker f, T owner) => Convert<R>(f.Date.RecentDateOnly(descriptor.Days, descriptor.RefDateOnly)),
                DateType.RecentOffset => (Faker f, T owner) => Convert<R>(f.Date.RecentOffset(descriptor.Days, descriptor.RefDateOffset)),
                DateType.RecentTimeOnly => (Faker f, T owner) => Convert<R>(f.Date.RecentTimeOnly(descriptor.Days, descriptor.RefTimeOnly)),
                DateType.Soon => (Faker f, T owner) => Convert<R>(f.Date.Soon(descriptor.Days, descriptor.RefDate)),
                DateType.SoonDateOnly => (Faker f, T owner) => Convert<R>(f.Date.SoonDateOnly(descriptor.Days, descriptor.RefDateOnly)),
                DateType.SoonOffset => (Faker f, T owner) => Convert<R>(f.Date.SoonOffset(descriptor.Days, descriptor.RefDateOffset)),
                DateType.SoonTimeOnly => (Faker f, T owner) => Convert<R>(f.Date.SoonTimeOnly(descriptor.Days, descriptor.RefTimeOnly)),
                DateType.TimeSpan => (Faker f, T owner) => Convert<R>(f.Date.Timespan(descriptor.MaxTimeSpan)),
                DateType.TimeZoneString => (Faker f, T owner) => Convert<R>(f.Date.TimeZoneString()),
                DateType.WeekDay => (Faker f, T owner) => Convert<R>(f.Date.Weekday(descriptor.WeekDayAbbrviated)),
                _ => throw new NotImplementedException(),
            };
        }

    }
}
