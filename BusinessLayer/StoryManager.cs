using DataAccessLayer.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StoryManager
    {
        Repository<Story> repo_Story = new Repository<Story>();
        Repository<User> repo_User = new Repository<User>();

        public List<Story> GetAllStories()
        {
            return repo_Story.List();
        }

        public Story Find(int data)
        {
            return repo_Story.Find(x => x.ID == data);
        }

        public void InsertStory(string path,string StoryComment, int UserID)
        {
            User user = repo_User.Find(x => x.ID == UserID);
            Story story = new Story();
            story.User = user;
            story.Text = StoryComment;
            story.ImagePath = path;
            story.LikeCount = 0;
            repo_Story.Insert(story);
        }

        public int AddLike (int StoryID)
        {
            Story Story = repo_Story.Find(x => x.ID == StoryID);
            int NewLikeCount = Story.LikeCount+1;
            Story.LikeCount = NewLikeCount;
            repo_Story.Save();

            return NewLikeCount;
        }
    }
}
