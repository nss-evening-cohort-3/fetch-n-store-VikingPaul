using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FetchNStore.DAL;
using FetchNStore.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace FetchNStore.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTests
    {

        Mock<ResponseContext> moq_context { get; set; }
        Mock<DbSet<Response>> moq_response { get; set; }
        List<Response> Response_list { get; set; }
        ResponseRepository repo { get; set; }

        public void ConnectMockToData()
        {
            var queryList = Response_list.AsQueryable();
            moq_response.As<IQueryable<Response>>().Setup(m => m.Provider).Returns(queryList.Provider);
            moq_response.As<IQueryable<Response>>().Setup(m => m.Expression).Returns(queryList.Expression);
            moq_response.As<IQueryable<Response>>().Setup(m => m.ElementType).Returns(queryList.ElementType);
            moq_response.As<IQueryable<Response>>().Setup(m => m.GetEnumerator()).Returns(() => queryList.GetEnumerator());
            moq_context.Setup(c => c.Responses).Returns(moq_response.Object);
            moq_response.Setup(c => c.Add(It.IsAny<Response>())).Callback((Response a) => Response_list.Add(a));
        }

        [TestInitialize]
        public void init()
        {
            moq_context = new Mock<ResponseContext>();
            moq_response = new Mock<DbSet<Response>>();
            Response_list = new List<Response>();
            ConnectMockToData();
            repo = new ResponseRepository(moq_context.Object);
        }
        [TestMethod]
        public void RepoIsNotNull()
        {
            ResponseRepository repo = new ResponseRepository();
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void RepoCanSave()
        {
            Response newResponse = new Response();
            repo.AddResponse(newResponse);
            int number = repo.GetResponses().Count;
            Assert.AreEqual(1, number);
        }
        [TestMethod]
        public void RepoCanGet()
        {
            Response newResponse = new Response { ResponseTime = "1" };
            repo.AddResponse(newResponse);
            string number = repo.GetResponses()[0].ResponseTime;
            Assert.AreEqual("1", number);
        }
    }
}
