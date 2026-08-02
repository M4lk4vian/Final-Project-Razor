using System.Collections.Generic;
using System.ComponentModel.Design;
namespace Models
{
    public class Comments
    {

        public int CommentId { get; set; }
        public string Content { get; set; }

        public Recipes Recipe { get; set; }

        public Users User { get; set; }


        public Comments()
        {

        }

        public Comments(int commentId, string content, Recipes recipe, Users user) 
        {
            this.CommentId = commentId;
            this.Content = content;
            this.Recipe = recipe;
            this.User = user;
        }


    }
}
