using DataAccessLayer.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CommentManager
    {
        Repository<Comment> repo_Comment = new Repository<Comment>();
   
        public Comment AddComment (Comment Comment , int UserID , int StoryID)
        {
            StoryManager sm = new StoryManager();
            UserManager um = new UserManager();
            Story Story = sm.Find(StoryID);
            User User = um.FindUser(UserID);
            Comment.Story = Story;
            Comment.User = User;
            repo_Comment.Insert(Comment);
            repo_Comment.Save();
            return Comment;
        }

        public List<Comment> GetAllComments(int StoryID)
        {
            return repo_Comment.List(x => x.Story.ID == StoryID);
        }
    }
}
