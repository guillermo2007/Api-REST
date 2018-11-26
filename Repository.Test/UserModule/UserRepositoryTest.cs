using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Moq;
using Repository.UserModule.Interfaces;
using System.Linq;
using Domain.UserModule.Aggregates;

namespace Repository.Test.UserModule
{
    [TestClass]

    public class UserRepositoryTest
    {
        public IUserRepository MockUserRepository;

        private Dictionary<string, Guid> UsersGuid;

        public UserRepositoryTest()
        {
            UsersGuid = new Dictionary<string, Guid>();
            UsersGuid.Add("Guillermo", Guid.NewGuid());
            UsersGuid.Add("Pepe", Guid.NewGuid());
            UsersGuid.Add("Maria", Guid.NewGuid());
            IList<User> users = new List<User>()
            {
                new User(UsersGuid["Guillermo"],"Guillermo", DateTime.Parse("29/10/1988")),
                new User(UsersGuid["Pepe"],"Pepe",DateTime.Parse("02/03/2008")),
                new User(UsersGuid["Maria"],"Maria", DateTime.Now)
            };        

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(ur => ur.GetAll()).Returns(users);
            mockUserRepository.Setup(ur => ur.Get(It.IsAny<Guid>())).Returns((Guid id) => users.Where(x => x.Id == id).First());
            mockUserRepository.Setup(ur => ur.Add(It.IsAny<User>())).Returns(
                (User user) =>
                {
                    if (user.Id.Equals(default(Guid)))
                    {
                        user.GenerateNewId();
                        users.Add(user);
                    }
                    else
                    {
                        var userDb = users.Where(x => x.Id == user.Id).Single();
                        if (userDb != null)
                            return null;
                        userDb.Name = user.Name;
                        userDb.Birthdate = user.Birthdate;
                    }
                    return user;
                }
           );

            mockUserRepository.Setup(ur => ur.Update(It.IsAny<User>())).Returns(
                 (User user) =>

                 {
                     var userDb = users.Where(x => x.Id == user.Id).Single();
                     if (userDb == null)
                         return null;
                     userDb.Name = user.Name;
                     userDb.Birthdate = user.Birthdate;

                     return userDb;
                 }
            );
            MockUserRepository = mockUserRepository.Object;

        }



        [TestMethod]
        public void CanReturnAllUsers()
        {
            var users = MockUserRepository.GetAll();
            Assert.IsNotNull(users);
            Assert.AreEqual(3, users.Count());
        }



        [TestMethod]
        public void CanReturnUserById()
        {
            var user = MockUserRepository.Get(UsersGuid["Guillermo"]);

            Assert.IsNotNull(user);
            Assert.AreEqual("Guillermo", user.Name);
        }

        [TestMethod]
        public void CanInsertUser()
        {
            var user = new User("Marta", DateTime.Parse("01/01/1977"));
            UsersGuid.Add(user.Name, user.Id);


            MockUserRepository.Add(user);

            var numUsers = MockUserRepository.GetAll().Count();
            Assert.AreEqual(4, numUsers);

            var userNew = MockUserRepository.Get(UsersGuid["Marta"]);
            Assert.AreEqual("Marta", userNew.Name);
        }

        [TestMethod]
        public void CaunUpdateUser()
        {
            var user = MockUserRepository.Get(UsersGuid["Pepe"]);
            Assert.IsNotNull(user);
            Assert.AreEqual("Pepe", user.Name);

            user.Name = "Alfredo";
            UsersGuid.Remove("Pepe");
            UsersGuid.Add(user.Name, user.Id);
            var result = MockUserRepository.Update(user);
            Assert.IsNotNull(result);

            var userUpdated = MockUserRepository.Get(UsersGuid["Alfredo"]);
            Assert.AreEqual("Alfredo", userUpdated.Name);

        }
    }
}
