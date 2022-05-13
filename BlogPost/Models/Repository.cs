namespace BlogPost.Models
{
    public static class Repository
    {
        private static List<Post> allPost = new List<Post>();
        public static IEnumerable<Post> AllPost
        {
            get { return allPost; }
        }
        public static void Create(Post post)
        {
            allPost.Add(post);
        }
         public static void Delete(Post post)
        {
            allPost.Remove(post);
        }
    }
}
