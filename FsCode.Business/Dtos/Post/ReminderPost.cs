namespace FsCodeBusiness.Dtos.Post
{
    public class ReminderPost
    {
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public string Method { get; set; }
    }
}
