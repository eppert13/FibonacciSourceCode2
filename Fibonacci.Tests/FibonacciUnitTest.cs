using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci.Controllers;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Net;

namespace Fibonacci.Tests
{
    [TestClass]
    public class FibonacciUnitTest
    {
        [TestMethod]
        public void Fibonacci_ShouldReturnCorrectSequence()
        {
            // Check return value are fibonacci sequence
            var controller = new FibonacciController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            HttpResponseMessage result = controller.Get(6);
  
            var sequence = result.Content.ReadAsAsync<List<int>>();
            for (int i = 2; i<sequence.Result.Count; i++)
            {
                Assert.IsTrue(TwoPrecedingNumbersMatchCurrentNumber(sequence.Result[i-2], sequence.Result[i - 1], sequence.Result[i]));
            }
        }

        [TestMethod]
        public void Fibonacci_ShouldReturnErrorOnNegative()
        {
            // Check return value are fibonacci sequence
            var controller = new FibonacciController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            HttpResponseMessage result = controller.Get(-2);

            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void Fibonacci_ShouldReturnErrorOnZero()
        {
            // Check return value are fibonacci sequence
            var controller = new FibonacciController();
            controller.Request = new HttpRequestMessage();
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            HttpResponseMessage result = controller.Get(0);

            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
        }

        private bool TwoPrecedingNumbersMatchCurrentNumber(int preceding1, int preceding2, int current)
        {
            // Add 2 preceding numbers and check if they match current number
            // c=a+b
            // d=b+c
            // d-b=(b+c) - b=c

            bool precedingNumbersMatchCurrent = false;

            if ((preceding1 + preceding2) == current)
                precedingNumbersMatchCurrent = true;

            return precedingNumbersMatchCurrent;
        }
    }
}
