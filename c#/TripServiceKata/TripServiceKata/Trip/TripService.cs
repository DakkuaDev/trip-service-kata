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

            CheckLoggedUser(loggedUser);

            return CheckFriendTripList(user, tripList, loggedUser);
        }

        private List<Trip> CheckFriendTripList(User.User user, List<Trip> tripList, User.User loggedUser)
        {
            if (IsFriend(user, loggedUser))
            {
                tripList = TripDAO.FindTripsByUser(user);
            }

            return tripList;
        }

        private static void CheckLoggedUser(User.User loggedUser)
        {
            if (loggedUser == null) throw new UserNotLoggedInException();
        }

        bool IsFriend(User.User user, User.User loggedUser)
        {
            List<User.User> friends = user.GetFriends();
            return friends.Exists(friend => friend.Equals(loggedUser));
        }
    }
}
