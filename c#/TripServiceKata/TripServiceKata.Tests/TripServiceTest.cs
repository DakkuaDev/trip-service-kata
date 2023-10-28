using NUnit.Framework;
using System.Collections.Generic;

namespace TripServiceKata.Tests
{
    public class TripServiceTest
    {
        [Test]
        public void IsFriend_ShouldReturnTrueIfFriendExists()
        {
            // Arrange
            var user = new User.user(); // Crea una instancia de la clase User
            User.User loggedUser = UserSession.GetInstance().GetLoggedUser(); // Crea una instancia de loggedUser
            user.AddFriend(loggedUser); // Agrega a loggedUser como amigo

            // Act
            bool result = user.IsFriend();

            // Assert
            Assert.IsTrue(result, "El usuario debería ser un amigo.");

        }
    }
}
