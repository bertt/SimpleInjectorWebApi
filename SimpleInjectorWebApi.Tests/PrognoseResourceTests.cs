using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleInjector;

namespace SimpleInjectorWebApi.Tests
{
    [TestClass]
    public class PrognoseResourceTests
    {
        private readonly HttpServer _server;

        public PrognoseResourceTests()
        {
            var httpconfig = ConfigHelper.GetHttpConfiguration();

            // Create the container as usual.
            var container = new Container();

            var mock = new Mock<IPrognoseRepository>();
            mock.Setup(foo => foo.GetPrognoses()).Returns(new List<Prognose>());
            container.Register(()=>mock.Object);

            // Verify the container configuration
            container.Verify();

            // Register the dependency resolver.
            httpconfig.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
 

            _server = new HttpServer(httpconfig);
        }

        [TestMethod]
        public void GetPrognoseReturnsProgonese()
        {
            // arrange
            var client = new HttpClient(_server);

            // act
            var response = client.GetAsync("http://server/api/prognose").Result;

            // assert
            var prognoses = response.Content.ReadAsAsync<List<Prognose>>().Result;
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            Assert.IsTrue(prognoses.Count == 0);
        }
    }
}

