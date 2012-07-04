using System;
using System.Reactive.Linq;
using NUnit.Framework;

namespace nTextNetwork.Core.Test.Impl
{
    [TestFixture]
    public class ProducerConsumerTest
    {
        [Test]
        public void ProduceAndConsume_String_StringConsumed()
        {
            IObservable<string> source;
            IObserver<string> handler;

            IDisposable subscription = source.Subscribe((int x) => { Console.WriteLine("Received {0} from source.", x); }, (Exception ex) => { Console.WriteLine("Source signaled an error: {0}.", ex.Message); }, () => { Console.WriteLine("Source said there are no messages to follow anymore."); });
        }

    }
}