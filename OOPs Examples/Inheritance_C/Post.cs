using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_C
{
    internal class Post
    {
        private static int currentPostId;
        public int ID { get; set; }
        protected string Title { get; set; }
        protected string SendByUsername { get; set; }
        protected bool IsPublic { get; set; }

        public Post()
        {
            ID = 0;
            Title = "My First Post";
            IsPublic = true;
            SendByUsername = "Rajorshi Ghosh";
        }

        public Post(int i, string t, string s, bool p)
        {
            ID = GetNextID();
            Title = t;
            SendByUsername = s;
            IsPublic = p;
        }

        protected int GetNextID()
        {
            return ++currentPostId;
        }

        public void Update(string tit, bool pub) {
            Title = tit;
            IsPublic = pub;
        }

        public override string ToString()
        {
            return String.Format($"{this.ID} - {this.Title} - by {this.SendByUsername}");
        }
    }
}
