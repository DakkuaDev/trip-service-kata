using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            List<Trip> tripList = new List<Trip>();
            User.User loggedUser = UserSession.GetInstance().GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                isFriend = IsFriend(user, loggedUser);
                if (isFriend)
                {
                    tripList = TripDAO.FindTripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }


        }

        bool IsFriend(User.User user, User.User loggedUser)
        {
            List<User.User> friends = user.GetFriends();
            return friends.Exists(friend => friend.Equals(loggedUser));
        }
    }
}
