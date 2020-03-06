using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using System;

namespace Snippets.LazyInjectionOnCastle
{
    public static class Program
    {
        public static void Main()
        {
            var container = new WindsorContainer();
            container.Register(
                Component.For<ILazyComponentLoader>().ImplementedBy<LazyOfTComponentLoader>(),
                Component.For<IService>().ImplementedBy<Service>().LifestyleTransient(),
                Component.For<ILazyService>().ImplementedBy<LazyService>().LifestyleTransient());

            var service = container.Resolve<IService>();
            service.DoSomething();
        }
    }

    public interface IService
    {
        void DoSomething();
    }

    public class Service : IService
    {
        private readonly Lazy<ILazyService> _lazyService;

        public Service(Lazy<ILazyService> lazyService)
        {
            _lazyService = lazyService ?? throw new ArgumentNullException(nameof(lazyService));
        }

        public void DoSomething()
        {
            _lazyService.Value.SpeakSomething();
        }
    }

    public interface ILazyService
    {
        void SpeakSomething();
    }

    public class LazyService : ILazyService
    {
        public void SpeakSomething()
        {
            Console.WriteLine("Hi! How are you?");
        }
    }
}