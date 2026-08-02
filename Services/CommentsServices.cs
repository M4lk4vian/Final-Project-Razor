using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class CommentsServices : ICommentsServices
    {

        private readonly CommentsRepo _commentsRepo = new CommentsRepo();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public Comments comment = new Comments();
        public List<Comments> comments = new List<Comments>();

        public Recipes recipe = new Recipes();

        public Users user = new Users();
        public Comments Create(Comments comment)
        {
            return _commentsRepo.Create(comment);
        }

        public Comments RetrieveById(int CommentId)
        {

            DataTable dt = _commentsRepo.RetrieveById(CommentId);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];
            Comments comment = new Comments(
                Convert.ToInt32(dr["commentId"]),
                dr["content"].ToString(),
                _recipesServices.RetrieveById(Convert.ToInt32(dr["recipeId"])),
                _usersServices.RetrieveById(Convert.ToInt32(dr["userId"])));
            
            return comment;
        }

        public List<Comments> RetrieveCommentsByUserId(int UserId)
        {
            DataTable dt = _commentsRepo.RetrieveCommentsByUserId(UserId);
            List<Comments> comments = new List<Comments>();
            Users user = _usersServices.RetrieveById(UserId);
            foreach(DataRow dr in dt.Rows)
            {
                Comments comment = new Comments(
                    Convert.ToInt32(dr["commentId"]),
                    dr["content"].ToString(),
                    _recipesServices.RetrieveById(Convert.ToInt32(dr["recipeId"])),
                    user);

                comments.Add(comment);
            }
            return comments;
        }

        public List<Comments> RetrieveCommentsByRecipeId(int RecipeId)
        {
            DataTable dt = _commentsRepo.RetrieveCommentsByRecipeId(RecipeId);
            List<Comments> comments = new List<Comments>();
            Recipes recipe = _recipesServices.RetrieveById(RecipeId);
            foreach (DataRow dr in dt.Rows)
            {
                Comments comment = new Comments(
                    Convert.ToInt32(dr["commentId"]),
                    dr["content"].ToString(),
                    recipe,
                    _usersServices.RetrieveById(Convert.ToInt32(dr["userId"])));

                comments.Add(comment);
            }
            return comments;
        }

        public Comments Update(Comments comment)
        {
            return _commentsRepo.Update(comment);
        }

    }
}
