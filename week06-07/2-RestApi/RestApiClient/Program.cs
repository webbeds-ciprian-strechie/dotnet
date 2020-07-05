using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rest Api client");

            try
            {
                var task1 = GetPostsAsync();

                var posts = JsonSerializer.Deserialize<List<Post>>(task1.Result);

                List<Task<string>> commentsTasks = new List<Task<string>>();
                foreach (Post post in posts)
                {
                    commentsTasks.Add(GetCommentsAsync(post.Id));
                }

                Task.WaitAll(commentsTasks.ToArray());

                var comments = JsonSerializer.Deserialize<List<Comment>>(task1.Result);
                foreach (Comment comment in comments)
                {
                    Console.WriteLine("Post " + comment.PostId + ":" + comment.Body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get data:" + ex.Message);
            }

            Console.WriteLine("Done!");
        }

        private static async Task<string> GetPostsAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> GetCommentsAsync(int postId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/comments?postId=" + postId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
