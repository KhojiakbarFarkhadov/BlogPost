namespace BlogPost.ViewModels
{
    public class PostCreateVM //ViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public string PostType { get; set; } = "Draft";
    }
}
