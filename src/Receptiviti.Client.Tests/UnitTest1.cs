﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Receptiviti.Client.Model;

namespace Receptiviti.Client.Tests
{

    [TestClass]
    public class UnitTest1
    {

        static readonly string API_KEY = "565df83d93aed404aba473d2";
        static readonly string API_SECRET_KEY = "k6IuDFgzxh453HVxSbJe0vov0g6YTBN5gpXhvaI8Jd0";

        [TestMethod]
        public async Task Test_GetPerson()
        {
            var api = new ReceptivitiClient(API_KEY, API_SECRET_KEY);
            var person = await api.GetPerson("57489384955bdb0647153c5e");
        }

        [TestMethod]
        public async Task Test_PostPerson()
        {
            var api = new ReceptivitiClient(API_KEY, API_SECRET_KEY);
            var rid = Guid.NewGuid().ToString();
            var person = await api.PostPerson(new CreatePersonRequest()
            {
                ClientReferenceId = rid,
                Name = "Test Person",
                Gender = Gender.Male,
                Tags = new string[] { "tag1", "tag2" },
            });
            Assert.AreEqual(rid, person.ClientReferenceId);
            Assert.AreEqual("Test Person", person.Name);
            Assert.AreEqual(Gender.Male, person.Gender);
            Assert.AreEqual(2, person.Tags.Length);
        }

        [TestMethod]
        public async Task Test_GetPersons()
        {
            var api = new ReceptivitiClient(API_KEY, API_SECRET_KEY);
            var lst = await api.GetPersons();
        }

        [TestMethod]
        public async Task Test_GetLsm()
        {
            var api = new ReceptivitiClient(API_KEY, API_SECRET_KEY);
            var person1 = await api.PostPerson(new CreatePersonRequest()
            {
                ClientReferenceId = Guid.NewGuid().ToString(),
                Name = "Test Person 1",
                Gender = Gender.Male,
                Tags = new string[] { "tag1", "tag2" },
            });
            var person2 = await api.PostPerson(new CreatePersonRequest()
            {
                ClientReferenceId = Guid.NewGuid().ToString(),
                Name = "Test Person 2",
                Gender = Gender.Male,
                Tags = new string[] { "tag1", "tag2" },
            });
            var sample1 = await api.PostPersonWritingSample(person1.Id, new WritingSampleRequest()
            {
                ContentSource = ContentSource.ProfessionalCorrespondence,
                Content = "hello this is a test",
                Recipient = person2.Id,
            });
            var sample2 = await api.PostPersonWritingSample(person2.Id, new WritingSampleRequest()
            {
                ContentSource = ContentSource.ProfessionalCorrespondence,
                Content = "hello this is a test",
                Recipient = person1.Id,
            });
            var lsm = await api.GetLsmScore(person1.Id, person2.Id);
        }

    }

}