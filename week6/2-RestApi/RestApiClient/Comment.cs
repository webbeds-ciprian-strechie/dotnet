using System;
using System.Collections.Generic;
using System.Text;

namespace RestApiClient
{
    class Comment
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Body { get; set; }
    }
}
