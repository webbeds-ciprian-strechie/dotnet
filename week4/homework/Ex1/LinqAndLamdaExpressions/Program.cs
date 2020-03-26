namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            // 3 - print number of posts for each user.
            Console.WriteLine("\t 3 - print number of posts for each user: ");

            var postsCounter = allPosts.GroupBy(post => post.UserId)
                          .Select(counter => new { UserId = counter.Key, Counter = counter.Count() });

            foreach (var cnt in postsCounter)
            {
                Console.WriteLine("user: " + cnt.UserId + " " + " cnt posts: " + cnt.Counter);
            }

            // 4 - find all users that have lat and long negative.
            Console.WriteLine("\t 4 - find all users that have lat and long negative: ");

            IEnumerable<User> users4 = allUsers.Where(user => user.Address.Geo.Lat < 0 && user.Address.Geo.Lng < 0);

            foreach (var user in users4)
            {
                Console.WriteLine("user: " + user.Id);
            }

            // 5 - find the post with longest body.
            Console.WriteLine("\t 5 - find the post with longest body: ");
            Post post5 = allPosts.OrderByDescending(post => post.Body.Length).First();
            Console.WriteLine("post id: " + post5.Id);

            // 6 - print the name of the employee that have post with longest body.
            Console.WriteLine("\t 6 - print the name of the employee that have post with longest body: ");
            User user6 = allUsers.Where(user => user.Id == post5.UserId).First();
            Console.WriteLine("user name: " + user6.Name);

            // 7 - select all addresses in a new List<Address>. print the list.
            Console.WriteLine("\t 7 - select all addresses in a new List<Address>. print the list: ");
            List<Address> lst = allUsers.Select(user => user.Address).ToList();
            foreach (var address in lst)
            {
                Console.WriteLine("Address: " + address.Street + " " + address.City + " " + address.Zipcode);
            }


            // 8 - print the user with min lat
            Console.WriteLine("\t 8 - print the user with min lat: ");
            var minLat = allUsers.Min(user => user.Address.Geo.Lat);
            User user8 = allUsers.First(user => user.Address.Geo.Lat == minLat);
            Console.WriteLine("user.id: " + user8.Id + " user name: " + user8.Name);

            // 9 - print the user with max long
            Console.WriteLine("\t 9 - print the user with max long: ");
            var maxLong = allUsers.Max(user => user.Address.Geo.Lng);
            User user9 = allUsers.First(user => user.Address.Geo.Lng == maxLong);
            Console.WriteLine("user.id: " + user9.Id + " user name: " + user9.Name);

            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only

            Console.WriteLine("\t 10 - create a new class: public class UserPost: ");
            List<UserPosts> upList = new List<UserPosts>();

            foreach (var user in allUsers)
            {
                UserPosts up = new UserPosts();
                up.Posts = allPosts.Where(post => post.UserId == user.Id).ToList();
                upList.Add(up);
            }

            // 11 - order users by zip code
            Console.WriteLine("\t 11 - order users by zip code: ");
            IEnumerable<User> myUsers11 = allUsers.OrderBy(user => user.Address.Zipcode);
            foreach (var user in myUsers11)
            {
                Console.WriteLine("user: " + user.Id);
            }
            // 12 - order users by number of posts
            Console.WriteLine("\t 12 - order users by number of posts: ");
            var postsCounter12 = allPosts.GroupBy(post => post.UserId)
              .Select(counter => new { UserId = counter.Key, Counter = counter.Count() }).ToDictionary(grp => grp.UserId, grp => grp.Counter);

            IEnumerable<User> myUsers12 = allUsers.OrderBy(user => postsCounter12[user.Id]);
            foreach (var user in myUsers12)
            {
                Console.WriteLine("user: " + user.Id);
            }

            Console.ReadKey();
        }

        public class UserPosts { public User User { get; set; } public List<Post> Posts { get; set; } }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
